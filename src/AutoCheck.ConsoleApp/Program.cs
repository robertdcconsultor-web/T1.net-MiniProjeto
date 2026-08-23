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

            //Vamos criar o menu principal com o do (switch - laço de repetição)
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

