
using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services
{
    public class MotorVistoria
    {
        
        public int PontuacaoObtida {get; private set;}
        public int PontuacaoMaxima {get; private set;}

        public double PercentualAprovacao {get; private set;}

        public string ClassificacaoFinal {get; private set;} = "";

        public void Processar(Veiculo veiculo)
        {
            this.PontuacaoObtida = 0;
            this.PontuacaoMaxima = veiculo.VistoriaRealizada.Count * 10;

            //Atende aos critérios de pontuação, poderia ter apenas colocado 1 para ruim, 2 para regular e 3 pra bom, mas dá no mesmo!
            foreach (ItemVistoria item in veiculo.VistoriaRealizada)
            {
                if (item.Status == "Bom") this.PontuacaoObtida += 10;
                else if (item.Status == "Regular") this.PontuacaoObtida += 5;
            }
            if (this.PontuacaoMaxima > 0)
            {
                //Atende a somatória solicita
                this.PercentualAprovacao = ((double)this.PontuacaoObtida / this.PontuacaoMaxima) *100;             
            }
            else
            {
                this.PercentualAprovacao = 0;
            }

            ClassificarVeiculo();
        }
        private void ClassificarVeiculo()
        {
            if (this.PercentualAprovacao >=90) this.ClassificacaoFinal = "Aprovado com Excelência";
            else if (this.PercentualAprovacao >=60) this.ClassificacaoFinal = "Aprovado com Apontamentos";
            else this.ClassificacaoFinal = "Reprovado na Vistoria";
        }
    }
}
