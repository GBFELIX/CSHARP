using System;

class Pessoa{
    public string Nome;
    public int Idade;

    public void Apresentar(){
        Console.WriteLine($"Nome: {Nome} | Idade: {Idade}");
    }
    public bool EhMaiorDeIdade(){
        return Idade > 18;
    }
}