using System;

public class Ciclismo : Atividade
{
    private double _velocidadeKmh;

    public Ciclismo(string data, int duracaoMinutos, double velocidadeKmh)
        : base(data, duracaoMinutos)
    {
        _velocidadeKmh = velocidadeKmh;
    }

    public override double ObterDistancia()
    {
        // Distância (km) = (velocidade * minutos) / 60
        return (_velocidadeKmh * GetDuracaoMinutos()) / 60.0;
    }

    public override double ObterVelocidade()
    {
        return _velocidadeKmh;
    }

    public override double ObterRitmo()
    {
        // Ritmo (min por km) = 60 / velocidade
        return 60.0 / _velocidadeKmh;
    }

    public override string ObterTipoAtividade()
    {
        return "Ciclismo";
    }
}
