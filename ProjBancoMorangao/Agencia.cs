using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Agencia 
    {
        public string NumAgencia { get; set; }
        public Endereco Endereco { get; set; }
        public Atendente Atendente { get; set; }
        public Gerente Gerente { get; set; }

        public Agencia(string numAgencia, int funcionario)
        {
            this.NumAgencia = numAgencia;

            if(numAgencia == "1")
            {
                if(funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Vinicius";
                    Console.WriteLine($"\n\tBem vindo atendente {Atendente.Nome}!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Thalya";
                    Gerente.Senha = 666;
                    Console.WriteLine($"\n\tGerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("\tAcesso liberado!");
                        Console.WriteLine("\t[1] - Aprova Conta [2] - Aprova Empréstimo");
                        string opcao = Console.ReadLine();
                        if(opcao == "1")
                        {
                            Gerente.AprovaConta();
                        }
                        else
                        {
                            Gerente.AprovaEmprestimo();
                        }
                    }
                }
            }

            if(numAgencia == "2")
            {
                if(funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Weslen";
                    Console.WriteLine($"\n\tBem vindo atendente {Atendente.Nome}!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Louise";
                    Gerente.Senha = 666;
                    Console.WriteLine($"\n\tGerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("\tAcesso liberado!");
                        Console.WriteLine("\t[1] - Aprova Conta [2] - Aprova Empréstimo");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            Gerente.AprovaConta();
                        }
                        else
                        {
                            Gerente.AprovaEmprestimo();
                        }
                    }
                }
            }

            if(numAgencia == "3")
            {
                if (funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Papini";
                    Console.WriteLine($"\n\tBem vindo atendente {Atendente.Nome}!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Pestana";
                    Gerente.Senha = 666;
                    Console.WriteLine($"\n\tGerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("\tAcesso liberado!");
                        Console.WriteLine("\t[1] - Aprova Conta [2] - Aprova Empréstimo");
                        string opcao = Console.ReadLine();
                        if (opcao == "1")
                        {
                            Gerente.AprovaConta();
                        }
                        else
                        {
                            Gerente.AprovaEmprestimo();
                        }
                    }
                }
            }
        }

    }
}
