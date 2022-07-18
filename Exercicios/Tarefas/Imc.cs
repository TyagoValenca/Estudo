using System;

namespace Exercicios
{
    public class Imc
    {
        public static void Calcula()
        {
            Console.Clear();
            Console.WriteLine("Informe seu Nome!");
            var sNome = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Informe seu Peso em quilos!");
            var sPeso = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Informe sua Altura em metros!");
            var sAltura = Console.ReadLine() ?? string.Empty;

            if (sNome == string.Empty || sPeso == string.Empty || sAltura == string.Empty) Console.WriteLine("Algum valor não foi informado!");
            else
            {
                try
                {
                    decimal peso = decimal.Parse(sPeso);
                    decimal altura = decimal.Parse(sAltura);
                    decimal imc = peso / (altura * altura);
                    string mensagem = string.Empty;
                    switch (imc)
                    {
                        case < 18.5m: mensagem = "Abaixo do peso"; break;
                        case < 24.9m: mensagem = "Peso normal"; break;
                        case < 29.9m: mensagem = "Acima do peso (sobrepeso)"; break;
                        case < 34.9m: mensagem = "Obesidade I"; break;
                        case < 39.9m: mensagem = "Obesidade II"; break;
                        default: mensagem = "Obesidade III"; break;

                    }
                    string texto = $"{sNome} mede {altura} m e pesa {peso} Kg. Com isso tem um IMC de {imc.ToString("F")}, o que lhe classifica como {mensagem}";
                    Console.WriteLine(texto);

                    //Salva no arquivo
                    //using (var file = new StreamWriter(@".\BD.txt")) file.Write(texto);
                    using (StreamWriter sw = File.AppendText(@".\BD\IMC.txt"))
                        sw.WriteLine(texto);
                }
                catch { Console.WriteLine("Algum valor informado não é numérico!"); }
            }
        }
    }
}