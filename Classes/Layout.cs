using System;

namespace SimpleBankOOP.Classes
{
    public class Layout
    {
        private static int opcao = 0;
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
                    Console.WriteLine("2");
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
        }
    }
}