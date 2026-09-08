// Classe que representa um único registro (entrada) do diário.
// Contém a data, a pergunta exibida e a resposta do usuário.
// Demonstra abstração com variáveis membro privadas e propriedades públicas.

using System;

public class Entry
{
    // ── Variáveis membro privadas ──────────────────────────────────────────
    private string _date;
    private string _promptQuestion;
    private string _response;

    // ── Propriedades públicas (encapsulamento) ─────────────────────────────
    public string Date           => _date;
    public string PromptQuestion => _promptQuestion;
    public string Response       => _response;

    // ── Construtor ─────────────────────────────────────────────────────────
    public Entry(string date, string promptQuestion, string response)
    {
        _date           = date;
        _promptQuestion = promptQuestion;
        _response       = response;
    }

    // ── Exibe o registro formatado no console ──────────────────────────────
    public void Display()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"  Data: {_date}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"  Pergunta: ");
        Console.ResetColor();
        Console.WriteLine(_promptQuestion);

        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"  Resposta: ");
        Console.ResetColor();
        Console.WriteLine(_response);
    }

    // ── Serializa o registro para uma linha no arquivo ─────────────────────
    // Formato: data|~|pergunta|~|resposta
    public string ToFileString()
    {
        return $"{_date}|~|{_promptQuestion}|~|{_response}";
    }

    // ── Cria um Entry a partir de uma linha do arquivo ─────────────────────
    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("|~|");
        if (parts.Length != 3)
            throw new FormatException($"Linha inválida no arquivo: {line}");

        return new Entry(parts[0], parts[1], parts[2]);
    }
}
