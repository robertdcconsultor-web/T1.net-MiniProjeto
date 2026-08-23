

using AutoCheck.ConsoleApp.Models;

namespace AutoCheck.ConsoleApp.Services
{
    public class MotorVistoria
    {
        public int PontuacaoObtida {get; private set;}
        public int PontuacaoMaxima {get; private set;}

        public double PercentualAprovado {get; private set;}

        public double ClassificacaoFinal {get; private set;}

        public void Processar(Veiculo veiculo)
        {
            this.PontuacaoMaxima = 0;
            this.PontuacaoObtida = veiculo.VistoriaRealizada.Count * 10;

            foreach (ItemVistoria item in vei)
        }
    }
}