using System;

class Pessoa{
    public string Nome;
    public int Idade;

    public void Apresentar(){
        Console.WriteLine($"Nome: {Nome} | Idade: {Idade}");
    }
    public bool EhMaiorDeIdade(){
        return Idade >= 18;
    }
    public string ParaTexto(){
        return $"{Nome}|{Idade}";
    }
    public static Pessoa DeTexto(string linha){
        var partes = linha.Split('|');
        return new Pessoa
        {
            Nome = partes[0],
            Idade = int.Parse(partes[1])
        };
    }
}

