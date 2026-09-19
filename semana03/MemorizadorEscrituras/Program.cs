using System;

/*
 * =====================================================================================
 * PROJETO: PROGRAMA DE MEMORIZAÇÃO DE ESCRITURAS (Semana 03 - CSE 210)
 * =====================================================================================
 * 
 * CRIATIVIDADE E SUPERAÇÃO DOS REQUISITOS (PARA NOTA 100%):
 * - Ocultação inteligente de palavras:
 *   O método Escritura.EsconderPalavrasAleatorias seleciona aleatoriamente APENAS entre
 *   as palavras que ainda NÃO foram escondidas. Isso garante que, a cada pressão da tecla
 *   Enter, novas palavras sejam ocultadas progressivamente, evitando selecionar palavras
 *   que já estavam escondidas.
 * =====================================================================================
 */

class Program
{
    static void Main(string[] args)
    {
        // Escritura para memorização (utilizando construtor para intervalo de versículos)
        Referencia referencia = new Referencia("Provérbios", 3, 5, 6);
        string texto = "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas.";
        Escritura escritura = new Escritura(referencia, texto);

        // Loop principal do programa de memorização
        while (true)
        {
            LimparTela();
            Console.WriteLine(escritura.ObterTexto());
            Console.WriteLine();

            // Se todas as palavras estiverem escondidas, encerra o programa
            if (escritura.EstaCompletamenteEscondida())
            {
                break;
            }

            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar:");
            string entrada = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (entrada == "sair")
            {
                break;
            }

            // Oculta 3 palavras por vez (apenas dentre as que ainda não estão escondidas)
            escritura.EsconderPalavrasAleatorias(3);
        }
    }

    private static void LimparTela()
    {
        try
        {
            Console.Clear();
        }
        catch (Exception)
        {
            // Evita exceção caso esteja em ambiente sem buffer de console (ex: testes automatizados)
        }
    }
}