using System.Collections.Generic;
using System.Text;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double GetCustoTotal()
    {
        double total = 0;
        foreach (Produto p in _produtos)
        {
            total += p.GetCustoTotal();
        }

        double frete = _cliente.MoraNosEUA() ? 5.0 : 35.0;
        return total + frete;
    }

    public string GetEtiquetaEmbalagem()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== Etiqueta de Embalagem ===");
        foreach (Produto p in _produtos)
        {
            sb.AppendLine($"- {p.GetNome()} (ID: {p.GetId()})");
        }
        return sb.ToString();
    }

    public string GetEtiquetaEnvio()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("=== Etiqueta de Envio ===");
        sb.AppendLine(_cliente.GetNome());
        sb.AppendLine(_cliente.GetEndereco().GetEnderecoCompleto());
        return sb.ToString();
    }
}
