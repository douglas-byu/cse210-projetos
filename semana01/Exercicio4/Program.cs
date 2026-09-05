using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();

        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");

        int entrada = -1;

        while (entrada != 0)
        {
            Console.Write("Insira o número: ");
            entrada = int.Parse(Console.ReadLine());

            if (entrada != 0)
            {
                numeros.Add(entrada);
            }
        }

        int soma = 0;
        foreach (int numero in numeros)
        {
            soma += numero;
        }

        double media = (double)soma / numeros.Count;

        int maior = numeros[0];
        foreach (int numero in numeros)
        {
            if (numero > maior)
            {
                maior = numero;
            }
        }

        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");

        int menorPositivo = int.MaxValue;
        foreach (int numero in numeros)
        {
            if (numero > 0 && numero < menorPositivo)
            {
                menorPositivo = numero;
            }
        }

        if (menorPositivo != int.MaxValue)
        {
            Console.WriteLine($"O menor número positivo é: {menorPositivo}");
        }

        numeros.Sort();
        Console.WriteLine("A lista reordenada é:");
        foreach (int numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}