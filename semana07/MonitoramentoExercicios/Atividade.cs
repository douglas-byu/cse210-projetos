using System;
using System.Globalization;

public abstract class Atividade
{
    private string _data;
    private int _duracaoMinutos;

    public Atividade(string data, int duracaoMinutos)
    {
        _data = data;
        _duracaoMinutos = duracaoMinutos;
    }

    public string GetData()
    {
        return _data;
    }

    public int GetDuracaoMinutos()
    {
        return _duracaoMinutos;
    }

    // Métodos virtuais/abstratos a serem sobrescritos nas classes derivadas
    public abstract double ObterDistancia();
    public abstract double ObterVelocidade();
    public abstract double ObterRitmo();
    public abstract string ObterTipoAtividade();

    // Método que produz o resumo formatado utilizando polimorfismo
    public virtual string ObterResumo()
    {
        string distancia = ObterDistancia().ToString("0.0", CultureInfo.InvariantCulture);
        string velocidade = ObterVelocidade().ToString("0.0", CultureInfo.InvariantCulture);
        string ritmo = ObterRitmo().ToString("0.00", CultureInfo.InvariantCulture);

        return $"{_data} {ObterTipoAtividade()} ({_duracaoMinutos} min): Distância {distancia} km, Velocidade: {velocidade} km/h, Ritmo: {ritmo} min por km";
    }
}
