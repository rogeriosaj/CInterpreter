using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: ferramenta.sh ./arquivo.c");
            return;
        }

        string filePath = args[0];
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Erro: Arquivo {filePath} não encontrado.");
            return;
        }

        try
        {
            // Ler o código-fonte do arquivo
            string code = File.ReadAllText(filePath);

            // Criar um CharStream a partir do código-fonte
            AntlrInputStream inputStream = new AntlrInputStream(code);

            // Criar o Lexer
            CLexer lexer = new CLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            // Criar o Parser
            CParser parser = new CParser(tokenStream);
            IParseTree tree = parser.program(); // Ponto de entrada

            // Criar e percorrer a árvore de sintaxe
            CInterpreterVisitor visitor = new CInterpreterVisitor();
            visitor.Visit(tree);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao processar o arquivo: {ex.Message}");
        }
    }
}
