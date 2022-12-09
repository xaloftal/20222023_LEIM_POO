// See https://aka.ms/new-console-template for more information

static void MenuDoDoente() 
{
    Console.WriteLine("---------------MENU DO DOENTE---------------\n");
    Console.WriteLine("1. Inserção de dados");
    Console.WriteLine("2. Atualização de dados");
    Console.WriteLine("3. Eliminação de dados");
    Console.WriteLine("4. Consultar doentes");

    int opcao = int.Parse(Console.ReadLine());

    switch (opcao)
    {
        default:
            break;
    }
}
