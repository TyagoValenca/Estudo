using System;

namespace Exercicios
{
    public static class Cadastro
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
            Console.WriteLine("Informe o CPF!");
            string cpf = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Informe o nome!");
            string nome = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Informe o telefone!");
            string telefone = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Informe o e-mail!");
            string email = Console.ReadLine() ?? string.Empty;
            if (cpf == string.Empty || nome == string.Empty || telefone == string.Empty || email == string.Empty) Console.WriteLine("Algum valor não foi informado!");
            else
            {
                Dados dado = new Dados(cpf, nome, telefone, email);
                Dictionary<string, Dados> bd = LerBD();
                if (bd.ContainsKey(dado.cpf))
                {
                    bd[dado.cpf] = dado;
                    Console.WriteLine("Altera");
                }
                else
                {
                    bd.Add(dado.cpf, dado);
                    Console.WriteLine("Novo");
                }
                SalvarBD(bd);
            }
        }

        private static void Visualizar()
        {
            /*using (var file = new StreamReader(@".\BD_Cadastro.txt"))
            {
                string arquivo = file.ReadToEnd();
                foreach (string linha in arquivo.Split('\n'))
                {
                    Dados dado = new Dados(linha.Split("|")[0], linha.Split("|")[1], linha.Split("|")[2], linha.Split("|")[3]);
                    Console.WriteLine($"Os dados do registro são CPF: {dado.cpf}, Nome: {dado.nome}, telefone: {dado.telefone} e e-mail: {dado.email}.");
                }
            }*/

            Dictionary<string, Dados> bd = LerBD();
            foreach (Dados dado in bd.Values)
            {
                Console.WriteLine($"Os dados do registro são CPF: {dado.cpf}, Nome: {dado.nome}, telefone: {dado.telefone} e e-mail: {dado.email}.");
            }
        }

        private static Dictionary<string, Dados> LerBD()
        {
            Dictionary<string, Dados> bd = new Dictionary<string, Dados>();
            using (var file = new StreamReader(@".\BD\Cadastro.txt"))
            {
                string arquivo = file.ReadToEnd();
                foreach (string linha in arquivo.Split('\n'))
                {
                    if (linha.Trim() != string.Empty)
                    {
                        Dados dado = new Dados(linha.Split("|")[0], linha.Split("|")[1], linha.Split("|")[2], linha.Split("|")[3]);
                        bd.Add(dado.cpf, dado);
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
                dados += dado.cpf + "|" + dado.nome + "|" + dado.telefone + "|" + dado.email + "\n";
            }
            dados = dados.TrimEnd('\n');
            Console.WriteLine(dados);
            File.Delete(@".\BD\Cadastro.txt");
            using (StreamWriter sw = File.AppendText(@".\BD\Cadastro.txt"))
                sw.WriteLine(dados);

        }

    }

    struct Dados
    {
        public string cpf;
        public string nome;
        public string telefone;
        public string email;
        public Dados(string pCpf, string pNome, string pTelefone, string pEmail)
        {
            if (pCpf == null || pCpf == string.Empty) throw new ArgumentException("CPF inválido");
            else cpf = pCpf;
            if (pNome == null || pNome == string.Empty) throw new ArgumentException("Nome inválido");
            else nome = pNome;
            if (pTelefone == null || pTelefone == string.Empty) throw new ArgumentException("Telefone inválido");
            else telefone = pTelefone;
            if (pEmail == null || pEmail == string.Empty) throw new ArgumentException("Email inválido");
            else email = pEmail;
        }
    }
}