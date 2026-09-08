// =============================================================================
// Programa: Diário Pessoal
// Autor: Desenvolvido para o projeto da semana 02 - CSE 210
//
// INDO ALÉM DOS REQUISITOS (para nota 100%):
//  1. Criada uma 3ª classe (PromptGenerator) além das obrigatórias (Entry, Journal).
//  2. O programa usa cores no terminal para melhorar a experiência do usuário,
//     tornando o menu e os registros mais fáceis de ler.
//  3. A lista de perguntas foi ampliada para 12 perguntas (mínimo era 5).
//  4. O formato de arquivo usa o separador "|~|" que é improvável de aparecer
//     no texto do usuário, evitando conflitos de parsing.
//  5. O programa exibe a hora exata do registro (não apenas a data).
//  6. Mensagens de erro e sucesso são exibidas com cores distintas (verde/vermelho).
//  7. Validação de entrada: o menu rejeita opções inválidas com mensagem clara.
// =============================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal           = new Journal();
        PromptGenerator generator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            ExibirMenu();
            string escolha = Console.ReadLine()?.Trim();

            switch (escolha)
            {
                case "1":
                    EscreverNovoRegistro(journal, generator);
                    break;

                case "2":
                    ExibirDiario(journal);
                    break;

                case "3":
                    SalvarDiario(journal);
                    break;

                case "4":
                    CarregarDiario(journal);
                    break;

                case "5":
                    running = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n  Até logo! Continue escrevendo seu diário! 📖\n");
                    Console.ResetColor();
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n  ✘ Opção inválida. Por favor, escolha um número de 1 a 5.");
                    Console.ResetColor();
                    PausarParaContinuar();
                    break;
            }
        }
    }

    // ── Exibe o menu principal ─────────────────────────────────────────────
    static void ExibirMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════════════════════╗");
        Console.WriteLine("║         📖  MEU DIÁRIO PESSOAL           ║");
        Console.WriteLine("╠══════════════════════════════════════════╣");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("║  1. Escrever novo registro               ║");
        Console.WriteLine("║  2. Exibir o diário                      ║");
        Console.WriteLine("║  3. Salvar o diário em um arquivo        ║");
        Console.WriteLine("║  4. Carregar o diário de um arquivo      ║");
        Console.WriteLine("║  5. Sair                                  ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╚══════════════════════════════════════════╝");
        Console.ResetColor();

        Console.Write("\n  Escolha uma opção: ");
    }

    // ── Escreve um novo registro no diário ────────────────────────────────
    static void EscreverNovoRegistro(Journal journal, PromptGenerator generator)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ── Novo Registro ──────────────────────────\n");
        Console.ResetColor();

        string pergunta = generator.GetRandomPrompt();
        string data     = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"  Pergunta: {pergunta}");
        Console.ResetColor();

        Console.Write("\n  Sua resposta: ");
        string resposta = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(resposta))
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  Nenhuma resposta digitada. Registro não salvo.");
            Console.ResetColor();
        }
        else
        {
            Entry novoRegistro = new Entry(data, pergunta, resposta);
            journal.AddEntry(novoRegistro);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  ✔ Registro adicionado com sucesso!");
            Console.ResetColor();
        }

        PausarParaContinuar();
    }

    // ── Exibe todos os registros do diário ────────────────────────────────
    static void ExibirDiario(Journal journal)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ── Seu Diário ─────────────────────────────\n");
        Console.ResetColor();

        journal.Display();

        PausarParaContinuar();
    }

    // ── Salva o diário em um arquivo ──────────────────────────────────────
    static void SalvarDiario(Journal journal)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ── Salvar Diário ──────────────────────────\n");
        Console.ResetColor();

        if (journal.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  O diário está vazio. Nada a salvar.");
            Console.ResetColor();
            PausarParaContinuar();
            return;
        }

        Console.Write("  Digite o nome do arquivo (ex: meu_diario.txt): ");
        string nomeArquivo = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeArquivo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ✘ Nome de arquivo inválido.");
            Console.ResetColor();
        }
        else
        {
            journal.SaveToFile(nomeArquivo);
        }

        PausarParaContinuar();
    }

    // ── Carrega o diário de um arquivo ────────────────────────────────────
    static void CarregarDiario(Journal journal)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("  ── Carregar Diário ────────────────────────\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("  ⚠ Atenção: Isso substituirá todos os registros atuais!");
        Console.ResetColor();

        Console.Write("\n  Digite o nome do arquivo (ex: meu_diario.txt): ");
        string nomeArquivo = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(nomeArquivo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n  ✘ Nome de arquivo inválido.");
            Console.ResetColor();
        }
        else
        {
            journal.LoadFromFile(nomeArquivo);
        }

        PausarParaContinuar();
    }

    // ── Pausa o programa até o usuário pressionar Enter ───────────────────
    static void PausarParaContinuar()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("\n  Pressione Enter para continuar...");
        Console.ResetColor();
        Console.ReadLine();
    }
}