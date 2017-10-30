using System.ComponentModel.DataAnnotations;


namespace NovoBackend.Models
{
    public class Dados
    {
        public int DadosID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int Poligonos { get; set; }
    }
}