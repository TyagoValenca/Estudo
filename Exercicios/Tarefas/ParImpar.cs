using System;

namespace Exercicios
{
    public class ParImpar
    {
        public static void VerificarParImpar()
        {
            Console.Clear();
            Console.WriteLine("Informe um número inteiro!");
            string? numero = Console.ReadLine();

            if (numero != null)
            {
                int num = int.Parse(numero);
                if (num % 2 == 0)
                {
                    Console.WriteLine($"O número {num} é par!");
                }
                else
                {
                    Console.WriteLine($"O número {num} é impar!");
                }
            }
            else Console.WriteLine("Não foi informado nenhum valor!");
        }
    }
}