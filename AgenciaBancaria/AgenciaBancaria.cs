using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AgenciaBancaria
{
    public class AgenciaBancaria
    {
        static List<Conta> contasBancarias = new List<Conta>();

        public static void Main(string[] args)
        {
            operacoes();
        }

        public static void operacoes()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("-------------Bem vindos a nossa Agência---------------");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("***** Selecione uma operação que deseja realizar *****");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("|   Opção 1 - Criar conta   |");
            Console.WriteLine("|   Opção 2 - Depositar     |");
            Console.WriteLine("|   Opção 3 - Sacar         |");
            Console.WriteLine("|   Opção 4 - Transferir    |");
            Console.WriteLine("|   Opção 5 - Listar        |");
            Console.WriteLine("|   Opção 6 - Sair          |");

            int operacao = int.Parse(Console.ReadLine());

            switch (operacao)
            {
                case 1:
                    CriarConta();
                    break;
                case 2:
                    Depositar();
                    break;
                case 3:
                    Sacar();
                    break;
                case 4:
                    Transferir();
                    break;
                case 5:
                    ListarContas();
                    break;
                case 6:
                    Console.WriteLine("Obrigado por usar nossa agência! Volte sempre.");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Por favor, insira um número válido.");
                    operacoes();
                    break;
            }
        }

        public static void CriarConta()
        {

            Console.WriteLine("\nNome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nCPF: ");
            string cpf = Console.ReadLine();

            Console.Write("\nEmail: ");
            string email = Console.ReadLine();

            Pessoa pessoa = new Pessoa();
            pessoa.SetNome(nome);
            pessoa.SetCpf(cpf);
            pessoa.SetEmail(email);

            Conta conta = new Conta(pessoa);

            contasBancarias.Add(conta);

            Console.Write("Sua conta foi criada com sucesso!");

            operacoes();
        }

        private static Conta EncontrarConta(int numeroConta)
        {
            Conta conta = null;
            if (contasBancarias.Count() > 0)
            {
                foreach (Conta c in contasBancarias)
                {
                    if (c.GetNumeroConta() == numeroConta)
                    {
                        conta = c;
                    }
                }
            }
            return conta;
        }

        public static void Depositar()
        {
            Console.Write("Número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta conta = EncontrarConta(numeroConta);

            if (conta != null)
            {
                Console.Write("Qual valor deseja depositar? ");
                double valorDeposito = double.Parse(Console.ReadLine());
                conta.Depositar(valorDeposito);
                Console.WriteLine("Valor depositado com sucesso!");
            }
            else
            {
                Console.WriteLine(" Conta não encontrada!");
            }

            Console.Write("Deseja voltar ao menu inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                operacoes();
            }
            else if (resp == 'n' || resp == 'N')
            {
                Console.WriteLine("Obrigado por usar nossa agência! Volte sempre.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Por favor, insira uma opção válida.");
                Environment.Exit(0);
            }
        }

        public static void Sacar()
        {
            Console.Write("Número da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            Conta conta = EncontrarConta(numeroConta);

            if (conta != null)
            {
                Console.WriteLine("Qual valor deseja sacar? ");
                double valorSaque = double.Parse(Console.ReadLine());
                conta.Sacar(valorSaque);
            }
            else
            {
                Console.WriteLine("Conta não encontrada! ");
            }

            Console.Write("Deseja voltar ao menu inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                operacoes();
            }
            else if (resp == 'n' || resp == 'N')
            {
                Console.WriteLine("Obrigado por usar nossa agência! Volte sempre.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Por favor, insira uma opção válida.");
                Environment.Exit(0);
            }
        }

        public static void Transferir()
        {
            Console.Write("Número da conta do remetente: ");
            int numeroContaRemetente = int.Parse(Console.ReadLine());

            Conta contaRemetente = EncontrarConta(numeroContaRemetente);

            if (contaRemetente != null)
            {
                Console.WriteLine();

                Console.Write("Número da conta do destinatário: ");
                int numeroContaDestinatario = int.Parse(Console.ReadLine());

                Conta contaDestinatario = EncontrarConta(numeroContaDestinatario);

                if (contaDestinatario != null)
                {
                    Console.Write("Valor da transferência: ");
                    double valorTransferencia = double.Parse(Console.ReadLine());

                    contaRemetente.Tranferencia(contaDestinatario, valorTransferencia);
                }
                else
                {
                    Console.WriteLine("A conta para depósito não foi encontrada");
                }
            }
            else
            {
                Console.WriteLine("Conta para transferência não encontada");
            }

            Console.Write("Deseja voltar ao menu inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                operacoes();
            }
            else if (resp == 'n' || resp == 'N')
            {
                Console.WriteLine("Obrigado por usar nossa agência! Volte sempre.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Por favor, insira uma opção válida.");
                Environment.Exit(0);
            }
        }

        public static void ListarContas()
        {
            if (contasBancarias.Count() > 0)
            {
                foreach (Conta conta in contasBancarias)
                {
                    Console.WriteLine(conta);
                }
            }
            else
            {
                Console.WriteLine("Não há contas cadastradas");
            }

            Console.Write("Deseja voltar ao menu inicial (s/n)? ");
            char resp = char.Parse(Console.ReadLine());
            if (resp == 's' || resp == 'S')
            {
                operacoes();
            }
            else if (resp == 'n' || resp == 'N')
            {
                Console.WriteLine("Obrigado por usar nossa agência! Volte sempre.");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Por favor, insira uma opção válida.");
                Environment.Exit(0);
            }
        }
    }
}
