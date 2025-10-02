namespace FolhaPagamento
{
    abstract class Funcionario
    {
        public string Nome { get; set; }
        public int Modalidade { get; set; }
        public double SalarioBase { get; set; }
        public int DiasTrabalhados { get; set; }
        public int DadoDaModalidade { get; set; }
        public double SalarioFinal { get; set; }

     
        public abstract void CalcularSalario();

        public Funcionario() { }

        // Construtor completo para todas as propriedades
        public Funcionario(string nome, int modalidade, double salarioBase, int diasTrabalhados, int dadoDaModalidade)
        {
            Nome = nome;
            Modalidade = modalidade;
            SalarioBase = salarioBase;
            DiasTrabalhados = diasTrabalhados;
            DadoDaModalidade = dadoDaModalidade;
        }
    }
}