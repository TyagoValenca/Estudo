using System;

namespace Exercicios
{
    public class Nome
    {
        public static void FormaNome()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu Primeiro Nome!");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Informe o seu Segundo Nome!");
            string sobreNome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Seu nome completo é: {nome} {sobreNome}!");
        }

        public static void MeuNome()
        {
            Console.Clear();
            Console.WriteLine("Informe o seu nome!");
            string nome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine($"Olá meu nome é: {nome}.");
        }
    }
}