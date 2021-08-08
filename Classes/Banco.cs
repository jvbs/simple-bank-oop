namespace SimpleBankOOP.Classes
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeBanco = "Simple Bank OOP";
            this.CodigoDoBanco = "001";
        }

        public string NomeBanco { get; private set; }
        public string CodigoDoBanco { get; private set; }
    }
}