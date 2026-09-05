using System;

class Program
{
    static void Main(string[] args)
    {
        // Pede a nota numérica ao usuário
        Console.Write("Qual é a sua nota? ");
        string entradaUsuario = Console.ReadLine();
        int nota = int.Parse(entradaUsuario);

        // ============================================================
        // REQUISITO 1 e 3: Determina a letra da nota e salva em variável
        // ============================================================
        string letra;

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >= 80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        // ============================================================
        // DESAFIO ADICIONAL: Determina o sinal + ou -
        // ============================================================
        string sinal;
        int ultimoDigito = nota % 10;

        if (ultimoDigito >= 7)
        {
            sinal = "+";
        }
        else if (ultimoDigito < 3)
        {
            sinal = "-";
        }
        else
        {
            sinal = "";
        }

        // Caso especial: não existe A+, apenas A ou A-
        if (letra == "A" && sinal == "+")
        {
            sinal = "";
        }

        // Caso especial: não existe F+ ou F-, apenas F
        if (letra == "F")
        {
            sinal = "";
        }

        // Exibe a nota conceitual uma única vez
        Console.WriteLine($"Sua nota é: {letra}{sinal}");

        // ============================================================
        // REQUISITO 2: Verifica se foi aprovado (>= 70)
        // ============================================================
        if (nota >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado no curso!");
        }
        else
        {
            Console.WriteLine("Não desanime! Continue estudando e você conseguirá na próxima vez!");
        }
    }
}