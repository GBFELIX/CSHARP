using System;
using System.Collections.Generic;

class Program 
{
    static void Main() 
    {
        List<Pessoa> pessoas = new List<Pessoa>();
        Console.WriteLine("Quantas pessoas deseja cadastrar?");
        int quantidade = int.Parse(Console.ReadLine());

        for(int i = 0; i < quantidade; i++){

        Pessoa pessoa = new Pessoa();  
        Console.WriteLine($"\nCadastro da pessoa {i + 1}");
        Console.Write("Digite o nome: ");
        pessoa.Nome = Console.ReadLine();
        
        Console.Write("Digite a idade: ");
        pessoa.Idade = int.Parse(Console.ReadLine());

        pessoas.Add(pessoa);
        }
        Console.WriteLine("\n📋 Lista de Pessoas Cadastradas:"); 
        foreach(Pessoa p in pessoas){
            if(p.EhMaiorDeIdade()){
                Console.WriteLine($"{p.Nome} é maior de idade.");
            }
    
        }
    }
}
