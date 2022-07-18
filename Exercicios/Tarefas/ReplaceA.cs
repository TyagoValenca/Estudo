using System;

namespace Exercicios
{
    public class ReplaceA
    {
        public static void Alterar()
        {
            //Prepara o Console
            Console.Clear();
            Console.WriteLine("Digite a frase desejada!");

            //Define e inicializa as variáveis
            string frase = Console.ReadLine() ?? string.Empty;
            string novaFrase = string.Empty;
            int numTrocas = 0;
            var meuArray = new char[2] { 'A', 'a' };

            //Verifica se foi digitado algum valor
            if (frase == string.Empty) Console.WriteLine("Nenhuma frase foi digitada!");
            else
            {
                //Percorre todos os caracteres da frase
                for (int i = 0; i < frase.Length; i++)
                {
                    //if (frase[i] == 'A' || frase[i] == 'a')
                    if (meuArray.Contains(frase[i]))//Se for igual a algum valor do array, muda
                    {
                        novaFrase += "&";
                        numTrocas++;
                    }
                    else novaFrase += frase[i];
                }
                Console.WriteLine($"Foram realizadas {numTrocas} troca na frase inicial, ficando o o valor abaixo:\n{novaFrase}");
            }

        }
    }
}