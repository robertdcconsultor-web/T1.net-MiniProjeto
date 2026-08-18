

namespace AutoCheck.ConsoleApp.Models
{
    public class Veiculo
    {
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public int Ano {get; set;}
        public int Quilometragem {get; set;}

        public List<ItemVistoria> VistoriaRealizada { get; set;}

        public Veiculo(string marca, string modelo, int ano, int quilometragem)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Ano = ano;
            this.Quilometragem = quilometragem;          
        }

        public void AdicionarItemVistoria(string nome, string status)
        {
            ItemVistoria novoItem = new ItemVistoria(nome, status);
            this.VistoriaRealizada.Add(novoItem);
        }        
        public virtual List<string> ObterChecklistObrigatorio()
        {
            List<string> checklistGenerico = new List<string>();
            checklistGenerico.Add("Nível de Óleo do Motor");
            checklistGenerico.Add("Bateria e Sistema Elétrico");
            checklistGenerico.Add("Documentação Regularizada");
            return checklistGenerico;
            
        }
    }
}