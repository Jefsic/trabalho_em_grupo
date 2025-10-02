namespace FolhaPagamento
{
    class Horista : Funcionario
    {
        public override void CalcularSalario()
        {
            SalarioFinal = (SalarioBase / 30 / 8) * DadoDaModalidade;
        }
    }
}