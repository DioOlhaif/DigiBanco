using DigiBanco.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DigiBanco.Classes
{
    public class Layout
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();
        private static int opcao = 0;
        

        
        public static void TelaPrincipal()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("                                                                                   ");
            Console.WriteLine("                   Digite a Opção Desejada:                                        ");
            Console.WriteLine("                 ================================                                  ");                                      
            Console.WriteLine("                 1 - Criar Conta                                                   ");
            Console.WriteLine("                 ================================                                  ");
            Console.WriteLine("                 2 - Entrar com CPF e Senha                                        "); 
            Console.WriteLine("                 ================================                                  ");

            opcao = int.Parse(Console.ReadLine());
        
        switch(opcao)
            {
                case 1:
                    TelaCriacao();
                    break;
                       
                case 2:
                    
                    TelaLogin();
                    break;
               
                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
        
                }
        private static void TelaCriacao()
        {
            Console.Clear();

            Console.WriteLine("                                                                                   ");
            Console.WriteLine("                         Criando Conta                                             ");
            Console.WriteLine("                 ================================                                  ");
            Console.WriteLine("                 Digite seu nome:                                                  ");
            string nome = Console.ReadLine();
            Console.WriteLine("                 ================================                                  ");
            Console.WriteLine("                 Digite seu CPF:                                                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 ================================                                  ");
            Console.WriteLine("                 Digite sua Senha                                                  ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 ================================                                  ");
            ContaCorrente contaCorrente = new ContaCorrente();
            Pessoa pessoa = new Pessoa();
            pessoa.DefinirNome(nome);
            pessoa.DefinirCPF(cpf);
            pessoa.DefinirSenha(senha);
            pessoa.Conta = contaCorrente;



             

            pessoas.Add(pessoa);

            Console.Clear();
            Console.WriteLine("         Conta Cadastrada com Sucesso.");
            Console.WriteLine("       ================================  ");
            // Aguarada um segundo para ir para a tela logada
            Thread.Sleep(1000);
            
            TelaLogada(pessoa);

            
        }

        private static void TelaLogin()
        {
            Console.WriteLine("                 Digite seu CPF:                                                   ");
            string cpf = Console.ReadLine();
            Console.WriteLine("                 ================================                                  ");
            Console.WriteLine("                 Digite sua Senha                                                  ");
            string senha = Console.ReadLine();
            Console.WriteLine("                 ================================                                  ");
            Pessoa pessoa = pessoas.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (pessoa != null)
            {
                TelaBoasVindas(pessoa);
                TelaLogada(pessoa);

            }

            else
            {
                Console.Clear();
                Console.WriteLine("                     Pessoa não Cadastrada"               );
                Console.WriteLine("                 ================================        ");

            }

            
        }
        private static void TelaBoasVindas(Pessoa pessoa)
        {
            string msgBemVindo =
                $"{pessoa.Nome}| Banco:{pessoa.Conta.GetCodigoBanco()}| " +
                $"Agência: {pessoa.Conta.GetNumeroAgencia()} | Conta: {pessoa.Conta.GetNumeroConta()}";
            Console.WriteLine("");
            Console.WriteLine($"                Bem vindo,{msgBemVindo}");
            Console.WriteLine("              =============================        ");


        }

        private static void TelaLogada(Pessoa pessoa)
        {
            Console.Clear();
            TelaBoasVindas(pessoa);

            Console.WriteLine("                Digite a Opção Desejada            ");
            Console.WriteLine("              =============================        ");
            Console.WriteLine("                1 Para Realizar um Depósito        ");
            Console.WriteLine("              =============================        ");
            Console.WriteLine("                2 Para Realizar um Saque           ");
            Console.WriteLine("              =============================        ");
            Console.WriteLine("                3 Consultar Saldo                  ");
            Console.WriteLine("              =============================        ");
            Console.WriteLine("                4 Listar Contas                    ");
            Console.WriteLine("              =============================        ");
            Console.WriteLine("                5 Sair                             ");
            Console.WriteLine("              =============================        ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:

                  
                    Console.Clear();

                    Console.WriteLine("              Informe o Valor que deseja Depositar        ");
                    Console.WriteLine("              ====================================        ");
                    double deposito = double.Parse(Console.ReadLine());

                    pessoa.Deposita(deposito);
                    Console.Clear();
                    Console.WriteLine("               Operação Realizada com Sucesso!            ");
                    Console.WriteLine("              ====================================        ");
                    Thread.Sleep(1000);
                    TelaLogada(pessoa);



                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("                 Informe o Valor que deseja sacar         ");
                    Console.WriteLine("              =====================================        ");
                    double saca = double.Parse(Console.ReadLine());
                    pessoa.Saca(saca);
                    


                    break;
                case 3:

                    Console.Clear();
                    Console.WriteLine($"             Saldo disponível:{pessoa.ConsultaSaldo()}");
                    Console.WriteLine("             ===========================================        ");
                    Thread.Sleep(1000);
                    TelaLogada(pessoa);

                    break;
                case 4:

                    ListaContas();
                    
                    break;
                case 5:
                    TelaPrincipal();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("                     Opção Invalida                ");
                    Console.WriteLine("              =============================        ");
                    break;

            }

          

        }
        private static void ListaContas()
        {
            Console.WriteLine("                      Listar Contas                ");
            Console.WriteLine("              =============================        ");
            if (pessoas.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("               Nenhuma Conta Cadastrada            ");
                Console.WriteLine("              =============================        ");


            }

            foreach (Pessoa p in pessoas)
            {
               
                
                Console.WriteLine($"{p.Nome}| CPF: {p.CPF}");
            
            }
        
        }



    }
}
