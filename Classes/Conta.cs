using SimpleBankOOP.Interfaces;

namespace SimpleBankOOP.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.NumeroConta = "0001";
            NumeroContaSequencial++;
        }

        public double Saldo { get; protected set; }
        public string Agencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroContaSequencial { get; private set; }
        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Depositar(double valor)
        {
            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor > this.ConsultarSaldo())
            {
                return false;
            }

            this.Saldo -= valor;
            return true;
        }

        public string GetAgencia()
        {
            return this.Agencia;
        }

        public string GetCodigoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetConta()
        {
            return this.NumeroConta;
        }
    }
}