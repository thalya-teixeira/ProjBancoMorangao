using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class ClientePF : Pessoa
    {
        private string CPF { get; set; }
        protected float Renda { get; set; }
        protected string Estudante { get; set; }
        public string RA { get; set; }

        //conta

        public ClientePF()
        {

        }

        public ClientePF(int id, string nome, string agencia, string telefone, DateTime data, string cpf, float renda, string estudante)
        {
            IDPessoa = id;
            Agencia = agencia;
            Nome = nome;
            Telefone = telefone;
            Data = data;
            CPF = cpf;
            Renda = renda;
            Estudante = estudante;
        }

        public override string ToString()
        {
            return IDPessoa + ";Conta Física;Agência: " + Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Nascimento: " + Data.ToShortDateString() + ";CPF: " + CPF +
                 ";Renda: R$" + Renda + ";Estudante: " + Estudante + ";";
        }

        private string DadosClientePF()
        {
            return $"{IDPessoa};Conta Física;{Agencia};{Nome};{Telefone};{Data.ToShortDateString()};{CPF};{Renda};{Estudante};";
        }

        public string CadastrarPF(int id)
        {

            Console.WriteLine("\t°°°°°°°°°°°°  SOLICITAÇÃO PESSOA FISÍCA  °°°°°°°°°°°°°°°");

            IDPessoa = id;

            Console.Write("\n\tDigite o Número da agência [1-Zona Norte / 2-Zona Leste / 3-Zona Sul]: ");
            Agencia = Console.ReadLine();

            Console.Write("\tInforme o seu nome completo: ");
            Nome = Console.ReadLine();

            Console.Write("\tInforme sua data de nascimento [dd/mm/aa]: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("\tInforme o seu CPF: ");
            CPF = Console.ReadLine();

            Console.Write("\tInforme o seu telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("\tInforme a sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            Console.Write("\tEstudante? S/N: ");
            string estudante = Console.ReadLine().ToLower().Trim();

            if (estudante == "s")
                Estudante = "s";
            // Console.WriteLine(" ♦ Digite seu RA: ");
            //RA = Console.ReadLine();
            else
                Estudante = "s";

            return DadosClientePF();
        }

        public void SolicitarAberturaPF()
        {

            int id = getID();

            string cadastrapf = CadastrarPF(id);

            Endereco end = new();
            //criando uma variael que irá armazenar dentro dessa variavel o retorno
            string endereco = end.CadastrarEndereco(id);

            //cria o arquivo com os dados da pessoa e o com o contador do id  C:
            try
            {
                StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{CPF}.txt");
                arqId.WriteLine(cadastrapf + endereco);
                arqId.Close();
                id++;
                SaveID(id);
                Console.WriteLine("\tSOLICITAÇÃO DE ABERTURA DE CONTA REALIZADA COM SUCESSO!!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
