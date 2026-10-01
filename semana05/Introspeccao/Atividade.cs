using System;
using System.Collections.Generic;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    protected int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();
        Console.Write("Quanto tempo, em segundos, você gostaria para sua sessão? ");
        _duracao = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ExibirAnimacao(3);
        Console.WriteLine();
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Bom trabalho!");
        ExibirAnimacao(3);
        Console.WriteLine();
        Console.WriteLine($"Você concluiu mais {_duracao} segundos da {_nome}.");
        ExibirAnimacao(3);
    }

    public void ExibirAnimacao(int segundos)
    {
        List<string> animacao = new List<string>() { "|", "/", "-", "\\" };
        DateTime fim = DateTime.Now.AddSeconds(segundos);
        int i = 0;

        while (DateTime.Now < fim)
        {
            string s = animacao[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animacao.Count)
            {
                i = 0;
            }
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
