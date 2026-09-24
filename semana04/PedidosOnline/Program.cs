using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Pedido 1 - cliente nos EUA (frete $5)
        Endereco endereco1 = new Endereco("123 Main St", "Salt Lake City", "UT", "EUA");
        Cliente cliente1 = new Cliente("João Silva", endereco1);
        Pedido pedido1 = new Pedido(cliente1);
        pedido1.AdicionarProduto(new Produto("Teclado Mecânico", "TEC-001", 120.00, 1));
        pedido1.AdicionarProduto(new Produto("Mouse Gamer", "MOU-002", 75.50, 2));
        pedido1.AdicionarProduto(new Produto("Mousepad XL", "PAD-003", 30.00, 1));

        // Pedido 2 - cliente fora dos EUA (frete $35)
        Endereco endereco2 = new Endereco("Rua das Flores, 456", "São Paulo", "SP", "Brasil");
        Cliente cliente2 = new Cliente("Maria Oliveira", endereco2);
        Pedido pedido2 = new Pedido(cliente2);
        pedido2.AdicionarProduto(new Produto("Monitor 27\"", "MON-010", 350.00, 1));
        pedido2.AdicionarProduto(new Produto("Cabo HDMI", "CAB-011", 15.00, 2));

        List<Pedido> pedidos = new List<Pedido> { pedido1, pedido2 };

        foreach (Pedido pedido in pedidos)
        {
            Console.WriteLine(pedido.GetEtiquetaEmbalagem());
            Console.WriteLine(pedido.GetEtiquetaEnvio());
            Console.WriteLine($"Custo Total: ${pedido.GetCustoTotal():F2}");
            Console.WriteLine(new string('-', 40));
        }
    }
}