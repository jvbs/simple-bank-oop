namespace SimpleBankOOP.Interfaces
{
    public interface IConta
    {
        void Depositar(double valor);
        bool Sacar(double valor);
        double ConsultarSaldo();
        string GetCodigoBanco();
        string GetAgencia();
        string GetConta();

    }
}