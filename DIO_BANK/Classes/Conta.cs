using DIO_BANK.Enum;
using System;

namespace DIO_BANK.Classes
{
    class Conta
    {
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		private string Nome { get; set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			TipoConta = tipoConta;
			Saldo = saldo;
			Credito = credito;
			Nome = nome;
		}

		public bool Sacar(double valorSaque)
		{
			// Validação de saldo suficiente
			if (Saldo - valorSaque < (Credito * -1))
			{
				Console.WriteLine("Saldo insuficiente!");
				return false;
			}
			Saldo -= valorSaque;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
			// https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

			return true;
		}

		public void Depositar(double valorDeposito)
		{
			Saldo += valorDeposito;

			Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (Sacar(valorTransferencia))
			{
				contaDestino.Depositar(valorTransferencia);
			}
		}

		public override string ToString()
		{
			string retorno = "";
			retorno += "TipoConta " + TipoConta + " | ";
			retorno += "Nome " + Nome + " | ";
			retorno += "Saldo " + Saldo + " | ";
			retorno += "Crédito " + Credito;
			return retorno;
		}
	}
}

