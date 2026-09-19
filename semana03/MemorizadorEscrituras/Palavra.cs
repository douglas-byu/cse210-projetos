using System;

public class Palavra
{
    private string _texto;
    private bool _estaEscondida;

    public Palavra(string texto)
    {
        _texto = texto;
        _estaEscondida = false;
    }

    // Oculta a palavra
    public void Esconder()
    {
        _estaEscondida = true;
    }

    // Exibe a palavra
    public void Exibir()
    {
        _estaEscondida = false;
    }

    // Retorna se a palavra está escondida
    public bool EstaEscondida()
    {
        return _estaEscondida;
    }

    // Retorna o texto da palavra ou sublinhados se estiver escondida
    public string ObterTexto()
    {
        if (_estaEscondida)
        {
            return new string('_', _texto.Length);
        }

        return _texto;
    }
}
