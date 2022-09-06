using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class CCUniversitaria : ContaCorrente
    {
        public CCUniversitaria (string cpfCnpj)
        {
            //busca o arquivo que tem o cpf
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in solicita)
                dados = dado.Split(';');

            //verifica se o arquivo é do tipo clientePF
            if (solicita[0].Contains("Física"))
            {
                ClientePF pessoa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], float.Parse(dados[7]), (dados[8]));
                Pessoa = pessoa;
                NumConta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }

            //Cria o objeto do tipo endereço com os dados do arquivo
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;

        }

        public void SacarContUn(float valor)
        {
            //verifica se o saldo fica mais que R$ -1000,00 
            if(this.Saldo - valor < -1000)
            {
                Console.WriteLine("Você não possui limite para realizar essa transação!");
                return;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("Débito/Pagamento realizado com sucesso!");
            }
        }
        //método para realizar transferência
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            SacarContUn(valorSolicitado);
            Depositar(valorSolicitado, cpfCnpjDestino);
        }

        //método para realizar pagamentos
        public void RealizaPagamento(float valor)
        {
            SacarContUn(valor);
        }

    }
}
