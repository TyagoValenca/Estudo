using System;

namespace Exercicios
{
    public class Calculadora
    {
        public static void Menu()
        {
            Console.WriteLine(@"Selecione uma operação:
    1 - Soma
    2 - Subtração
    3 - Multiplicação
    4 - Divisão
    9 - Limpar histórico
    0 - Sair");
            var opcao = Console.ReadLine() ?? string.Empty;
            if (opcao == string.Empty) Console.WriteLine("Nenhum valor foi informado!");
            else
            {
                try
                {
                    int operacao = int.Parse(opcao);
                    switch (operacao)
                    {
                        case 1:
                        case 2:
                        case 3:
                        case 4: Calculo(operacao); break;
                        case 9: Console.Clear(); break;
                        case 0: return;
                        default: Console.WriteLine("Nenhuma opção válida foi informada!"); break;
                    }

                }
                catch { Console.WriteLine("Informe um valor numérico!"); }
            }
            Menu();
        }

        private static void Calculo(int operacao)
        {
            Console.WriteLine("Informe o primeiro valor!");
            var primeiro = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Informe o segundo valor!");
            var segundo = Console.ReadLine() ?? string.Empty;

            if (primeiro == string.Empty || segundo == string.Empty) Console.WriteLine("Faltou informar algum valor!");
            else
            {
                try
                {
                    int num1 = int.Parse(primeiro);
                    int num2 = int.Parse(segundo);
                    switch (operacao)
                    {
                        case 1: Console.WriteLine($"O resultado da soma de {primeiro} com {segundo} é igual a: {num1 + num2}"); break;
                        case 2: Console.WriteLine($"O resultado da subtração de {primeiro} com {segundo} é igual a: {num1 - num2}"); break;
                        case 3: Console.WriteLine($"O resultado da multiplicação de {primeiro} com {segundo} é igual a: {num1 * num2}"); break;
                        case 4: Console.WriteLine($"O resultado da divisão de {primeiro} com {segundo} é igual a: {num1 / num2}"); break;
                    }
                }
                catch { Console.WriteLine("Informe valores numéricos!"); }
            }
        }
    }
}