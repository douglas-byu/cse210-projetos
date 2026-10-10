using System;

public abstract class Objetivo
{
    private string _titulo;
    private string _descricao;
    private int _pontos;

    public Objetivo(string titulo, string descricao, int pontos)
    {
        _titulo = titulo;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string GetTitulo()
    {
        return _titulo;
    }

    public string GetDescricao()
    {
        return _descricao;
    }

    public int GetPontos()
    {
        return _pontos;
    }

    public abstract void RegistrarProgresso();

    public abstract bool FoiCumprido();

    public virtual string FormatarExibicao()
    {
        string status = FoiCumprido() ? "[X]" : "[ ]";
        return $"{status} {_titulo} ({_descricao})";
    }

    public abstract string SalvarEmLinha();
}
