using System;
using System.Collections.Generic;

public class AtividadeDeListagem : Atividade
{
    private List<string> _listaAvisos = new List<string>()
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    private List<string> _avisosRestantes;
    private Random _geradorAleatorio = new Random();

    public AtividadeDeListagem() : base(
        "Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
        _avisosRestantes = new List<string>(_listaAvisos);
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        string avisoEscolhido = ObterAvisoSemRepeticao();

        Console.WriteLine("Liste o máximo de itens que conseguir para o seguinte tópico:");
        Console.WriteLine();
        Console.WriteLine($"  --- \"{avisoEscolhido}\" ---");
        Console.WriteLine();
        Console.Write("Você pode começar a listar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine();
        Console.WriteLine();

        List<string> itensListados = new List<string>();
        DateTime horarioFim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < horarioFim)
        {
            Console.Write("> ");
            string resposta = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                itensListados.Add(resposta.Trim());
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Parabéns! Você registrou um total de {itensListados.Count} item(ns) positivo(s)!");

        ExibirMensagemFinal();
    }

    private string ObterAvisoSemRepeticao()
    {
        if (_avisosRestantes.Count == 0)
        {
            _avisosRestantes = new List<string>(_listaAvisos);
        }

        int indice = _geradorAleatorio.Next(_avisosRestantes.Count);
        string aviso = _avisosRestantes[indice];
        _avisosRestantes.RemoveAt(indice);
        return aviso;
    }
}
