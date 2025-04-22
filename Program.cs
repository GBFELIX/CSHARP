using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Pessoa> pessoas = new List<Pessoa>();
    static string caminhoArquivo = "pessoas.txt";

    static void Main()
    {
        CarregarPessoasDoArquivo();

        int opcao;
        do
        {
            MostrarMenu();
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarPessoa();
                    break;
                case 2:
                    ListarPessoas();
                    break;
                case 3:
                    MostrarMaioresDeIdade();
                    break;
                case 0:
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine("=== MENU ===");
        Console.WriteLine("1 - Cadastrar Pessoa");
        Console.WriteLine("2 - Listar Pessoas");
        Console.WriteLine("3 - Mostrar Maiores de Idade");
        Console.WriteLine("0 - Sair");
        Console.Write("Escolha uma opção: ");
    }

    static void CadastrarPessoa()
    {
        Pessoa pessoa = new Pessoa();

        Console.Write("Digite o nome: ");
        pessoa.Nome = Console.ReadLine();

        Console.Write("Digite a idade: ");
        pessoa.Idade = int.Parse(Console.ReadLine());

        pessoas.Add(pessoa);
        SalvarPessoaNoArquivo(pessoa);

        Console.WriteLine("Pessoa cadastrada com sucesso!");
    }

    static void ListarPessoas()
    {
        if (pessoas.Count == 0)
        {
            Console.WriteLine("Nenhuma pessoa cadastrada.");
            return;
        }

        Console.WriteLine("📋 Lista de Pessoas:");
        foreach (Pessoa p in pessoas)
        {
            p.Apresentar();
        }
    }

    static void MostrarMaioresDeIdade()
    {
        Console.WriteLine("🔍 Maiores de Idade:");
        foreach (Pessoa p in pessoas)
        {
            if (p.EhMaiorDeIdade())
            {
                Console.WriteLine($"{p.Nome} é maior de idade.");
            }
        }
    }

    static void SalvarPessoaNoArquivo(Pessoa pessoa)
    {
        using (StreamWriter sw = File.AppendText(caminhoArquivo))
        {
            sw.WriteLine(pessoa.ParaTexto());
        }
    }

    static void CarregarPessoasDoArquivo()
    {
        if (!File.Exists(caminhoArquivo))
            return;

        string[] linhas = File.ReadAllLines(caminhoArquivo);
        foreach (string linha in linhas)
        {
            Pessoa pessoa = Pessoa.DeTexto(linha);
            pessoas.Add(pessoa);
        }
    }
}