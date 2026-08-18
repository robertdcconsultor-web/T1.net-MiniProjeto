

namespace AutoCheck.ConsoleApp.Models
{
    public class Moto : Veiculo
    {
        public int Cilindradas {get; set;}

        public Moto(String marca, string modelo, int ano, int quilometragem, int quantidadePortas) : base(marca, modelo, ano, quilometragem)
        {
            this.Clilindradas = cilindradas;
        }
        public override List<string> ObterChechlistObrigatorio()
        {
            List<string> checklist = new List<string>();

            checklist.Add("Kit Transmissão e Corrente");
            checklist.Add("Manete de Freio e Embreagem");
            checklist.Add("Pezinho Lateral ");
            
            return checklist;
        }
    }
}