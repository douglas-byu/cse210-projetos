using System;
using System.Collections.Generic;
using System.IO;

public class RegistroSessoes
{
    private string _caminhoArquivo;
    private Dictionary<string, int> _contagemAtividades;
    private Dictionary<string, int> _tempoTotalAtividades;

    public RegistroSessoes(string nomeArquivo = "historico_sessoes.txt")
    {
        _caminhoArquivo = nomeArquivo;
        _contagemAtividades = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        _tempoTotalAtividades = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        CarregarHistorico();
    }

    public void RegistrarSessao(string nomeAtividade, int duracaoSegundos)
    {
        if (string.IsNullOrWhiteSpace(nomeAtividade) || duracaoSegundos <= 0)
        {
            return;
        }

        if (!_contagemAtividades.ContainsKey(nomeAtividade))
        {
            _contagemAtividades[nomeAtividade] = 0;
            _tempoTotalAtividades[nomeAtividade] = 0;
        }

        _contagemAtividades[nomeAtividade]++;
        _tempoTotalAtividades[nomeAtividade] += duracaoSegundos;

        SalvarEntradaArquivo(nomeAtividade, duracaoSegundos);
    }

    private void SalvarEntradaArquivo(string nomeAtividade, int duracaoSegundos)
    {
        try
        {
            string linha = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}|{nomeAtividade}|{duracaoSegundos}";
            File.AppendAllLines(_caminhoArquivo, new[] { linha });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Aviso] Não foi possível gravar o histórico: {ex.Message}");
        }
    }

    private void CarregarHistorico()
    {
        if (!File.Exists(_caminhoArquivo))
        {
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(_caminhoArquivo);
            foreach (string linha in linhas)
            {
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split('|');
                if (partes.Length >= 3)
                {
                    string nome = partes[1].Trim();
                    if (int.TryParse(partes[2].Trim(), out int duracao))
                    {
                        if (!_contagemAtividades.ContainsKey(nome))
                        {
                            _contagemAtividades[nome] = 0;
                            _tempoTotalAtividades[nome] = 0;
                        }
                        _contagemAtividades[nome]++;
                        _tempoTotalAtividades[nome] += duracao;
                    }
                }
            }
        }
        catch
        {
            // Se houver falha na leitura, o histórico começa zerado em memória
        }
    }

    public void ExibirResumo()
    {
        Console.Clear();
        Console.WriteLine("========================================================");
        Console.WriteLine("        HISTÓRICO E ESTATÍSTICAS DE INTROSPECÇÃO        ");
        Console.WriteLine("========================================================");
        Console.WriteLine();

        if (_contagemAtividades.Count == 0)
        {
            Console.WriteLine("Nenhuma atividade foi realizada ainda nesta sessão.");
            Console.WriteLine("Dedique alguns minutos para cuidar da sua mente hoje!");
        }
        else
        {
            Console.WriteLine(string.Format("{0,-35} | {1,-10} | {2,-12}", "Atividade", "Sessões", "Tempo Total"));
            Console.WriteLine(new string('-', 64));

            int totalGeralSessoes = 0;
            int totalGeralSegundos = 0;

            foreach (var par in _contagemAtividades)
            {
                string nome = par.Key;
                int sessoes = par.Value;
                int segundos = _tempoTotalAtividades[nome];

                totalGeralSessoes += sessoes;
                totalGeralSegundos += segundos;

                Console.WriteLine(string.Format("{0,-35} | {1,-10} | {2,8} s", nome, sessoes, segundos));
            }

            Console.WriteLine(new string('-', 64));
            Console.WriteLine(string.Format("{0,-35} | {1,-10} | {2,8} s", "TOTAL GERAL", totalGeralSessoes, totalGeralSegundos));
        }

        Console.WriteLine();
        Console.WriteLine($"Arquivo de log: {Path.GetFullPath(_caminhoArquivo)}");
        Console.WriteLine();
        Console.Write("Pressione ENTER para voltar ao menu principal...");
        Console.ReadLine();
    }
}
