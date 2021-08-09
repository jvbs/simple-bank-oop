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
            Console.WriteLine("===============================================");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    TelaDeposito(pessoa);
                    break;
                case 2:
                    TelaSaque(pessoa);
                    break;
                case 3:
                    TelaSaldo(pessoa);
                    break;
                case 4:
                    TelaExtrato(pessoa);
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

        private static void TelaDeposito(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite o valor do depósito.          ");
            Console.WriteLine("===============================================");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("===============================================");

            pessoa.Conta.Depositar(valor);
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            Console.WriteLine("          Depósito realizado com sucesso.      ");
            Console.WriteLine("===============================================");

            OpcaoVoltarLogado(pessoa);
        }
        private static void TelaSaque(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            Console.WriteLine("          Digite o valor do saque.             ");
            Console.WriteLine("===============================================");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("===============================================");

            bool saque = pessoa.Conta.Sacar(valor);
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            if (saque)
            {

                Console.WriteLine("          Saque realizado com sucesso.         ");
            }
            else
            {
                Console.WriteLine("          Saque insuficiente.                  ");
            }
            Console.WriteLine("===============================================");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaSaldo(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            Console.WriteLine("===============================================");
            Console.WriteLine($" Seu saldo é: {pessoa.Conta.ConsultarSaldo()}.");
            Console.WriteLine("===============================================");

            OpcaoVoltarLogado(pessoa);
        }

        private static void TelaExtrato(Pessoa pessoa)
        {
            Console.Clear();

            TelaBoasVindas(pessoa);

            if (pessoa.Conta.Extrato().Any())
            {
                double total = pessoa.Conta.Extrato().Sum(x => x.Valor);

                foreach (Extrato extrato in pessoa.Conta.Extrato())
                {
                    Console.WriteLine($"===================================================");
                    Console.WriteLine($"     Data Movimentação: {extrato.Data.ToString("dd/MM/yyyy HH:mm:ss")}");
                    Console.WriteLine($"     Tipo de Movimentação: {extrato.Descricao}");
                    Console.WriteLine($"     Valor: {extrato.Valor}");
                }

                Console.WriteLine("===============================================");
                Console.WriteLine($"         Sub Total: {total}.                  ");
                Console.WriteLine("===============================================");

            }
            else
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("          Não há extrato para ser exibido.     ");
                Console.WriteLine("===============================================");
            }

            OpcaoVoltarLogado(pessoa);
        }

        private static void OpcaoVoltarLogado(Pessoa pessoa)
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("          Seleciona uma opção abaixo.          ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          1 - Voltar para minha conta.         ");
            Console.WriteLine("          2 - Sair.                            ");
            Console.WriteLine("===============================================");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                TelaContaLogada(pessoa);
            }
            else
            {
                TelaPrincipal();
            }
        }
        private static void OpcaoVoltarDeslogado()
        {
            Console.WriteLine("===============================================");
            Console.WriteLine("          Seleciona uma opção abaixo.          ");
            Console.WriteLine("===============================================");
            Console.WriteLine("          1 - Voltar para menu principal.      ");
            Console.WriteLine("          2 - Sair.                            ");
            Console.WriteLine("===============================================");

            opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                TelaPrincipal();
            }
            else
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("          Opção inválida.                      ");
                Console.WriteLine("===============================================");
            }
        }

    }
}