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
        protected int IdPessoa { get; set; }

        public Endereco()
        {
            
        }
        public override string ToString()
        {
            return "IdPessoa: " + IdPessoa + ";Logradouro: " + Logradouro + "nNúmero: " + Numero + ";Complemento: " + Complemento +
              ";Bairro: " + Bairro + ";CEP: " + CEP + ";Cidade: " + Cidade + ";Estado: " + Estado + ";";
        }
        /*
        public string DadosEnd()
        {
            return $"{Logradouro};{Numero};{Complemento};{Bairro};{CEP};{Cidade};{Estado};";
        }
        */
        //cadastrar endereço dos clientes
        public string CadastrarEndereco(int idPessoa)
        {
            IdPessoa = idPessoa;
            Console.Write("Informe o seu logradouro(rua): ");
            Logradouro = Console.ReadLine();
            
            Console.Write("Informe o número: ");
            Numero = Console.ReadLine();
            
            Console.Write("Informe o seu complemento: ");
            Complemento = Console.ReadLine();

            Console.Write("Informe o bairro: ");
            Bairro = Console.ReadLine();

            Console.Write("Informe o CEP: ");
            CEP = Console.ReadLine();

            Console.Write("Informe o nome da cidade: ");
            Cidade = Console.ReadLine();

            Console.Write("Informe o nome do estado: ");
            Estado = Console.ReadLine();

            return ToString();
        }
    }
}
