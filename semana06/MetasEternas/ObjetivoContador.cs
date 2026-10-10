using System;

public class ObjetivoContador : Objetivo
{
    private int _execucoes;
    private int _alvo;
    private int _pontosBonus;

    public ObjetivoContador(string titulo, string descricao, int pontos, int alvo, int pontosBonus)
        : base(titulo, descricao, pontos)
    {
        _alvo = alvo;
        _pontosBonus = pontosBonus;
        _execucoes = 0;
    }

    public ObjetivoContador(string titulo, string descricao, int pontos, int alvo, int pontosBonus, int execucoes)
        : base(titulo, descricao, pontos)
    {
        _alvo = alvo;
        _pontosBonus = pontosBonus;
        _execucoes = execucoes;
    }

    public int GetExecucoes()
    {
        return _execucoes;
    }

    public int GetAlvo()
    {
        return _alvo;
    }

    public int GetPontosBonus()
    {
        return _pontosBonus;
    }

    public override void RegistrarProgresso()
    {
        _execucoes++;
    }

    public override bool FoiCumprido()
    {
        return _execucoes >= _alvo;
    }

    public override string FormatarExibicao()
    {
        string status = FoiCumprido() ? "[X]" : "[ ]";
        return $"{status} {GetTitulo()} ({GetDescricao()}) -- Progresso: {_execucoes}/{_alvo}";
    }

    public override string SalvarEmLinha()
    {
        return $"Contador|{GetTitulo()}|{GetDescricao()}|{GetPontos()}|{_alvo}|{_pontosBonus}|{_execucoes}";
    }
}
