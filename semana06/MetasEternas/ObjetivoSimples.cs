using System;

public class ObjetivoSimples : Objetivo
{
    private bool _terminado;

    public ObjetivoSimples(string titulo, string descricao, int pontos) 
        : base(titulo, descricao, pontos)
    {
        _terminado = false;
    }

    public ObjetivoSimples(string titulo, string descricao, int pontos, bool terminado) 
        : base(titulo, descricao, pontos)
    {
        _terminado = terminado;
    }

    public override void RegistrarProgresso()
    {
        _terminado = true;
    }

    public override bool FoiCumprido()
    {
        return _terminado;
    }

    public override string SalvarEmLinha()
    {
        return $"Simples|{GetTitulo()}|{GetDescricao()}|{GetPontos()}|{_terminado}";
    }
}
