// Classe responsável por armazenar e sortear perguntas aleatórias para o diário.
// Encapsula a lista de prompts e a lógica de seleção aleatória.

using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // ── Lista privada de perguntas ─────────────────────────────────────────
    private List<string> _prompts = new List<string>()
    {
        "Quem foi a pessoa mais interessante com quem interagi hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como vi a mão do Senhor em minha vida hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "Se eu pudesse fazer uma coisa hoje, o que seria?",
        "O que aprendi de novo hoje?",
        "Pelo que sou grato hoje?",
        "Qual foi o maior desafio que enfrentei hoje e como lidei com ele?",
        "O que eu poderia ter feito melhor hoje?",
        "Que momento de hoje eu gostaria de guardar para sempre?",
        "Como estou me sentindo fisicamente e emocionalmente agora?",
        "Qual foi a coisa mais engraçada que aconteceu hoje?"
    };

    private Random _random = new Random();

    // ── Retorna uma pergunta aleatória da lista ────────────────────────────
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
