using System;
using System.IO;
using System.Text;

namespace ProjBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();

        }

        static void Menu()
        {
            int opc;
            do
            {

                Console.WriteLine("\n\n\t°°°°°°°°°°° BEM VINDO AO BANCO DO MORANGÃO °°°°°°°°°°°");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("\t|°°°°°°°°°°°°°°°°°°°°°°  MENU  °°°°°°°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("\t|                                                      |");
                Console.WriteLine("\t|   opção 1 : Não sou cliente                          |");
                Console.WriteLine("\t|   opção 2 : Já sou cliente                           |");
                Console.WriteLine("\t|   opção 3 : Acesso a funcionários                    |");
                Console.WriteLine("\t|                                                      |");
                Console.WriteLine("\t|   opção 0 : Sair                                     |");
                Console.WriteLine("\t|______________________________________________________|");

                opc = int.Parse(Console.ReadLine());

                switch (opc)
                {
                    case 1:
                        char opcao;
                        Console.Write("\tDeseja se cadastrar? [S/N]: ");
                        opcao = char.Parse(Console.ReadLine().ToLower().Trim());
                        if (opcao == 's')
                        {
                            ClienteNovo();
                        }
                        break;

                    case 2:
                        Console.Write("\tInforme [1] - Operações de conta [2] - Retornar ao menu: ");
                        opc = char.Parse(Console.ReadLine());
                        Console.Clear();
                        if (opc == '1')
                        {
                            Conta();
                        }
                        break;

                    case 3:
                        int opfunc;
                        Console.Write("\tInforme [1] - Atendente [2] - Gerente: ");
                        opfunc = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.Write("\tDigite o Número da agência[1 - Zona Norte / 2 - Zona Leste / 3 - Zona Sul]: ");
                        string ag = Console.ReadLine();
                        new Agencia(ag, opfunc);
                        Console.WriteLine("\tPressione Enter para continuar!!");
                        Console.ReadKey();
                        Console.Clear();
                        /*
                        if (opfunc == 1)
                        {
                            Atendente atendente = new Atendente();
                            atendente.AcessoAtendente();
                            Console.ReadKey();

                            atendente.AbreConta();
                            Console.ReadKey();

                        }
                        else if (opfunc == 2)
                        {
                            Gerente gerente = new Gerente();
                            bool senha;
                            do
                            {
                                Console.WriteLine("\t°°°°°°°   ACESSO ADMINISTRATIVO RESPONSÁVEL   °°°°°°°°");
                                Console.WriteLine("\tDigite sua senha de acesso: ");
                                int acesso = int.Parse(Console.ReadLine());
                                senha = gerente.Autentica(acesso);
                            } while (!senha);

                            gerente.AprovaConta();
                            Console.ReadKey();
                        }
                        */
                        break;
                }

            } while (opc != 0);
            Console.WriteLine("\tFIM");
        }

        static void ClienteNovo()
        {
            int opc = 0;

            Console.WriteLine("\n\tFicamos felizes por você nos escolher!");
            Console.WriteLine("\n\tDigite: [1]  para Pessoa Fisíca e [2] para Pessoa Jurídica");
            opc = int.Parse(Console.ReadLine());
            Console.Clear();

            if (opc == 1)
            {
                Console.WriteLine("\t°°°°°°°°°°°°°°  CADASTRO PESSOA FÍSICA  °°°°°°°°°°°°°°°°");
                ClientePF pessoapf = new ClientePF();
                pessoapf.SolicitarAberturaPF();
                Console.WriteLine("\t--------------------------------------------------------");
                Console.WriteLine("\t|           CADASTRO REALIZADO COM SUCESSO             |");
                Console.WriteLine("\t|                APROVAÇÃO EM ANÁLISE                  |");
                Console.WriteLine("\t|         O ATENDENTE IRÁ CRIAR SUA CONTA EM BREVE     |");
                Console.WriteLine("\t|         PRESSIONE ENTER PARA VOLTAR AO MENU          |");
                Console.WriteLine("\t|______________________________________________________|");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\t°°°°°°°°°°°°°  CADASTRO PESSOA JURÍDICA °°°°°°°°°°°°°°°°");
                ClientePJ pessoapj = new ClientePJ();
                pessoapj.SolicitarAberturaPJ();
                Console.WriteLine("\t--------------------------------------------------------");
                Console.WriteLine("\t|           CADASTRO REALIZADO COM SUCESSO             |");
                Console.WriteLine("\t|                APROVAÇÃO EM ANÁLISE                  |");
                Console.WriteLine("\t|         O ATENDENTE IRÁ CRIAR SUA CONTA EM BREVE     |");
                Console.WriteLine("\t|         PRESSIONE ENTER PARA VOLTAR AO MENU          |");
                Console.WriteLine("\t|______________________________________________________|");
                Console.ReadKey();
                Console.Clear();

                Menu();
            }

        }

        static void Conta()
        {
            try
            {
                Console.Write("\tInforme o seu CPF ou CNPJ: ");
                string cpfCnpj = Console.ReadLine();

                string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                string[] dados = new string[18];

                foreach (string dado in solicita)
                    dados = dado.Split(';');
                Console.WriteLine(dados[16]);

                if (dados[16].Contains("Normal")) //ele vai procurar no meu arquivo se tem conta normal
                {
                    ContaNormal conta = new ContaNormal(cpfCnpj);
                    conta.OpCaixaEletronica();
                }
                else if (dados[16].Contains("VIP"))
                {
                    ContaVIP conta = new ContaVIP(cpfCnpj);
                    conta.OpCaixaEletronica();
                }
                else if (dados[16].Contains("Universitária"))
                {
                    CCUniversitaria conta = new CCUniversitaria(cpfCnpj);
                    conta.OpCaixaEletronica();
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\tConta não encontrada.\nErro: {e.Message}");
            }
            //forech é para cada item
        }

        
    }
}

