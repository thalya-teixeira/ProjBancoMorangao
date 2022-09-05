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
                Console.Clear();
                Console.WriteLine(">>>>> MENU <<<<<");
                Console.WriteLine("1- Cadastrar Pessoa Fisíca");
                Console.WriteLine("2- Cadastrar Pessoa Jurídica");
            }
        }
        */
        static void Main(string[] args)
        {
           
            ClientePF pf = new ClientePF();
            pf.SolicitarAberturaPF();
            pf.ToString();

            //ClientePJ pj = new ClientePJ();
            //pj.SolicitarAberturaPJ();
            //pj.ToString();

            Atendente atend = new();
            atend.AbreConta();

            Gerente geren = new();
            geren.AprovaConta();

        }
    }
}
