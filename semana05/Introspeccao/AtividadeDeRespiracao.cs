using System;
using System.Threading;

public class AtividadeDeRespiracao : Atividade
{
    private const int SegundosInspiracao = 4;
    private const int SegundosExpiracao = 6;

    public AtividadeDeRespiracao() : base(
        "Atividade de Respiração",
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public override void Executar()
    {
        ExibirMensagemInicial();

        DateTime horarioFim = DateTime.Now.AddSeconds(_duracao);

        Console.WriteLine("Siga o ritmo da respiração abaixo:");
        Console.WriteLine();

        while (DateTime.Now < horarioFim)
        {
            // Fase de Inspiração
            ExecutarFaseRespiracao("Inspire suavemente...", SegundosInspiracao, true);

            // Fase de Expiração
            ExecutarFaseRespiracao("Expire lentamente...", SegundosExpiracao, false);

            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }

    private void ExecutarFaseRespiracao(string mensagem, int segundos, bool inspirando)
    {
        Console.Write($"{mensagem} ");
        
        for (int i = segundos; i > 0; i--)
        {
            // Gera um indicador visual que cresce ao inspirar e encolhe ao expirar
            int proporcao = inspirando ? (segundos - i + 1) * 3 : i * 3;
            string barra = new string('=', Math.Max(1, proporcao));
            string indicador = $"[{barra}>] {i}s";

            Console.Write(indicador);
            Thread.Sleep(1000);

            // Apaga a linha do indicador para o próximo segundo
            string backspaces = new string('\b', indicador.Length);
            string espacos = new string(' ', indicador.Length);
            Console.Write($"{backspaces}{espacos}{backspaces}");
        }

        Console.WriteLine();
    }
}
