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
        protected char Estudante { get; set; }
        public string RA { get; set; }
        
        //conta

        public ClientePF()
        {

        }

        public override string ToString()
        {
            return IdPessoa + ";Conta Física;Agência: " + Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Nascimento: " + Data + ";CPF: " + CPF +
                ";Renda: R$" + Renda + ";Estudante: " + Estudante + ";";
        }

        public string CadastrarPF(int id)
        {
            Console.WriteLine("***************************** BANCO MORANGÃO ********************************\n");
            Console.WriteLine("********** SOLICITAÇÃO DE ABERTURA DE CONTA CADASTRO PESSOA FÍSICA **********\n");

           IdPessoa = id;

            Console.Write("Informe o seu nome completo: ");
            Nome = Console.ReadLine();

            Console.Write("Informe sua data de nascimento: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("Informe o seu CPF: ");
            CPF = Console.ReadLine();

            Console.Write("Informe o seu telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Informe a sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            Console.WriteLine("Você é um estudante? S/N");
            Estudante = char.Parse(Console.ReadLine().ToLower().Trim()); //letra minuscula e sem espaço

            if (Estudante == 's')
            {
                Console.WriteLine("Informe o seu RA: ");
                RA = Console.ReadLine();
                Estudante = 's';
            }                
            else Estudante = 'n';

            return ToString();
        }

        public void SolicitarAberturaPF()
        {

            int id = getIdPessoa();

            string cadastrapf = CadastrarPF(id);

            Endereco end = new();
            //criando uma variael que irá armazenar dentro dessa variavel o retorno
            string endereco = end.CadastrarEndereco(id);

            //cria o arquivo com os dados da pessoa e o com o contador do id  C:
            try
            {
                StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\pessoafisica{id}.txt");
                arqId.WriteLine(cadastrapf + endereco);
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
