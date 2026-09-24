public class Produto
{
    private string _nome;
    private string _id;
    private double _preco;
    private int _quantidade;

    public Produto(string nome, string id, double preco, int quantidade)
    {
        _nome = nome;
        _id = id;
        _preco = preco;
        _quantidade = quantidade;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetId()
    {
        return _id;
    }

    public double GetCustoTotal()
    {
        return _preco * _quantidade;
    }
}
