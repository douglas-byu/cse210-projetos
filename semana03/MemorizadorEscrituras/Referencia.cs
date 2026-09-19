using System;

public class Referencia
{
    private string _livro;
    private int _capitulo;
    private int _versiculo;
    private int _ultimoVersiculo;

    // Construtor para versículo único (ex: "João 3:16")
    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculo;
        _ultimoVersiculo = versiculo;
    }

    // Construtor para intervalo de versículos (ex: "Provérbios 3:5-6")
    public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculo = versiculoInicial;
        _ultimoVersiculo = versiculoFinal;
    }

    // Retorna a representação formatada da referência
    public string ObterTexto()
    {
        if (_versiculo == _ultimoVersiculo)
        {
            return $"{_livro} {_capitulo}:{_versiculo}";
        }
        else
        {
            return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
        }
    }
}
