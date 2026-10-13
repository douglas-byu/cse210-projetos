using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Atividade
{
    private string _nome;
    private string _descricao;
    protected int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
        _duracao = 0;
    }

    public string Nome => _nome;
    public int Duracao => _duracao;

    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"=== {_nome.ToUpper()} ===");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();

        _duracao = SolicitarDuracaoSessao();

        Console.Clear();
        Console.WriteLine("Prepare-se para iniciar a atividade...");
        ExibirAnimacaoSpinner(4);
        Console.WriteLine();
    }

    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Bom trabalho! Você concluiu este exercício.");
        ExibirAnimacaoSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"Você dedicou {_duracao} segundos à {_nome}.");
        ExibirAnimacaoSpinner(4);
    }

    public void ExibirAnimacaoSpinner(int segundos)
    {
        List<string> quadros = new List<string>() { "|", "/", "-", "\\" };
        DateTime horarioLimite = DateTime.Now.AddSeconds(segundos);
        int indice = 0;

        while (DateTime.Now < horarioLimite)
        {
            string simbolo = quadros[indice];
            Console.Write(simbolo);
            Thread.Sleep(250);
            Console.Write("\b \b");

            indice = (indice + 1) % quadros.Count;
        }
    }

    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);

            // Se for número com 2 dígitos, apaga 2 caracteres
            string tamanho = i.ToString();
            string backspaces = new string('\b', tamanho.Length);
            string espacos = new string(' ', tamanho.Length);
            Console.Write($"{backspaces}{espacos}{backspaces}");
        }
    }

    private int SolicitarDuracaoSessao()
    {
        while (true)
        {
            Console.Write("Por quantos segundos você deseja realizar esta atividade? ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int segundos) && segundos > 0)
            {
                return segundos;
            }

            Console.WriteLine("Por favor, informe um número inteiro positivo válido em segundos.");
        }
    }

    public abstract void Executar();
}
