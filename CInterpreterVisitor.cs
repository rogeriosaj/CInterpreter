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
        expr = expr.Trim();

        // Substituir todas as variáveis armazenadas por seus valores numéricos
        foreach (var variable in memory.Keys)
        {
            if (expr.Contains(variable))
            {
                expr = expr.Replace(variable, memory[variable].ToString());
            }
        }

        try
        {
            DataTable table = new DataTable();
            object result = table.Compute(expr, ""); // Agora pode avaliar corretamente "5+10"
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
        expr = expr.Trim();

        // Impede substituição de números por variáveis
        foreach (var variable in memory.Keys.OrderByDescending(k => k.Length))
        {
            if (Regex.IsMatch(expr, $@"\b{variable}\b"))
            {
                expr = Regex.Replace(expr, $@"\b{variable}\b", memory[variable].ToString());
            }
        }

        try
        {
            return Convert.ToBoolean(new DataTable().Compute(expr, ""));
        }
        catch
        {
            Console.WriteLine($"Erro ao avaliar condição '{expr}': Expressão inválida.");
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
        string? functionName = context.IDENTIFIER()?.GetText(); // Pode ser NULL!
        if (functionName != null)
        {
            Console.WriteLine($"Função declarada: {functionName}");
            functions[functionName] = context;
        }
        else
        {
            Console.WriteLine("Erro: Nome da função é nulo.");
        }
        return null;
    }

    public override object VisitFunctionCallStatement(CParser.FunctionCallStatementContext context)
    {
        string functionName = context.IDENTIFIER().GetText();
        Console.WriteLine($"Chamando função: {functionName}");
        return VisitChildren(context);
    }


    public override object VisitReturnStatement(CParser.ReturnStatementContext context)
    {
        string returnValue = context.expression()?.GetText();
        if (returnValue != null)
        {
            Console.WriteLine($"Retornando: {EvaluateExpression(returnValue)}");
            return EvaluateExpression(returnValue);
        }
        return null;
    }

    // -------------------- STRUCTS --------------------
    public override object VisitStructDeclaration(CParser.StructDeclarationContext context)
    {
        string structName = context.IDENTIFIER().GetText();
        Console.WriteLine($"Struct declarada: {structName}");
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

    

}
