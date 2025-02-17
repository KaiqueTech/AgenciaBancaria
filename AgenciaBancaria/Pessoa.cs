using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgenciaBancaria {
    public class Pessoa {

        private static int counter = 1;

        private string _nome;
        private string _cpf;
        private string _email;


        public string GetNome() {
            return _nome;
        }

        public void SetNome(string nome) {
            _nome = nome;
        }

        public string GetCPf() {
            return _cpf;
        }

        public void SetCpf(string cpf) {
            _cpf = cpf;
        }

        public string GetEmail() {
            return _email;
        }

        public void SetEmail(string email) {
            _email = email;
        }

        public override string ToString() {
            return "\nNome: " + GetNome() +
                   "\nCPF: " + GetCPf() +
                   "\nEmail: " + GetEmail();
        }
    }
}
