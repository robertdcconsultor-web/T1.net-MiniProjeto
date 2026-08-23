
//Correção para ligar as outras listas
using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models
{
    public class Caminhao : Veiculo
    {
        public int QuantidadeEixos {get; set;}
        public double CapacidadeCargaToneladas {get; set;}


        public Caminhao(String marca, string modelo, int ano, int quilometragem, int quantidadeEixos, double capacidadeCargaToneladas) : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadeEixos = quantidadeEixos;
            this.CapacidadeCargaToneladas = capacidadeCargaToneladas;
        }
        //Cooreção: erro de grafia!
        public override List<string> ObterChecklistObrigatorio()
        {
            //Correção - Puxando os itens do pai!
            List<string> checklist = base.ObterChecklistObrigatorio();

            checklist.Add("Tacógrafo");
            checklist.Add("Sistema de Freios a Ar");
            checklist.Add("Trava e Lona Caçamba");
            
            return checklist;
        }
    }
}