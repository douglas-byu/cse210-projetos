using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeObjetivos
{
    private List<Objetivo> _objetivos;
    private int _pontuacaoTotal;

    public GerenciadorDeObjetivos()
    {
        _objetivos = new List<Objetivo>();
        _pontuacaoTotal = 0;
    }

    public void Executar()
    {
        int escolha = 0;

        while (escolha != 6)
        {
            Console.WriteLine($"\nPontuação Atual: {_pontuacaoTotal} pontos\n");

            Console.WriteLine("Menu:");
            Console.WriteLine("  1. Criar Objetivo");
            Console.WriteLine("  2. Visualizar Objetivos");
            Console.WriteLine("  3. Salvar em Arquivo");
            Console.WriteLine("  4. Carregar de Arquivo");
            Console.WriteLine("  5. Registrar Cumprimento");
            Console.WriteLine("  6. Sair");
            Console.Write("Digite a opção desejada: ");

            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out escolha))
            {
                switch (escolha)
                {
                    case 1:
                        CriarNovoObjetivo();
                        break;
                    case 2:
                        ExibirListaDeObjetivos();
                        break;
                    case 3:
                        SalvarDados();
                        break;
                    case 4:
                        CarregarDados();
                        break;
                    case 5:
                        RegistrarCumprimento();
                        break;
                    case 6:
                        Console.WriteLine("Até logo!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }

    private void CriarNovoObjetivo()
    {
        Console.WriteLine("\nTipos disponíveis:");
        Console.WriteLine("  1. Objetivo Simples");
        Console.WriteLine("  2. Objetivo Recorrente");
        Console.WriteLine("  3. Objetivo Contador");
        Console.Write("Selecione o tipo: ");
        string opcaoTipo = Console.ReadLine();

        Console.Write("Informe o título: ");
        string titulo = Console.ReadLine();

        Console.Write("Informe a descrição: ");
        string descricao = Console.ReadLine();

        Console.Write("Informe o valor em pontos: ");
        int pontos = int.Parse(Console.ReadLine());

        if (opcaoTipo == "1")
        {
            _objetivos.Add(new ObjetivoSimples(titulo, descricao, pontos));
        }
        else if (opcaoTipo == "2")
        {
            _objetivos.Add(new ObjetivoRecorrente(titulo, descricao, pontos));
        }
        else if (opcaoTipo == "3")
        {
            Console.Write("Quantas repetições são necessárias para completar? ");
            int alvo = int.Parse(Console.ReadLine());

            Console.Write("Quantos pontos de bônus ao finalizar? ");
            int bonus = int.Parse(Console.ReadLine());

            _objetivos.Add(new ObjetivoContador(titulo, descricao, pontos, alvo, bonus));
        }
    }

    private void ExibirListaDeObjetivos()
    {
        Console.WriteLine("\nSeus Objetivos:");
        if (_objetivos.Count == 0)
        {
            Console.WriteLine("Nenhum objetivo registrado.");
            return;
        }

        for (int i = 0; i < _objetivos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_objetivos[i].FormatarExibicao()}");
        }
    }

    private void RegistrarCumprimento()
    {
        if (_objetivos.Count == 0)
        {
            Console.WriteLine("\nNão existem objetivos para registrar.");
            return;
        }

        Console.WriteLine("\nSelecione o objetivo realizado:");
        for (int i = 0; i < _objetivos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_objetivos[i].GetTitulo()}");
        }

        Console.Write("Número do objetivo: ");
        if (int.TryParse(Console.ReadLine(), out int indice) && indice >= 1 && indice <= _objetivos.Count)
        {
            Objetivo item = _objetivos[indice - 1];

            if (item.FoiCumprido())
            {
                Console.WriteLine("Este objetivo já está finalizado.");
                return;
            }

            item.RegistrarProgresso();
            int ganho = item.GetPontos();

            if (item is ObjetivoContador contador && contador.FoiCumprido())
            {
                ganho += contador.GetPontosBonus();
                Console.WriteLine($"Bônus de {contador.GetPontosBonus()} pontos recebido!");
            }

            _pontuacaoTotal += ganho;
            Console.WriteLine($"Você ganhou {ganho} pontos!");
            Console.WriteLine($"Total atual: {_pontuacaoTotal} pontos.");
        }
        else
        {
            Console.WriteLine("Entrada inválida.");
        }
    }

    private void SalvarDados()
    {
        Console.Write("Digite o nome do arquivo para salvar (ex: dados.txt): ");
        string caminho = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(caminho))
        {
            writer.WriteLine(_pontuacaoTotal);
            foreach (Objetivo obj in _objetivos)
            {
                writer.WriteLine(obj.SalvarEmLinha());
            }
        }

        Console.WriteLine("Dados salvos com sucesso.");
    }

    private void CarregarDados()
    {
        Console.Write("Digite o nome do arquivo para carregar (ex: dados.txt): ");
        string caminho = Console.ReadLine();

        if (!File.Exists(caminho))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(caminho);
        if (linhas.Length > 0)
        {
            _pontuacaoTotal = int.Parse(linhas[0]);
            _objetivos.Clear();

            for (int i = 1; i < linhas.Length; i++)
            {
                string linha = linhas[i];
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split('|');
                string tipo = partes[0];

                if (tipo == "Simples")
                {
                    string titulo = partes[1];
                    string descricao = partes[2];
                    int pontos = int.Parse(partes[3]);
                    bool terminado = bool.Parse(partes[4]);

                    _objetivos.Add(new ObjetivoSimples(titulo, descricao, pontos, terminado));
                }
                else if (tipo == "Recorrente")
                {
                    string titulo = partes[1];
                    string descricao = partes[2];
                    int pontos = int.Parse(partes[3]);

                    _objetivos.Add(new ObjetivoRecorrente(titulo, descricao, pontos));
                }
                else if (tipo == "Contador")
                {
                    string titulo = partes[1];
                    string descricao = partes[2];
                    int pontos = int.Parse(partes[3]);
                    int alvo = int.Parse(partes[4]);
                    int bonus = int.Parse(partes[5]);
                    int execucoes = int.Parse(partes[6]);

                    _objetivos.Add(new ObjetivoContador(titulo, descricao, pontos, alvo, bonus, execucoes));
                }
            }

            Console.WriteLine("Dados carregados com sucesso.");
        }
    }
}
