public class Comentario
{
    private string _nome;
    private string _texto;

    public Comentario(string nome, string texto)
    {
        _nome = nome;
        _texto = texto;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetTexto()
    {
        return _texto;
    }
}
