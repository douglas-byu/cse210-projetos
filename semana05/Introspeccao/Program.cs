using System;

/*
========================================================================================
PROJETO: PROGRAMA DE INTROSPECÇÃO (MINDFULNESS PROGRAM) - SEMANA 05 (CSE 210)
----------------------------------------------------------------------------------------
DEMONSTRANDO CRIATIVIDADE E INDO ALÉM DOS REQUISITOS (SUPERANDO OS REQUISITOS PARA 100%):

1. SISTEMA DE HISTÓRICO E ESTATÍSTICAS PERSISTENTES (RegistroSessoes.cs):
   - O programa monitora a quantidade de vezes que cada atividade foi concluída e o tempo
     total acumulado em segundos.
   - Os dados são salvos e atualizados em um arquivo de log local ("historico_sessoes.txt"),
     permitindo que o histórico permaneça mesmo após fechar e reabrir o programa.
   - Foi adicionada uma opção no menu ("Visualizar Estatísticas e Histórico de Sessões")
     para exibir um relatório detalhado e formatado em tabela.

2. SELEÇÃO ALEATÓRIA SEM REPETIÇÃO (SISTEMA DE EMBARALHAMENTO POR CICLO):
   - Tanto na Atividade de Reflexão (avisos e perguntas reflexivas) quanto na Atividade
     de Listagem (tópicos), nenhum item é sorteado repetidamente até que todas as opções
     disponíveis da lista tenham sido apresentadas pelo menos uma vez no ciclo atual.

3. ANIMAÇÃO VISUAL DINÂMICA DE RESPIRAÇÃO (AtividadeDeRespiracao.cs):
   - Na Atividade de Respiração, além da contagem regressiva em segundos, foi implementada
     uma barra visual de expansão e contração pulmonar progressiva ("Inspire... [=====>] 4s"),
     proporcionando uma experiência relaxante, estética e envolvente.

4. NOVA ATIVIDADE EXTRA DE INTROSPECÇÃO: ANCORAGEM SENSORIAL 5-4-3-2-1 (AtividadeDeAncoragem.cs):
   - Adicionada uma quarta atividade com a técnica terapêutica de grounding ("Aterramento
     5-4-3-2-1"), que guia o usuário através dos 5 sentidos humanos (visão, tato, audição,
     olfato e gratidão/paladar) para foco no momento presente e alívio de estresse.

5. TRATAMENTO ROBUSTO DE ENTRADAS:
   - Validação com int.TryParse para evitar que entradas inválidas (textos ou números negativos)
     provoquem exceções, garantindo estabilidade e boa usabilidade.
========================================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        RegistroSessoes registro = new RegistroSessoes("historico_sessoes.txt");
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("        PROGRAMA DE INTROSPECÇÃO E BEM-ESTAR     ");
            Console.WriteLine("=================================================");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("  1. Iniciar Atividade de Respiração");
            Console.WriteLine("  2. Iniciar Atividade de Reflexão");
            Console.WriteLine("  3. Iniciar Atividade de Listagem");
            Console.WriteLine("  4. Iniciar Atividade de Ancoragem Sensorial (5-4-3-2-1) [Extra]");
            Console.WriteLine("  5. Visualizar Estatísticas e Histórico de Sessões [Extra]");
            Console.WriteLine("  6. Sair");
            Console.WriteLine("=================================================");
            Console.Write("Digite o número da opção desejada: ");

            string opcao = Console.ReadLine()?.Trim();

            Atividade atividadeAtual = null;

            switch (opcao)
            {
                case "1":
                    atividadeAtual = new AtividadeDeRespiracao();
                    break;

                case "2":
                    atividadeAtual = new AtividadeDeReflexao();
                    break;

                case "3":
                    atividadeAtual = new AtividadeDeListagem();
                    break;

                case "4":
                    atividadeAtual = new AtividadeDeAncoragem();
                    break;

                case "5":
                    registro.ExibirResumo();
                    continue;

                case "6":
                    continuar = false;
                    Console.WriteLine();
                    Console.WriteLine("Obrigado por dedicar este tempo a si mesmo(a). Tenha um dia com paz e propósito!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida. Pressione ENTER para tentar novamente...");
                    Console.ReadLine();
                    continue;
            }

            if (atividadeAtual != null)
            {
                atividadeAtual.Executar();
                registro.RegistrarSessao(atividadeAtual.Nome, atividadeAtual.Duracao);
            }
        }
    }
}
