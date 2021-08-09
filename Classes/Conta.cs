using System;
using System.Collections.Generic;
using SimpleBankOOP.Interfaces;

namespace SimpleBankOOP.Classes
{
    public abstract class Conta : Banco, IConta
    {
        public Conta()
        {
            this.Agencia = "0001";
            NumeroContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }
        public string Agencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroContaSequencial { get; private set; }
        private List<Extrato> Movimentacoes;

        public double ConsultarSaldo()
        {
            return this.Saldo;
        }

        public void Depositar(double valor)
        {
            this.Movimentacoes.Add(new Extrato(DateTime.Now, "Depósito", valor));
            this.Saldo += valor;
        }

        public bool Sacar(double valor)
        {
            if (valor > this.ConsultarSaldo())
            {
                return false;
            }

            this.Movimentacoes.Add(new Extrato(DateTime.Now, "Saque", -valor));

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

        public List<Extrato> Extrato()
        {
            return this.Movimentacoes;
        }
    }
}