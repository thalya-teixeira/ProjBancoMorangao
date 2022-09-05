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

        public override string ToString()
        {
            return IdPessoa + ";Conta Jurídica;Agência: " + Agencia + ";Telefone: " + Telefone + ";Data de Abertura: " + Data  + ";Razão Social: " + RazaoSocial +
                 ";CNPJ: " + CNPJ + ";Renda: " + Renda + ";";
        }
        public string DadosPJ()
        {
            return $"{IdPessoa};{Nome};{Telefone};{Data};{RazaoSocial};{CNPJ};{Renda};";
        }


        public string CadastraPJ(int id)
        {
            Console.WriteLine("***************************** BANCO MORANGÃO ********************************\n");
            Console.WriteLine("********** SOLICITAÇÃO DE ABERTURA DE CONTA PESSOA JURÍDICA **********\n");

            IdPessoa = id;

            Console.Write("Informe a Razão Social: ");
            RazaoSocial = Console.ReadLine();

            Console.Write("Informe sua data de abertura: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o seu CNPJ: ");
            CNPJ = Console.ReadLine();

            return ToString();
        }

        public void SolicitarAberturaPJ()
        {
            int id = getIdPessoa();

            ClientePJ pj = new();
            string cadastrapj = pj.CadastraPJ(id);

            Endereco end = new();
            //criando uma variael que irá armazenar dentro dessa variavel o retorno
            string endereco = end.CadastrarEndereco(id);

            //idpessoa

            //cria o arquivo com os dados da pessoa e o com o contador do id 
            try
            {
                StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\pessoajuridica{id}.txt");
                arqId.WriteLine(cadastrapj + endereco);
                arqId.Close();
                id++;
                SaveID(id);
                Console.WriteLine("SOLICITAÇÃO DE ABERTURA DE CONTA REALIZADA COM SUCESSO!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
