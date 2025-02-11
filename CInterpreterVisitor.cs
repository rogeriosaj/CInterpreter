using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Antlr4.Runtime.Misc;
using System.Linq;

public class CInterpreterVisitor : CBaseVisitor<object>
{
    private Dictionary<string, object> memory = new Dictionary<string, object>();
    private Dictionary<string, CParser.FunctionDeclarationContext> functions = new Dictionary<string, CParser.FunctionDeclarationContext>();
    private Dictionary<string, Dictionary<string, object>> structs = new Dictionary<string, Dictionary<string, object>>();
    // -------------------- VARIÁVEIS --------------------
    public override object VisitVariableDeclaration(CParser.VariableDeclarationContext context)
    {
        string tipo = context.type().GetText();
        string nome = context.variableDeclarator(0).GetText();
        string[] partes = nome.Split('=');
        string varName = partes[0].Trim();
        string valorStr = partes.Length > 1 ? partes[1].Trim() : null;

        object valor = tipo switch
        {
            "int" => valorStr != null ? int.Parse(valorStr) : 0,
            "float" or "double" => valorStr != null ? double.Parse(valorStr) : 0.0,
            "char" => valorStr != null ? valorStr.Replace("'", "") : '\0',
            _ => throw new Exception($"Erro: Tipo desconhecido '{tipo}'")
        };

        memory[varName] = valor;
        Console.WriteLine($"Variável declarada: {tipo} {varName} = {valor}");
        return null;
    }

    private int EvaluateExpression(string expr)
    {
        try
        {
            expr = expr.Trim();

            // Substituir variáveis por seus valores na memória
            foreach (var var in memory.Keys)
            {
                // Substituir variáveis no contexto da expressão
                expr = Regex.Replace(expr, $@"\b{var}\b", memory[var].ToString());
            }

            // Avaliar a expressão matemática usando DataTable
            DataTable table = new DataTable();
            object result = table.Compute(expr, "");

            return Convert.ToInt32(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao avaliar expressão '{expr}': {ex.Message}");
            return 0;
        }
    }


    private bool EvaluateCondition(string expr)
    {
        try
        {
            expr = expr.Trim();

            // Substituir variáveis na expressão
            foreach (var var in memory.Keys)
            {
                expr = Regex.Replace(expr, $@"\b{var}\b", memory[var].ToString());
            }

            Console.WriteLine($"DEBUG: Expressão condicional após substituição = '{expr}'");

            // Avaliar expressões compostas com && e ||
            string pattern = @"(\d+)\s*(==|!=|<=|>=|<|>)\s*(\d+)";
            Match match = Regex.Match(expr, pattern);

            if (!match.Success)
            {
                Console.WriteLine($"Erro ao avaliar condição '{expr}': Expressão inválida.");
                return false;
            }

            // Extraindo os operandos e o operador
            int leftOperand = int.Parse(match.Groups[1].Value);
            string op = match.Groups[2].Value;
            int rightOperand = int.Parse(match.Groups[3].Value);

            bool result = op switch
            {
                "==" => leftOperand == rightOperand,
                "!=" => leftOperand != rightOperand,
                "<"  => leftOperand < rightOperand,
                ">"  => leftOperand > rightOperand,
                "<=" => leftOperand <= rightOperand,
                ">=" => leftOperand >= rightOperand,
                _ => throw new Exception("Operador inválido.")
            };

            // Avaliar operadores && e || se existirem na expressão
            if (expr.Contains("&&"))
            {
                string[] subExpressions = expr.Split("&&");
                return EvaluateCondition(subExpressions[0].Trim()) && EvaluateCondition(subExpressions[1].Trim());
            }
            else if (expr.Contains("||"))
            {
                string[] subExpressions = expr.Split("||");
                return EvaluateCondition(subExpressions[0].Trim()) || EvaluateCondition(subExpressions[1].Trim());
            }

            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao avaliar condição '{expr}': {ex.Message}");
            return false;
        }
    }



    private int GetOperandValue(string operand)
    {
        if (int.TryParse(operand, out int number)) return number;
        if (memory.ContainsKey(operand)) return Convert.ToInt32(memory[operand]);
        throw new Exception($"Erro: Variável indefinida '{operand}'");
    }

    // -------------------- CONTROLE DE FLUXO --------------------
    public override object VisitIfStatement(CParser.IfStatementContext context)
    {
        string conditionText = context.expression().GetText();
        bool condition = EvaluateCondition(conditionText);

        if (condition)
        {
            Console.WriteLine("Executando bloco IF");
            Visit(context.statement(0));
        }
        else if (context.statement().Length > 1)
        {
            Console.WriteLine("Executando bloco ELSE");
            Visit(context.statement(1));
        }
        return null;
    }

    public override object VisitForStatement(CParser.ForStatementContext context)
    {
        var forControl = context.forControl();

        // Inicialização do loop
        if (forControl.variableDeclaration() != null)
        {
            Visit(forControl.variableDeclaration());
        }
        else if (forControl.expression(0) != null)
        {
            Visit(forControl.expression(0));
        }

        while (true)
        {
            // Avalia a condição do loop
            if (forControl.expression(1) != null)
            {
                string conditionText = forControl.expression(1).GetText();
                bool condition = EvaluateCondition(conditionText);
                if (!condition) break;
            }

            // Executa o corpo do loop
            Visit(context.statement());

            // Incremento (tratamento especial para `j++`)
            if (forControl.expression(2) != null)
            {
                string incrementText = forControl.expression(2).GetText();
                if (Regex.IsMatch(incrementText, @"^\w+\+\+$"))
                {
                    string varName = incrementText.Replace("++", "").Trim();
                    if (memory.ContainsKey(varName))
                    {
                        if (memory[varName] is int intValue)
                        {
                            memory[varName] = intValue + 1; // Incrementa a variável
                        }
                        else
                        {
                            Console.WriteLine($"Erro: variável '{varName}' não é um inteiro.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Erro: variável '{varName}' não encontrada.");
                    }
                }
                else
                {
                    Visit(forControl.expression(2));
                }
            }
        }

        return null;
    }



    // -------------------- FUNÇÕES --------------------
    public override object VisitFunctionDeclaration(CParser.FunctionDeclarationContext context)
    {
        string functionName = context.IDENTIFIER().GetText(); // Nome da função
        string returnType = context.type()?.GetText() ?? "void"; // Evita null no tipo de retorno
        Console.WriteLine($"Função declarada: {returnType} {functionName}");

        // Armazena a função no dicionário para chamadas futuras
        functions[functionName] = context;

        return null!;
    }

    public override object VisitFunctionCallStatement(CParser.FunctionCallStatementContext context)
    {
        string functionName = context.IDENTIFIER().GetText(); // Nome da função chamada

        Console.WriteLine($"Tentando chamar a função: {functionName}");

        // Verifica se a função foi declarada
        if (!functions.ContainsKey(functionName))
        {
            Console.WriteLine($"Erro: Função '{functionName}' não foi declarada.");
            return null!;
        }

        Console.WriteLine($"Chamando função: {functionName}");

        // Obtém o contexto da função armazenado
        var functionContext = functions[functionName];
        string returnType = functionContext.type()?.GetText() ?? "void"; // Evita null no tipo de retorno

        // *Captura os argumentos passados para a função*
        List<object> argumentos = new List<object>();

        if (context.expression() != null)
        {
            foreach (var expr in context.expression())
            {
                object? valor = Visit(expr);
                if (valor == null)
                {
                    Console.WriteLine($"Erro: Argumento de {functionName} retornou null.");
                    return null!;
                }
                argumentos.Add(valor);
            }
        }

        // *Executa o corpo da função e captura o retorno*
        object? returnValue = Visit(functionContext.block());

        if (returnType != "void")
        {
            Console.WriteLine($"Função '{functionName}' retornou: {returnValue}");
            return returnValue ?? 0; // Substitui null por 0
        }

        return null!;
    }

    public override object VisitReturnStatement(CParser.ReturnStatementContext context)
    {
        if (context.expression() != null)
        {
            object returnValue = Visit(context.expression()); // Avalia a expressão do return
            
            return returnValue ?? 0;  // Retorna o valor corretamente para a função chamadora
        }

        return null!;
    }

    // -------------------- STRUCTS --------------------
    public override object VisitStructDeclaration(CParser.StructDeclarationContext context)
    {
        string structName = context.IDENTIFIER().GetText();
        var fields = new Dictionary<string, object>();

        foreach (var field in context.structMember())
        {
            string tipo = field.type().GetText();
            string varName = field.IDENTIFIER().GetText();
            fields[varName] = tipo == "int" ? 0 : ""; // Inicializa valores padrão
        }

        structs[structName] = fields;
        Console.WriteLine($"Struct declarada: {structName}");

        return null;
    }


    public override object VisitStructAssignment(CParser.StructAssignmentContext context)
    {
        string structVar = context.IDENTIFIER(0).GetText();  // "pessoa"
        string fieldName = context.IDENTIFIER(1).GetText();  // "codigo"
        int value = EvaluateExpression(context.expression().GetText());

        if (memory.ContainsKey(structVar) && memory[structVar] is Dictionary<string, object> structInstance)
        {
            structInstance[fieldName] = value;
            Console.WriteLine($"Atribuição: {structVar}.{fieldName} = {value}");
        }
        else
        {
            Console.WriteLine($"Erro: Variável '{structVar}' não é uma struct ou não existe.");
        }

        return null;
    }




    // -------------------- DIRETIVAS DE COMPILAÇÃO --------------------
    public override object VisitPreprocessorDirective(CParser.PreprocessorDirectiveContext context)
    {
        string directive = context.GetText();
        Console.WriteLine($"Processando diretiva de pré-processamento: {directive}");
        return null;
    }

    public override object VisitPrintfStatement(CParser.PrintfStatementContext context)
    {
        // Verifica se há uma string no printf
        if (context.STRING_LITERAL() == null)
        {
            Console.WriteLine("Erro: printf chamado sem string de formato.");
            return null;
        }

        string format = context.STRING_LITERAL().GetText().Trim('"');

        // Obtém os argumentos, se existirem
        var args = context.expression()?.Select(expr => EvaluateExpression(expr.GetText())).ToArray();

        // Substituir "%d" por valores reais das variáveis
        if (args != null)
        {
            foreach (var arg in args)
            {
                int index = format.IndexOf("%d");
                if (index != -1)
                {
                    format = format.Substring(0, index) + arg.ToString() + format.Substring(index + 2);
                }
            }
        }

        // Imprimir a saída do printf
        Console.WriteLine(format);
        return null;
    }

    public override object VisitSelectionStatement(CParser.SelectionStatementContext context)
    {
        string conditionText = context.expression().GetText();
        bool condition = EvaluateCondition(conditionText);

        if (condition)
        {
            Console.WriteLine("Executando bloco IF");
            return Visit(context.statement(0)); // Executa o bloco do IF
        }
        else if (context.statement().Length > 1)
        {
            Console.WriteLine("Executando bloco ELSE");
            return Visit(context.statement(1)); // Executa o bloco ELSE (se houver)
        }

        return null;
    }

    public override object VisitSwitchStatement(CParser.SwitchStatementContext context)
    {
        string switchExpression = context.expression().GetText();
        int switchValue = EvaluateExpression(switchExpression);

        bool caseMatched = false;

        foreach (var caseStatement in context.caseStatement())
        {
            string caseExpression = caseStatement.CONSTANT().GetText();
            int caseValue = EvaluateExpression(caseExpression);

            if (switchValue == caseValue)
            {
                Console.WriteLine($"Executando CASE {caseValue}");
                foreach (var statement in caseStatement.statement())
                {
                    Visit(statement);

                    // Verifica se há um break dentro do case
                    if (statement.GetText() == "break")
                    {
                        return null; // Sai do switch
                    }
                }

                caseMatched = true;
            }
        }

        if (!caseMatched && context.defaultStatement() != null)
        {
            Console.WriteLine("Executando DEFAULT");
            foreach (var statement in context.defaultStatement().statement())
            {
                Visit(statement);
            }
        }

        return null;
    }

    public override object VisitWhileStatement(CParser.WhileStatementContext context)
    {
        // Obtemos a condição do while
        string conditionText = context.expression().GetText();
        
        // Avaliamos a condição
        bool condition = EvaluateCondition(conditionText);
        Console.WriteLine($"Condição do while: {conditionText} => {condition}");

        // Enquanto a condição for verdadeira, executa o corpo do laço
        while (condition)
        {
            // Executa o corpo do while (o statement dentro do while)
            Visit(context.statement());

            // Agora, reavaliamos a condição para a próxima iteração
            condition = EvaluateCondition(conditionText);
            Console.WriteLine($"Condição do while após execução: {conditionText} => {condition}");

            // Atualizando o valor de i, caso tenha sido modificado dentro do while
            if (memory.ContainsKey("i"))
            {
                // Incrementa o valor de 'i' diretamente na memória
                int i = (int)memory["i"];
                memory["i"] = i + 1;  // Incrementa i
                Console.WriteLine($"Valor de i após incremento: {memory["i"]}");
            }
        }

        return null;
    }

    public override object VisitDoWhileStatement(CParser.DoWhileStatementContext context)
    {
        // Executa o corpo do loop pelo menos uma vez
        Console.WriteLine("Executando corpo do do-while...");
        Visit(context.statement());  // Executa o bloco de código dentro do 'do'

        // Incrementa a variável 'i' (se estiver sendo usada no corpo)
        if (memory.ContainsKey("i"))
        {
            memory["i"] = (int)memory["i"] + 1;  // Incrementa 'i'
            Console.WriteLine($"Valor de i após incremento: {memory["i"]}");
        }

        // Verifica a condição do 'while' após a execução
        string conditionText = context.expression().GetText();
        Console.WriteLine($"Condição do do-while antes da avaliação: {conditionText}");

        // Avalia a condição
        bool condition = EvaluateCondition(conditionText);  // Avalia a condição após o corpo

        // Se a condição for verdadeira, repete o loop
        Console.WriteLine($"Condição do do-while após execução: {conditionText} => {condition}");

        if (condition)
        {
            // Chama recursivamente para executar o loop novamente
            VisitDoWhileStatement(context);  
        }

        return null;
    }

    public override object VisitExpressionStatement(CParser.ExpressionStatementContext context)
    {
        string expr = context.expression().GetText().Trim();

        // Verifica se é um incremento `a++` ou `++a`
        if (Regex.IsMatch(expr, @"^\w+\+\+$") || Regex.IsMatch(expr, @"^\+\+\w+$"))
        {
            string varName = expr.Replace("++", "").Trim();
            if (memory.ContainsKey(varName))
            {
                if (memory[varName] is int intValue)
                {
                    memory[varName] = intValue + 1;  // Incrementa a variável corretamente
                }
                else
                {
                    Console.WriteLine($"Erro: variável '{varName}' não é um inteiro.");
                }
            }
            else
            {
                Console.WriteLine($"Erro: variável '{varName}' não encontrada.");
            }
            return null;
        }

        // Verifica se é um decremento `a--` ou `--a`
        if (Regex.IsMatch(expr, @"^\w+--$") || Regex.IsMatch(expr, @"^--\w+$"))
        {
            string varName = expr.Replace("--", "").Trim();
            if (memory.ContainsKey(varName))
            {
                if (memory[varName] is int intValue)
                {
                    memory[varName] = intValue - 1;  // Decrementa a variável corretamente
                }
                else
                {
                    Console.WriteLine($"Erro: variável '{varName}' não é um inteiro.");
                }
            }
            else
            {
                Console.WriteLine($"Erro: variável '{varName}' não encontrada.");
            }
            return null;
        }

        // Outros tratamentos para expressões podem ser adicionados aqui

        return base.VisitExpressionStatement(context);
    }

//gets puts

public override object VisitGetsStatement(CParser.GetsStatementContext context)
{
    string varName = context.IDENTIFIER().GetText();

    // Forçar saída do console antes de esperar a entrada
    Console.Out.Flush(); // Garante que o texto seja exibido antes da entrada

    string? input = Console.ReadLine(); // Aguarda entrada do usuário

    if (string.IsNullOrEmpty(input))
    {
        Console.WriteLine("Erro: Entrada inválida.");
        return null;
    }

    memory[varName] = input; // Armazena a entrada na memória da variável
    return null;
}

public override object VisitPutsStatement(CParser.PutsStatementContext context)
{
    string varName = context.IDENTIFIER().GetText();

    if (!memory.ContainsKey(varName))
    {
        Console.WriteLine($"Erro: Variável '{varName}' não foi declarada.");
        return null;
    }

    Console.WriteLine(memory[varName]);
    return null;
}

public override object VisitScanfStatement(CParser.ScanfStatementContext context)
{
    // Obtém os argumentos do scanf
    string format = context.STRING_LITERAL().GetText().Trim('"');

    var identifiers = context.IDENTIFIER(); // Lista de variáveis que receberão valores

    for (int i = 0; i < identifiers.Length; i++)
    {
        string varName = identifiers[i].GetText();
        Console.Out.Flush(); // Garante que a mensagem seja exibida antes da entrada

        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Erro: Entrada inválida.");
            return null;
        }

        // Determina o tipo esperado baseado no formato do scanf (%d, %f, %s, etc.)
        if (format.Contains("%d"))
        {
            if (int.TryParse(input, out int intValue))
            {
                memory[varName] = intValue;
            }
            else
            {
                Console.WriteLine($"Erro: '{input}' não é um número inteiro válido.");
                return null;
            }
        }
        else if (format.Contains("%f"))
        {
            if (float.TryParse(input, out float floatValue))
            {
                memory[varName] = floatValue;
            }
            else
            {
                Console.WriteLine($"Erro: '{input}' não é um número de ponto flutuante válido.");
                return null;
            }
        }
        else if (format.Contains("%s"))
        {
            memory[varName] = input;
        }
        else
        {
            Console.WriteLine($"Erro: Tipo de entrada não suportado no formato '{format}'.");
            return null;
        }
    }

    return null;
}


}