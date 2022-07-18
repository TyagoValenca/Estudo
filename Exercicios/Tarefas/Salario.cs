using System;

namespace Exercicios
{
    public class Salario
    {
        public static void Reajuste()
        {
            Console.Clear();
            Console.WriteLine("Informe o valor do salário");
            var sSalario = Console.ReadLine() ?? string.Empty;
            if (sSalario == string.Empty)
            {
                Console.WriteLine("Nenhum valor foi informado!");
            }
            else
            {
                try
                {
                    decimal salario = decimal.Parse(sSalario);
                    decimal aumento = 200m;
                    //if (salario < 1700) Console.WriteLine(string.Format("Parabéns pelo aumento de 200 reais.\nSeu salário passou de {0} para {1} reais.", salario, salario + 300));                 
                    //else Console.WriteLine(string.Format("Parabéns pelo aumento de 200 reais.\nSeu salário passou de {0} para {1} reais. ", salario, salario + 200));

                    if (salario < 1700) aumento = 300m;
                    //Console.WriteLine(string.Format("Parabéns pelo aumento de {0} reais.\nSeu salário passou de {1} para {2} reais. ", aumento, salario, salario + aumento));
                    Console.WriteLine($"Parabéns pelo aumento de {aumento} reais.\nSeu salário passou de {salario} para {salario + aumento} reais. ");
                }
                catch { Console.WriteLine("Valor informado não é número!"); }
            }
        }
    }
}