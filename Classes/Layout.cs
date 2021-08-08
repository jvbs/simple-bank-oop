using System;
using System.Collections.Generic;

namespace SimpleBankOOP.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public static void TelaPrincipal()
        {
            // Console.BackgroundColor = ConsoleColor.DarkBlue;
            // Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.WriteLine("          === Simple Bank OOP ===              ");
            Console.WriteLine("                                               ");
            Console.WriteLine("          Digite a opção desejada:             ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          1 - Criar conta                      ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          2 - Entrar com CPF e Senha           ");
            Console.WriteLine("===============================================");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaCriarConta();
                    break;
                case 2:
                    TelaLogin();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }

        private static void TelaCriarConta()
        {
            Console.Clear();

            Console.WriteLine("          === Simple Bank OOP ===              ");
            Console.WriteLine("                                               ");
            Console.WriteLine("          Digite o seu nome:                   ");
            string nome = Console.ReadLine();

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite o seu CPF:                    ");
            string cpf = Console.ReadLine();

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite sua senha:                    ");
            string senha = Console.ReadLine();

            Console.WriteLine("===============================================");

            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();

            pessoa.SetNome(nome);
            pessoa.SetCpf(cpf);
            pessoa.SetSenha(senha);
            pessoa.Conta = contaCorrente;

            pessoas.Add(pessoa);

            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("          Conta criada com sucesso.            ");
            Console.WriteLine("===============================================");

        }

        private static void TelaLogin()
        {
            Console.Clear();

            Console.WriteLine("          === Simple Bank OOP ===              ");
            Console.WriteLine("                                               ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite o seu CPF:                    ");
            string cpf = Console.ReadLine();

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite sua senha:                    ");
            string senha = Console.ReadLine();

            Console.WriteLine("===============================================");
        }


    }
}