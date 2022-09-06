using System;

namespace ProjBancoMorangao
{
    internal class Program
    {
        /*
        static void Menu()
        {
            do
            {
                Console.WriteLine("\n\tDENTRE AS OPÇÕES NO MENU, QUAL DESEJA EXECUTAR?\n");
                Console.WriteLine("\t|°°°°°°°°°°°°°°°°°°°°°°  MENU  °°°°°°°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("\t|                                                      |");
                Console.WriteLine("\t|   opção 1 : Cadastrar Pessoa Fisícia                 |");
                Console.WriteLine("\t|   opção 2 : Cadastrar Pessoa Jurídic                 |");
                Console.WriteLine("\t|   opção 3 : Solicitar Conta                          |");
                Console.WriteLine("\t|   opção 4 : Solicitar Conta                          |");
                Console.WriteLine("\t|   opção 5 : Solicitar Conta                          |");
                Console.WriteLine("\t|   opção 5 : Solicitar Conta                          |");
                Console.WriteLine("\t|   opção 5 : Solicitar Conta                          |");
                Console.WriteLine("\t|______________________________________________________|");
                Console.Clear();
                Console.WriteLine(">>>>> MENU <<<<<");
                Console.WriteLine("1- Cadastrar Pessoa Fisíca");
                Console.WriteLine("2- Cadastrar Pessoa Jurídica");
            }
        }
        */
        static void Main(string[] args)
        {
           
            ClientePF pessoapf = new ClientePF();
            pessoapf.SolicitarAberturaPF();
            //pessoapf.ToString();

            //ClientePJ pj = new ClientePJ();
            //pj.SolicitarAberturaPJ();
            //pj.ToString();

            Atendente atend = new();
            atend.AbreConta();

            Gerente geren = new();
            geren.AprovaConta();
            

            CCUniversitaria cc = new CCUniversitaria("33899767800");
            cc.SolicitaEmprestimo("33899767800");

            Gerente gerente = new Gerente();
            gerente.AprovaEmprest();
        }
    }
}
