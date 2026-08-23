
namespace AutoCheck.ConsoleApp.Models
{
    public class Carro : Veiculo
    {
        public int QuantidadePortas {get; set;}

        public Carro(String marca, string modelo, int ano, int quilometragem, int quantidadePortas) : base(marca, modelo, ano, quilometragem)
        {
            this.QuantidadePortas = quantidadePortas;
        }
        //Cooreção: erro de grafia!
        public override List<string> ObterChecklistObrigatorio()
        {
            //Correção - Puxando os itens do pai!
            List<string> checklist = base.ObterChecklistObrigatorio();

            checklist.Add("Estepe e Macado");
            checklist.Add("Triangulo de Sinalização");
            checklist.Add("Arcondicionado Funciona");
            
            return checklist;
        }
    }
}