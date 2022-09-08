using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Endereco
    {
        protected string Logradouro { get; set; }
        protected string Numero { get; set; }
        protected string Complemento { get; set; }
        protected string Bairro { get; set; }
        protected string CEP { get; set; }
        protected string Cidade { get; set; }
        protected string Estado { get; set; }
        protected int IDPessoa { get; set; }

        public Endereco()
        {

        }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public override string ToString()
        {
            return "Logradouro: " + Logradouro + ";Número: " + Numero + ";Complemento: " + Complemento +
              ";Bairro: " + Bairro + ";CEP: " + CEP + ";Cidade: " + Cidade + ";Estado: " + Estado + ";";
        }

        public string DadosEnd()
        {
            return $"{Logradouro};{Numero};{Complemento};{Bairro};{CEP};{Cidade};{Estado};";
        }

        //cadastrar endereço dos clientes
        public string CadastrarEndereco(int idPessoa)
        {
            IDPessoa = idPessoa;
            Console.Write("\tInforme o seu logradouro(rua): ");
            Logradouro = Console.ReadLine();

            Console.Write("\tInforme o número: ");
            Numero = Console.ReadLine();

            Console.Write("\tInforme o seu complemento: ");
            Complemento = Console.ReadLine();

            Console.Write("\tInforme o bairro: ");
            Bairro = Console.ReadLine();

            Console.Write("\tInforme o CEP: ");
            CEP = Console.ReadLine();

            Console.Write("\tInforme o nome da cidade: ");
            Cidade = Console.ReadLine();

            Console.Write("\tInforme o nome do estado: ");
            Estado = Console.ReadLine();

            return ToString();
        }
    }
}
