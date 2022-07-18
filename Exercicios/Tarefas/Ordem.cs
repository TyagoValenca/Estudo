using System;

namespace Exercicios
{
    public class Ordem
    {
        public static void Menu()
        {
            Console.WriteLine(@"Selecione uma operação:
    1 - Cadastrar
    2 - Visualizar
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
                        case 1: Cadastrar(); break;
                        case 2: Visualizar(); break;
                        case 9: Console.Clear(); break;
                        case 0: return;
                        default: Console.WriteLine("Nenhuma opção válida foi informada!"); break;
                    }
                }
                catch { Console.WriteLine("Informe um valor numérico!"); }
            }
            Menu();

        }

        private static void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("Informe o nome!");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Informe a altura em metros!");
            string altura = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Informe peso em Kg!");
            string peso = Console.ReadLine() ?? string.Empty;
            if (nome == string.Empty || altura == string.Empty || peso == string.Empty) Console.WriteLine("Algum valor não foi informado!");
            else
            {
                Dados dado = new Dados(nome, altura, peso);
                Dictionary<string, Dados> bd = LerBD();
                if (bd.ContainsKey(dado.nome))
                {
                    bd[dado.nome] = dado;
                    Console.WriteLine("Altera");
                }
                else
                {
                    bd.Add(dado.nome, dado);
                    Console.WriteLine("Novo");
                }
                SalvarBD(bd);
            }
        }

        private static void Visualizar()
        {
            Dictionary<string, Dados> bd = LerBD();
            List<string> nomes = bd.Keys.ToList();
            nomes.Sort();

            foreach (string nome in nomes)
            {
                Console.WriteLine($"Os dados de {bd[nome].nome} são: altura {bd[nome].altura}m, peso de : {bd[nome].peso}kg, o que dá uma IMC de {bd[nome].imc}.");
            }
        }
        private static Dictionary<string, Dados> LerBD()
        {
            Dictionary<string, Dados> bd = new Dictionary<string, Dados>();
            using (var file = new StreamReader(@".\BD\Ordem.txt"))
            {
                string arquivo = file.ReadToEnd();
                foreach (string linha in arquivo.Split('\n'))
                {
                    if (linha.Trim() != string.Empty)
                    {
                        Dados dado = new Dados(linha.Split("|")[0], linha.Split("|")[1], linha.Split("|")[2]);
                        bd.Add(dado.nome, dado);
                    }
                }
            }
            return bd;
        }
        private static void SalvarBD(Dictionary<string, Dados> bd)
        {
            string dados = string.Empty;
            foreach (Dados dado in bd.Values)
            {
                dados += dado.nome + "|" + dado.altura + "|" + dado.peso + "\n";
            }
            dados = dados.TrimEnd('\n');
            Console.WriteLine(dados);
            File.Delete(@".\BD\Ordem.txt");
            using (StreamWriter sw = File.AppendText(@".\BD\Ordem.txt"))
                sw.WriteLine(dados);

        }

        struct Dados
        {
            public string nome;
            public decimal altura;
            public decimal peso;
            public decimal imc;
            public Dados(string pNome, string pAltura, string pPeso)
            {
                if (pNome == null || pNome == string.Empty) throw new ArgumentException("Nome inválido");
                else nome = pNome;
                if (pAltura == null || pAltura == string.Empty) throw new ArgumentException("Altura inválida");
                else
                {
                    try { altura = decimal.Parse(pAltura); }
                    catch { throw new ArgumentException("Altura inválida"); }
                }
                if (pPeso == null || pPeso == string.Empty) throw new ArgumentException("Peso inválido");
                else
                {
                    try { peso = decimal.Parse(pPeso); }
                    catch { throw new ArgumentException("Peso inválido"); }
                }
                imc = peso / (altura * altura);
            }
        }
    }
}