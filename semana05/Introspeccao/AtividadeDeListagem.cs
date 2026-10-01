using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private List<string> _mensagens = new List<string>()
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private Random _random = new Random();

    public AtividadeDeListagem() : base(
        "Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        string mensagem = ObterMensagemAleatoria();
        Console.WriteLine("Liste o máximo de respostas que puder para o seguinte aviso:");
        Console.WriteLine($" --- {mensagem} --- ");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();

        int contador = 0;
        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write("> ");
            Console.ReadLine();
            contador++;
        }

        Console.WriteLine($"Você listou {contador} itens!");

        ExibirMensagemFinal();
    }

    private string ObterMensagemAleatoria()
    {
        int indice = _random.Next(_mensagens.Count);
        return _mensagens[indice];
    }
}
