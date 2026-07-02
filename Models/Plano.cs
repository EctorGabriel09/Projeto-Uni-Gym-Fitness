namespace UniGymFitness.Models
{
    public class Plano
    {
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public decimal Preco { get; set; }

        public string Descricao { get; set; } = string.Empty;

        public string Beneficios { get; set; } = string.Empty;
    }
}