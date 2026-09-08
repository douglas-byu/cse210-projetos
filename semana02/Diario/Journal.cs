// Classe que gerencia a lista completa de registros (entries) do diário.
// Responsável por adicionar, exibir, salvar e carregar entradas.
// Demonstra abstração: os detalhes de leitura/escrita ficam encapsulados aqui.

using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // ── Variáveis membro privadas ──────────────────────────────────────────
    private List<Entry> _entries = new List<Entry>();

    // ── Propriedade pública somente leitura ────────────────────────────────
    public int Count => _entries.Count;

    // ── Adiciona um novo registro ao diário ────────────────────────────────
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // ── Exibe todos os registros na tela ───────────────────────────────────
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Nenhum registro encontrado no diário.");
            Console.ResetColor();
            return;
        }

        int index = 1;
        foreach (Entry entry in _entries)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"\n  ══ Registro #{index} ══════════════════════");
            Console.ResetColor();
            entry.Display();
            index++;
        }

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"  ══════════════════════════════════════════");
        Console.ResetColor();
    }

    // ── Salva todos os registros em um arquivo de texto ────────────────────
    public void SaveToFile(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileString());
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✔ Diário salvo com sucesso em: {fileName}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ✘ Erro ao salvar: {ex.Message}");
            Console.ResetColor();
        }
    }

    // ── Carrega os registros de um arquivo de texto ────────────────────────
    // Substitui todos os registros atuais pelos do arquivo.
    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ✘ Arquivo não encontrado: {fileName}");
            Console.ResetColor();
            return;
        }

        try
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Entry entry = Entry.FromFileString(line);
                    _entries.Add(entry);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n  ✔ Diário carregado com sucesso! ({_entries.Count} registros encontrados)");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n  ✘ Erro ao carregar: {ex.Message}");
            Console.ResetColor();
        }
    }
}
