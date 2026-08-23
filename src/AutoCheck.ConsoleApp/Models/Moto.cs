
//Correção para lisgar as outras listas
using System.Collections.Generic;

namespace AutoCheck.ConsoleApp.Models
{
    public class Moto : Veiculo
    {
        public int Cilindradas {get; set;}

        public Moto(String marca, string modelo, int ano, int quilometragem, int cilindradas) : base(marca, modelo, ano, quilometragem)
        {
            this.Cilindradas = cilindradas;
        }
        //Cooreção: erro de grafia!
        public override List<string> ObterChecklistObrigatorio()
        {
            //Correção - Puxando os itens do pai!
            List<string> checklist = base.ObterChecklistObrigatorio();

            checklist.Add("Kit Transmissão e Corrente");
            checklist.Add("Manete de Freio e Embreagem");
            checklist.Add("Pezinho Lateral ");
            
            return checklist;
        }
    }
}