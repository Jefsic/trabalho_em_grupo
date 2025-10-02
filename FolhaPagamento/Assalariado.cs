namespace FolhaPagamento
{
    class Assalariado : Funcionario
    {
        public override void CalcularSalario()
        {
            SalarioFinal = DiasTrabalhados * (SalarioBase / 30);
        }
    }
}