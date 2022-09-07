using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class ClientePJ : Pessoa
    {
        protected string RazaoSocial { get; set; }
        protected string CNPJ { get; set; }
        private float Renda { get; set; }
        //protected Pessoa Pessoa { get; set; }
        //protected Endereco endereco { get; set; }

        //conta

        public ClientePJ()
        {

        }

        public ClientePJ(int id, string agencia, string nome, string telefone, DateTime data, string razao, string cnpj, float renda)
        {
            IdPessoa = id;
            Agencia = agencia;
            Nome = nome;
            Telefone = telefone;
            Data = data;
            RazaoSocial = razao;
            CNPJ = cnpj;
            Renda = renda;
        }

        public override string ToString()
        {
            return IdPessoa + ";Conta Jurídica;Agência: " + Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Abertura CNPJ: " + Data.ToShortDateString() + ";Razão Social: " + RazaoSocial +
                ";CNPJ: " + CNPJ + ";Renda: " + Renda + ";";
        }

        private string DadosClientePJ()
        {
            return $"{IdPessoa};Conta Jurídica;{Agencia};{Nome};{Telefone};{Data.ToShortDateString()};{CNPJ};{RazaoSocial};{Renda};";
        }


        public string CadastraPJ(int id)
        {
            
            Console.WriteLine("\t°°°°°°°°°°°  SOLICITAÇÃO PESSOA JURÍDICA °°°°°°°°°°°°°");

            IdPessoa = id;

            Console.WriteLine("\t\nDigite o Número da agência [1-Zona Norte / 2-Zona Leste / 3-Zona Sul]: ");
            Agencia = Console.ReadLine();

            Console.WriteLine("\tInforme o nome da sua empresa: ");
            Nome = Console.ReadLine();

            Console.Write("\tDigite o telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("\tInforme a Razão Social: ");
            RazaoSocial = Console.ReadLine();

            Console.Write("\tInforme sua data de abertura [dd/mm/aa]: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("\tInforme o seu CNPJ: ");
            CNPJ = Console.ReadLine();

            Console.Write("\tInforme sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            return DadosClientePJ();
        }

        public void SolicitarAberturaPJ()
        {
            int id = getIdPessoa();

            //ClientePJ pj = new ClientePJ();
            string cadastrapj = CadastraPJ(id);

            Endereco end = new();
            //criando uma variael que irá armazenar dentro dessa variavel o retorno
            string endereco = end.CadastrarEndereco(id);

            //idpessoa

            //cria o arquivo com os dados da pessoa e o com o contador do id 
            try
            {
                StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{CNPJ}.txt");
                arqId.WriteLine(cadastrapj + endereco);
                arqId.Close();
                id++;
                SaveID(id);
                Console.WriteLine("\n\tSOLICITAÇÃO DE ABERTURA DE CONTA REALIZADA COM SUCESSO!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
