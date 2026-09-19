using System;
using System.Collections.Generic;
using System.Linq;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;
    private static Random _geradorAleatorio = new Random();

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] partes = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string parte in partes)
        {
            _palavras.Add(new Palavra(parte));
        }
    }

    // Esconde aleatoriamente uma quantidade especificada de palavras
    // Indo além dos requisitos: seleciona apenas entre as palavras que ainda NÃO foram escondidas
    public void EsconderPalavrasAleatorias(int numeroParaEsconder)
    {
        List<Palavra> palavrasVisiveis = _palavras.Where(p => !p.EstaEscondida()).ToList();

        if (palavrasVisiveis.Count == 0)
        {
            return;
        }

        // Embaralha as palavras visíveis usando o algoritmo Fisher-Yates
        int n = palavrasVisiveis.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = _geradorAleatorio.Next(i + 1);
            Palavra temp = palavrasVisiveis[i];
            palavrasVisiveis[i] = palavrasVisiveis[j];
            palavrasVisiveis[j] = temp;
        }

        int quantidadeParaEsconder = Math.Min(numeroParaEsconder, palavrasVisiveis.Count);
        for (int i = 0; i < quantidadeParaEsconder; i++)
        {
            palavrasVisiveis[i].Esconder();
        }
    }

    // Retorna a referência seguida do texto com as palavras exibidas ou ocultas
    public string ObterTexto()
    {
        string textoPalavras = string.Join(" ", _palavras.Select(p => p.ObterTexto()));
        return $"{_referencia.ObterTexto()} {textoPalavras}";
    }

    // Verifica se todas as palavras já foram escondidas
    public bool EstaCompletamenteEscondida()
    {
        return _palavras.All(p => p.EstaEscondida());
    }
}
