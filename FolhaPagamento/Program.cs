using System;
using System.Collections.Generic;

namespace FolhaPagamento
{
    
    class Program
    {
        static List<Funcionario> colaborador = new List<Funcionario>();
        static double totalFolha;

        static void Main()
        {
            
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA FOLHA DE PAGAMENTO ===");

                Console.WriteLine("Insira o nome do funcionário");
                string nome = Console.ReadLine();

                Console.WriteLine("Informe a remuneração base da função:");
                double salarioBase = double.Parse(Console.ReadLine());

                Console.WriteLine("Informe o número de dias trabalhados no mês:");
                int diasTrabalhados = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe a modalidade de remuneração: (1.Assalariado  2.Horista  3.Comissionado)");
                int modalidade = int.Parse(Console.ReadLine());

                Funcionario funcionario = null;
                int dadoExtra = 0;

                switch (modalidade)
                {
                    case 1: // Assalariado
                        funcionario = new Assalariado();
                        break;

                    case 2: // Horista
                        Console.WriteLine("Informe a quantidade de horas trabalhadas no mês:");
                        dadoExtra = int.Parse(Console.ReadLine());
                        funcionario = new Horista();
                        break;

                    case 3: // Comissionado
                        Console.WriteLine("Informe o volume total de vendas do funcionário no mês:");
                        dadoExtra = int.Parse(Console.ReadLine());
                        funcionario = new Comissionado();
                        break;

                    default:
                        Console.WriteLine("Modalidade inválida!");
                        Console.ReadLine();
                        continue; // Volta para o início do loop
                }

                // Preenche os dados usando o construtor vazio + propriedades
                funcionario.Nome = nome;
                funcionario.SalarioBase = salarioBase;
                funcionario.DiasTrabalhados = diasTrabalhados;
                funcionario.Modalidade = modalidade;
                funcionario.DadoDaModalidade = dadoExtra;

                // Chama o cálculo polimórfico
                funcionario.CalcularSalario();

                colaborador.Add(funcionario);

                Console.Clear();
                Console.WriteLine("=== FUNCIONÁRIO CADASTRADO COM SUCESSO ===");
                Console.WriteLine($"Nome: {funcionario.Nome}");
                Console.WriteLine($"Modalidade: {funcionario.Modalidade}");
                Console.WriteLine($"Salário Base: {funcionario.SalarioBase:C}");
                Console.WriteLine($"Salário Final: {funcionario.SalarioFinal:C}");
                Console.WriteLine();

                // Pergunta se deseja continuar
                Console.WriteLine("Deseja cadastrar outro funcionário? (S/N)");
                string resposta = Console.ReadLine().ToUpper();

                if (resposta != "S")
                {
                    continuar = false;
                }
            }

            // Mostra relatório final
            Console.Clear();
            Console.WriteLine("=== RELATÓRIO FINAL ===");
            Console.WriteLine($"Total de funcionários cadastrados: {colaborador.Count}");
            Console.WriteLine();

            foreach (var func in colaborador)
            {
                string tipo = func.Modalidade switch
                {
                    1 => "Assalariado",
                    2 => "Horista",
                    3 => "Comissionado",
                    _ => "Desconhecido"
                };

                Console.WriteLine($"{func.Nome} - {tipo} - Salário: {func.SalarioFinal:C}");

                totalFolha += func.SalarioFinal;
            }


            Console.WriteLine();
            Console.WriteLine($"O VALOR TOTAL DA FOLHA FOI DE: {totalFolha.ToString("F2")}");
         

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadLine();
        }
    }
}