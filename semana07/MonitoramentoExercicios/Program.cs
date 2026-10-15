using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Lista polimórfica de atividades
        List<Atividade> atividades = new List<Atividade>();

        // Criação de pelo menos uma atividade de cada tipo
        atividades.Add(new Corrida("03 Nov 2022", 30, 4.8));
        atividades.Add(new Ciclismo("04 Nov 2022", 45, 20.0));
        atividades.Add(new Natacao("05 Nov 2022", 30, 40));

        Console.WriteLine("================================================================================");
        Console.WriteLine("               SISTEMA DE MONITORAMENTO DE EXERCÍCIOS");
        Console.WriteLine("================================================================================\n");

        // Itera sobre a lista chamando o método ObterResumo em cada atividade
        foreach (Atividade atividade in atividades)
        {
            Console.WriteLine(atividade.ObterResumo());
        }

        Console.WriteLine("\n================================================================================");
    }
}