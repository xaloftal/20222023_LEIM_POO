// See https://aka.ms/new-console-template for more information
using RNCCI.Modelos;
using RNCCI.Enums;
using RNCCI.Dados;

//Morada morada = new Morada("4770",Distrito.Braga );
//morada.Rua = "Rua das Boucas";
//morada.NumeroPorta = 313;
//morada.Cidade = "Avidos";
//Console.WriteLine($"{morada.Rua}, {morada.CodigoPostal} {morada.Cidade} ( {morada.Coordenadas} )");

Doentes doentes1 = new Doentes();


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
