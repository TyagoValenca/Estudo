using System;

namespace Exercicios
{
    public class Idade
    {
        public static void MaiorIdade()
        {
            Console.Clear();
            Console.WriteLine("Informe sua idade!");
            string idade = Console.ReadLine() ?? string.Empty;
            if (idade != string.Empty)
            {
                try
                {
                    if (int.Parse(idade) < 18) Console.WriteLine("Sem Permissão!");
                    else Console.WriteLine("Permissão concedida");
                }
                catch { Console.WriteLine("Valor informado não é número inteiro!"); }
            }
            else Console.WriteLine("A idade não foi informada");
        }
    }
}