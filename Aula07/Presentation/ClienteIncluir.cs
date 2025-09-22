using System.Reflection.Metadata.Ecma335;
using Aula07.Application.Services;
using Aula07.Domain.Entities;

namespace Aula07.Presentation;
public static class ClienteCadastro
{
    public static void Incluir()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Inclusao de cliente");
            Console.WriteLine("-------------------");
            Console.WriteLine();

            Cliente cliente = new Cliente();

            Console.WriteLine("Nome:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Endereço:");
            cliente.Endereço = Console.ReadLine();

            ClienteService.Incluir(cliente);

            Console.WriteLine("Deseja incluir outro (N/s)?");
            string resposta = Console.ReadLine();

            if (resposta.Trim().ToLower() != "s")
                break;
        }

    }

    public static void Listar()
    {
        Console.Clear();

        Console.WriteLine("Listagem de clientes");
        Console.WriteLine("-------------------");
        Console.WriteLine();

        foreach (Cliente cliente in ClienteService.Listar()) 
        {
            Console.WriteLine(cliente.Id+cliente.Nome + cliente.Endereço);
        }

        Console.WriteLine("Pressione qualuqer tecla");
        Console.ReadKey();

    }
}
