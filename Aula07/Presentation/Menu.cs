namespace Aula07.Presentation;
public static class Menu
{
    public static void Mostrar()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Inclusao de cliente");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine("CLIENTE");
            Console.WriteLine(" 1 - Incluir");
            Console.WriteLine(" 2 - Alterar");
            Console.WriteLine(" 3 - Listar");

            Console.WriteLine("Escolha uma opção:");
            string opcao = Console.ReadLine();
            int opcaoNumero = Convert.ToInt32(opcao);

            if (opcaoNumero == 1)
                ClienteCadastro.Incluir();
            else if (opcaoNumero == 3)
                ClienteCadastro.Listar();
        }
    }
}
