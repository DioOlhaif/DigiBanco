using DigiBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBanco.Classes
{
    public  class Pessoa : Conta
    {
        
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }
        public IConta Conta { get; set; }
        public void DefinirNome(string nome)
        {
            this.Nome=nome;
        }

        public void DefinirCPF(string cpf)
        {
            this.CPF = cpf;
        }

        public void DefinirSenha(string senha)
        {
            this.Senha = senha;
        }

      
    }
}
