using System;

public class Corrida : Atividade
{
    private double _distanciaKm;

    public Corrida(string data, int duracaoMinutos, double distanciaKm)
        : base(data, duracaoMinutos)
    {
        _distanciaKm = distanciaKm;
    }

    public override double ObterDistancia()
    {
        return _distanciaKm;
    }

    public override double ObterVelocidade()
    {
        // Velocidade (km/h) = (distância / minutos) * 60
        return (_distanciaKm / GetDuracaoMinutos()) * 60.0;
    }

    public override double ObterRitmo()
    {
        // Ritmo (min por km) = minutos / distância
        return GetDuracaoMinutos() / _distanciaKm;
    }

    public override string ObterTipoAtividade()
    {
        return "Corrida";
    }
}
