using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace AgenciaBancaria {
    internal class Conta {

        private static int contadorDeContas = 1;

        private int _numeroConta;
        private Pessoa _pessoa;
        private double _saldo = 0.0;



        public Conta(Pessoa pessoa) {
            _numeroConta = contadorDeContas;
            _pessoa = pessoa;
            contadorDeContas += 1;
        }

        public int GetNumeroConta() { 
            return _numeroConta;
        }

        public void SetNumeroConta(int numeroConta) {
            _numeroConta = numeroConta;
        }

        public Pessoa GetPessoa() {
            return _pessoa;
        }

        public void SetPessoa(Pessoa pessoa) {
            _pessoa = pessoa;
        }

        public double GetSaldo() {
            return _saldo;
        }

        public void SetSaldo(double saldo) {
            _saldo = saldo;
        }

        public override string ToString() {
            return "\nNúmero da conta: " + GetNumeroConta() +
                   "\nNome: " + _pessoa.GetNome() +
                   "\nCPF: " + _pessoa.GetCPf() +
                   "\nEmail: " + _pessoa.GetEmail() +
                   "\nSaldo: " + Utils.Utils.doubleToString(GetSaldo()) + 
                   "\n";
        }

        public void Depositar(double valor) {
            if (valor > 0) {
                SetSaldo(GetSaldo() + valor);
                Console.WriteLine("Deposito realizado com sucesso!");
            }
            else {
                Console.WriteLine("Não foi possivel realizar o deposito!");
            }
        }

        public void Sacar(double valor) {
            if (valor > 0 && GetSaldo() >= valor ) {
                SetSaldo(GetSaldo() - valor);
                Console.WriteLine("Saque realizado com sucesso!");
            }
            else {
                Console.WriteLine("Não foi possivel realizar o saque");
            }
        }

        public void Tranferencia(Conta contaDeposito, double valor) {
            if (valor > 0 && GetSaldo() >= valor) {
                SetSaldo(GetSaldo() - valor);
                contaDeposito._saldo = contaDeposito.GetSaldo() + valor;
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            else {
                Console.WriteLine("Não foi possivel realizar a transferência!");
            }
        }
    }
}
