using System;

class Program
{
    static void Main(string[] args)
    {
        string opcao = "";

        while (opcao != "4")
        {
            Console.Clear();
            Console.WriteLine("Opções de Menu:");
            Console.WriteLine("  1. Iniciar atividade de respiração");
            Console.WriteLine("  2. Iniciar atividade de reflexão");
            Console.WriteLine("  3. Iniciar atividade de listagem");
            Console.WriteLine("  4. Sair");
            Console.Write("Escolha uma opção do menu: ");
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                AtividadeDeRespiracao respiracao = new AtividadeDeRespiracao();
                respiracao.Executar();
            }
            else if (opcao == "2")
            {
                AtividadeDeReflexao reflexao = new AtividadeDeReflexao();
                reflexao.Executar();
            }
            else if (opcao == "3")
            {
                AtividadeDeListagem listagem = new AtividadeDeListagem();
                listagem.Executar();
            }
        }
    }
}
