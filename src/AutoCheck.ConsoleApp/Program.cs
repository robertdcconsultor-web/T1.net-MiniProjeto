//Caminhos necessários de integração!
using System;
using System.Collections.Generic;
using AutoCheck.ConsoleApp.Models;
using AutoCheck.ConsoleApp.Services;

namespace AutoCheck.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //A lista que vai armazenar as vistorias
            List<Veiculo> historicoVistorias = new List<Veiculo>();
            string opcao = "";

            //Tela inicial do sistema! Vamos criar o menu principal com laço de repetção DO e While
            do
            {
                Console.WriteLine("\n ---AUTOCHECK - MENU PRINCIPAL---\n");
                Console.WriteLine("1 - Realizar Nova Vistoria");
                Console.WriteLine("2 - Exibir Relatório das Vistorias");
                Console.WriteLine("3 - Sair\n");
                Console.WriteLine("Escolha uma das opções: ");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                    RealizarNovaVistoria(historicoVistorias);
                    break;
                    case "2":
                    ExibirRelatorioVistorias(historicoVistorias);
                    break;
                    case "3":
                    Console.WriteLine("\n Opção sair selecionado\n Sistema encerrado!\n");
                    break;
                    //Proteção em caso de pressionar algo não programado!
                    default:
                        Console.WriteLine("\n Opção Inválida! Selecione uma opção válida");
                        Console.ReadLine();
                        break;
                }
                
            } while (opcao != "0");
        }
    }
}

//Tela inicial para cadastro de veiculo!
static void RealizarNovaVistoria(List<Veiculo> historico)
{
    Console.WriteLine("--- Nova Vistoria ---\n");
    Console.WriteLine("Opção disponiveis\n 1 - Carro\n 2 - Moto \n 3 - Caminhão");
    Console.WriteLine("Informe o tipo de veiculo: ");
    string tipo = Console.ReadLine();

    Console.WriteLine("Marca: ");
    string tipo = Console.ReadLine();

    Console.WriteLine("Modelo: ");
    string modelo = Console.ReadLine();

    Console.WriteLine("Ano: ");
    int ano = int.Parse(Console.ReadLine());

    Console.WriteLine("Quilometragem: ");
    int km = int.Parse(Console.ReadLine());

    Veiculo novoVeiculo = null;

    //Vamos cadastrar os veiculos usando as subclasses Carro, Moto ou Caminhão
    if (tipo == "1")
    {
        Console.WriteLine("Quantidade de portas: ");
        int portas = int.Parse(Console.ReadLine());
        novoVeiculo = new Carro(marca, modelo, ano, km, portas);
    }
    else if (tipo == "2")
    {
        Console.WriteLine("Cilindradas: ");
        int cilindradas = int.Parse(Console.ReadLine());
        novoVeiculo = new Moto(marca, modelo, ano, km, cilindradas);
    }
    else if (tipo == "3")
    {
        Console.WriteLine("Qunatidade de eixos: ");
        int eixos = int.Parse(Console.ReadLine());
        Console.WriteLine("Capacidade de carga (em toneladas): ");
        double carga = double.Parse(Console.ReadLine());
        novoVeiculo = new Caminhao(marca, modelo, ano, km, eixos, carga);
    }
    else
    {
        Console.WriteLine("Tipo inválido. Vistoria Cancelada!");
        Console.ReadLine();
        return;
    }

    //Vamos coleçar o checklist
    Console.WriteLine("\n --- Preenchimento do Checklist --- \n");

    //Carrega a lista correta de acordo com o tipo informado!
    List<string> itensInspecionar = novoVeiculo.ObterChecklistObrigatorio();

    foreach (string nomeItem in itensInspecionar)
    {
        Console.WriteLine($"\nItem: {nomeItem}");
        Console.WriteLine("Status (1 - Bom | 2 - Regular | 3 - Ruim): ");
        string escolha = Console.ReadLine();

        string statusFinal = "Ruim"; //Define ruim por defaul!
        if (escolha == "1") statusFinal = "Bom";
        else if (escolha == "2") statusFinal = "Regular";

        novoVeiculo.AdicionarItemVistoria(nomeItem, statusFinal);
    }
    //Vamos salvar na lista do sistema oara posterior consulta
    historico.Add(novoVeiculo);

    Console.WriteLine("\n Vistoria concluida e salva com sucesso!")
    Console.ReadLine();
}