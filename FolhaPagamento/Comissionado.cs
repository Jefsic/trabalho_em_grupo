namespace FolhaPagamento
{
    class Comissionado : Funcionario
    {
        public override void CalcularSalario()
        {
            SalarioFinal = (DiasTrabalhados * (SalarioBase / 30)) + (DadoDaModalidade * 0.10);
        }
    }
}