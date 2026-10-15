using System;

public class Natacao : Atividade
{
    private int _voltas;

    public Natacao(string data, int duracaoMinutos, int voltas)
        : base(data, duracaoMinutos)
    {
        _voltas = voltas;
    }

    public override double ObterDistancia()
    {
        // Uma volta na piscina tem 50 metros. Distância (km) = voltas * 50 / 1000
        return _voltas * 50.0 / 1000.0;
    }

    public override double ObterVelocidade()
    {
        // Velocidade (km/h) = (distância / minutos) * 60
        return (ObterDistancia() / GetDuracaoMinutos()) * 60.0;
    }

    public override double ObterRitmo()
    {
        // Ritmo (min por km) = minutos / distância
        return GetDuracaoMinutos() / ObterDistancia();
    }

    public override string ObterTipoAtividade()
    {
        return "Natação";
    }
}
