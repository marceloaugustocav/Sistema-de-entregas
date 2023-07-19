using System;
using System.Collections.Generic;

class Delivery
{
    public int Id { get; set; }
    public string Address { get; set; }
    public bool Delivered { get; set; }
}

class Program
{
    static List<Delivery> deliveries = new List<Delivery>();
    static int lastId = 0;

    static void Main()
    {
        Console.WriteLine("Sistema de Entregas");
        Console.WriteLine("*******************");

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1 - Adicionar pedido de entrega");
            Console.WriteLine("2 - Mostrar pedidos de entrega");
            Console.WriteLine("3 - Marcar pedido como entregue");
            Console.WriteLine("4 - Sair do programa");

            Console.Write("Opção: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Digite o endereço de entrega: ");
                    string address = Console.ReadLine();
                    AddDelivery(address);
                    Console.WriteLine("Pedido de entrega adicionado com sucesso!");
                    break;

                case "2":
                    ShowDeliveries();
                    break;

                case "3":
                    Console.Write("Digite o ID do pedido a ser marcado como entregue: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        MarkDeliveryAsDelivered(id);
                    }
                    else
                    {
                        Console.WriteLine("ID inválido! Tente novamente.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }

    static void AddDelivery(string address)
    {
        lastId++;
        deliveries.Add(new Delivery { Id = lastId, Address = address, Delivered = false });
    }

    static void ShowDeliveries()
    {
        Console.WriteLine("Pedidos de Entrega:");
        foreach (var delivery in deliveries)
        {
            Console.WriteLine($"ID: {delivery.Id}, Endereço: {delivery.Address}, Entregue: {delivery.Delivered}");
        }
    }

    static void MarkDeliveryAsDelivered(int id)
    {
        var delivery = deliveries.Find(d => d.Id == id);
        if (delivery != null)
        {
            delivery.Delivered = true;
            Console.WriteLine($"Pedido de entrega {id} marcado como entregue!");
        }
        else
        {
            Console.WriteLine($"Pedido de entrega {id} não encontrado!");
        }
    }
}
