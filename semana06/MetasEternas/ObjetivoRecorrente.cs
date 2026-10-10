using System;

public class ObjetivoRecorrente : Objetivo
{
    public ObjetivoRecorrente(string titulo, string descricao, int pontos) 
        : base(titulo, descricao, pontos)
    {
    }

    public override void RegistrarProgresso()
    {
    }

    public override bool FoiCumprido()
    {
        return false;
    }

    public override string SalvarEmLinha()
    {
        return $"Recorrente|{GetTitulo()}|{GetDescricao()}|{GetPontos()}";
    }
}
