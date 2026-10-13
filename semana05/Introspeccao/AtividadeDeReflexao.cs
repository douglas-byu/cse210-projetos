using System;
using System.Collections.Generic;

public class AtividadeDeReflexao : Atividade
{
    private List<string> _listaAvisos = new List<string>()
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _listaPerguntas = new List<string>()
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo por meio dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    private List<string> _avisosRestantes;
    private List<string> _perguntasRestantes;
    private Random _geradorAleatorio = new Random();

    public AtividadeDeReflexao() : base(
        "Atividade de Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
    {
        _avisosRestantes = new List<string>(_listaAvisos);
        _perguntasRestantes = new List<string>(_listaPerguntas);
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        string avisoEscolhido = ObterAvisoSemRepeticao();

        Console.WriteLine("Considere a seguinte reflexão:");
        Console.WriteLine();
        Console.WriteLine($"  --- \"{avisoEscolhido}\" ---");
        Console.WriteLine();
        Console.WriteLine("Quando tiver um momento em mente, pressione ENTER para continuar...");
        Console.ReadLine();

        Console.WriteLine("Agora reflita profundamente sobre cada uma das perguntas a seguir:");
        Console.Write("Você pode começar em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();

        DateTime horarioFim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < horarioFim)
        {
            string perguntaEscolhida = ObterPerguntaSemRepeticao();
            Console.WriteLine();
            Console.Write($"> {perguntaEscolhida} ");
            
            // Pausa de 5 segundos mostrando spinner enquanto o usuário reflete
            ExibirAnimacaoSpinner(5);
            Console.WriteLine();
        }

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

    private string ObterPerguntaSemRepeticao()
    {
        if (_perguntasRestantes.Count == 0)
        {
            _perguntasRestantes = new List<string>(_listaPerguntas);
        }

        int indice = _geradorAleatorio.Next(_perguntasRestantes.Count);
        string pergunta = _perguntasRestantes[indice];
        _perguntasRestantes.RemoveAt(indice);
        return pergunta;
    }
}
