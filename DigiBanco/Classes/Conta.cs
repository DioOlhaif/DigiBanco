using DigiBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigiBanco.Classes
{
    public abstract class Conta : Banco, IConta

    {
       
        public Conta()
        {
            this.NumeroAgencia = "0001";
            Conta.NumeroContaSequencial++;
            this.Limite = 1000; // Valor de crédito para todas as contas
        
        }

        public double Saldo { get; protected set; }
        public string NumeroAgencia { get; private set; }
        public string NumeroConta { get; protected set; }
        public static int NumeroContaSequencial { get; private set; }
        public double Limite { get; protected set; }

        public double ConsultaSaldo()
        {
            return this.Saldo + this.Limite;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }


        public bool Saca(double valor)
        {
            double saldo = this.ConsultaSaldo();

            if (valor > saldo)
            {
                Console.Clear();
                Console.WriteLine("                        Saldo Indisponível                ");
                Console.WriteLine("              ====================================        ");
                

                return false;
            }
          


                else
            {
                Console.Clear();
                Console.WriteLine("                 Operação Realizada com Sucesso!          ");
                Console.WriteLine("              ====================================        ");
                
                this.Saldo -= valor;
                return true;
                
            }

            
            

        }


        public string GetCodigoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

       
    }
}
