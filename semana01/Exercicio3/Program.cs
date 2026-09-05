using System;

class Program
{
    static void Main(string[] args)
    {
        string jogarNovamente = "sim";

        while (jogarNovamente == "sim")
        {
            Random geradorAleatorio = new Random();
            int numeroMagico = geradorAleatorio.Next(1, 101);

            int palpite = 0;
            int contadorPalpites = 0;

            while (palpite != numeroMagico)
            {
                Console.Write("Qual é o seu palpite? ");
                string entradaUsuario = Console.ReadLine();
                palpite = int.Parse(entradaUsuario);
                contadorPalpites++;

                if (palpite < numeroMagico)
                {
                    Console.WriteLine("Mais alto");
                }
                else if (palpite > numeroMagico)
                {
                    Console.WriteLine("Mais baixo");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                    Console.WriteLine($"Você precisou de {contadorPalpites} palpites.");
                }
            }

            Console.Write("Deseja jogar novamente? (sim/não) ");
            jogarNovamente = Console.ReadLine();
        }

        Console.WriteLine("Obrigado por jogar!");
    }
}