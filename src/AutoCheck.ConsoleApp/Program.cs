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
    //Tela inicial para cadastro de veiculo!
    static void RealizarNovaVistoria(List<Veiculo> historico)
    {
        Console.WriteLine("--- Nova Vistoria ---\n");
        Console.WriteLine("Opção disponiveis\n 1 - Carro\n 2 - Moto \n 3 - Caminhão");
        Console.WriteLine("Informe o tipo de veiculo: ");
        string tipo = Console.ReadLine();

        Console.WriteLine("Marca: ");
        string marca = Console.ReadLine();

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

        foreach(string nomeItem in itensInspecionar)
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

    //Configurar a tela de relatório de vistorias!
    static void ExibirRelatorioVistorias(List<Veiculo> historico)
    {
                       
            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhuma vistoria realizada até o momento.");
                Console.WriteLine("Pressione ENTER para voltar ao menu.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n --- AUTOCHECK .NET - MOTOR DE VISTORIA ---\n");
            
            int contador = 1;
            MotorVistoria motor = new MotorVistoria();

            foreach (Veiculo veiculo in historico)
            {
                // Processa as notas do veículo atual
                motor.Processar(veiculo);

                Console.WriteLine($"\n[{contador}/{historico.Count}] PROCESSANDO VISTORIA\n");
                Console.WriteLine("> DADOS DO VEÍCULO:");
                
                // Identifica o tipo do veículo e pega o atributo específico
                string tipoTexto = "";
                string atributoEspecifico = "";
                
                if (veiculo is Carro)
                {
                    Carro c = (Carro)veiculo;
                    tipoTexto = "Carro";
                    atributoEspecifico = $"{c.QuantidadePortas} Portas";
                }
                else if (veiculo is Moto)
                {
                    Moto m = (Moto)veiculo;
                    tipoTexto = "Moto";
                    atributoEspecifico = $"{m.Cilindradas} cc";
                }
                else if (veiculo is Caminhao)
                {
                    Caminhao cam = (Caminhao)veiculo;
                    tipoTexto = "Caminhão";
                    atributoEspecifico = $"{cam.QuantidadeEixos} Eixos | Cap. Carga: {cam.CapacidadeCargaToneladas} Toneladas";
                }

                Console.WriteLine($"  - Tipo: {tipoTexto}");
                Console.WriteLine($"  - Modelo: {veiculo.Marca} {veiculo.Modelo}");
                Console.WriteLine($"  - Ano: {veiculo.Ano} | Quilometragem: {veiculo.Quilometragem} km");
                Console.WriteLine($"  - Atributo Específico: {atributoEspecifico}");

                Console.WriteLine($"\n> AVALIAÇÃO DOS ITENS INSPECIONADOS ({veiculo.VistoriaRealizada.Count} ITENS):");
                foreach (ItemVistoria item in veiculo.VistoriaRealizada)
                {
                    string icone = item.Status == "Bom" ? "[OK]" : item.Status == "Regular" ? "[ ! ]" : "[ X ]";
                    int pts = item.Status == "Bom" ? 10 : item.Status == "Regular" ? 5 : 0;
                    
                    // O ",-30" serve para alinhar o texto criando uma tabela imaginária de 30 caracteres
                    Console.WriteLine($"  {icone} {item.Nome,-30} Status: {item.Status} ({pts} pts)");
                }

                Console.WriteLine("\n> RESUMO DA PONTUAÇÃO:");
                Console.WriteLine($"  - Pontuação Atingida: {motor.PontuacaoObtida} de {motor.PontuacaoMaxima} pontos possíveis");
                Console.WriteLine($"  - Percentual de Aprovação: {motor.PercentualAprovacao:F1}%");
                Console.WriteLine($"  - Classificação Final: [ {motor.ClassificacaoFinal.ToUpper()} ]");

                Console.WriteLine("\n> RELATÓRIO DE MANUTENÇÃO E RECOMENDAÇÕES DA OFICINA:");
                
                bool temPendencia = false;

                // Varredura para itens Ruins
                bool temRuim = false;
                foreach (ItemVistoria item in veiculo.VistoriaRealizada) if (item.Status == "Ruim") temRuim = true;

                if (temRuim)
                {
                    temPendencia = true;
                    Console.WriteLine("  🔴 ITENS CRÍTICOS / REPROVADOS (AÇÃO IMEDIATA):");
                    foreach (ItemVistoria item in veiculo.VistoriaRealizada)
                    {
                        if (item.Status == "Ruim")
                            Console.WriteLine($"     - {item.Nome}: Repor ou reparar equipamento obrigatório ausente/danificado.");
                    }
                }

                // Varredura para itens Regulares
                bool temRegular = false;
                foreach (ItemVistoria item in veiculo.VistoriaRealizada) if (item.Status == "Regular") temRegular = true;

                if (temRegular)
                {
                    if (temRuim) Console.WriteLine(); // Apenas pular uma linha visualmente
                    temPendencia = true;
                    Console.WriteLine("  🟡 ITENS DE ATENÇÃO (REVISÃO PREVENTIVA):");
                    foreach (ItemVistoria item in veiculo.VistoriaRealizada)
                    {
                        if (item.Status == "Regular")
                            Console.WriteLine($"     - {item.Nome}: Realizar revisão, ajuste ou higienização preventiva.");
                    }
                }

                if (!temPendencia)
                {
                    Console.WriteLine("  🟢 Nenhuma pendência mecânica identificada. Veículo liberado para operação!");
                }

                Console.WriteLine("-------------------------------------------------------------------");
                contador++;
            }

            Console.WriteLine("\n --- FIM DO PROCESSAMENTO DE VISTORIAS --- \n");
            Console.WriteLine("Pressione ENTER para voltar ao menu.");
            Console.ReadLine();
        }
    }
}