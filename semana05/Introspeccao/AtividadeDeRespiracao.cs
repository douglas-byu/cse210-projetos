using System;

public class AtividadeDeRespiracao : Atividade
{
    public AtividadeDeRespiracao() : base(
        "Atividade de Respiração",
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        DateTime fim = DateTime.Now.AddSeconds(_duracao);

        while (DateTime.Now < fim)
        {
            Console.Write("Inspire... ");
            ExibirContagemRegressiva(4);
            Console.WriteLine();

            Console.Write("Expire... ");
            ExibirContagemRegressiva(6);
            Console.WriteLine();
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}
