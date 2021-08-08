using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SimpleBankOOP.Classes
{
    public class Layout
    {
        private static int opcao = 0;
        private static List<Pessoa> pessoas = new List<Pessoa>();
        public static void TelaPrincipal()
        {

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

            Thread.Sleep(1000);

            TelaContaLogada(pessoa);

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

            Pessoa pessoa = pessoas.FirstOrDefault(
                pessoa => pessoa.CPF == cpf && pessoa.Senha == senha
            );

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaContaLogada(pessoa);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("===============================================");
                Console.WriteLine("          Pessoa não cadastrada.               ");
                Console.WriteLine("===============================================");
            }
        }

        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgTelaBemVindo =
                $"{pessoa.Nome} | " +
                $"Banco: {pessoa.Conta.GetCodigoBanco()} | " +
                $"Agência: {pessoa.Conta.GetAgencia()} | " +
                $"Conta: {pessoa.Conta.GetConta()}";


            Console.WriteLine($"Seja bem-vindo(a), {msgTelaBemVindo}");
        }

        private static void TelaContaLogada(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite a opção desejada.             ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          1 - Realizar um depósito.            ");
            Console.WriteLine("          2 - Realizar um saque.               ");
            Console.WriteLine("          3 - Consultar saldo.                 ");
            Console.WriteLine("          4 - Extrato.                         ");
            Console.WriteLine("          5 - Sair.                            ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    TelaPrincipal();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("===============================================");
                    Console.WriteLine("          Opção inválida.                      ");
                    Console.WriteLine("===============================================");
                    break;
            }


        }

    }
}