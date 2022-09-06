using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class ContaCorrente
    {
        public int NumConta { get; set; }
        public float Saldo { get; set; }
        public ClientePF Pessoa { get; set; }
        public ClientePJ Empresa { get; set; }
        public Endereco Endereco { get; set; }
        public string DadoCliente { get; set; }

        public ContaCorrente()
        {

        }

        //método para realizar depósito
       public void Depositar (float valor, string cpfCnpj)
        {
            //busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\ProjBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de depósito
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino += valor; // += soma com o valor atual
            dados[17] = saldoContaDestino.ToString();

            //sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            arqId.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqId.Close();
        }

        protected void Sacar(float valor, string cpfCnpj)
        {
            //busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de saque
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino -= valor; // -= vai retirar da conta
            dados[17] = saldoContaDestino.ToString();

            //Sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            arqId.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqId.Close();
        }

        public void SolicitaEmprestimo(string cpfCnpj)
        {
            float valorParcela;

            Console.WriteLine("Digite o valor do empréstimo: R$");
            float valor = float.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de parcelas (máximo 36x): ");
            int parcelas = int.Parse(Console.ReadLine());

            if (parcelas > 10)
                valorParcela = valor * 1.1f / parcelas;

            else if (parcelas > 20)
                valorParcela = valor * 1.2f / parcelas;

            else if (parcelas > 30)
                valorParcela = valor * 1.3f / parcelas;

            else
                valorParcela = valor * 1.4f / parcelas;

            //Aguarda a confimação do usuário
            Console.WriteLine($"\nO valor do empréstimo será {parcelas} parcelas de R${valorParcela:N2}");

            Console.WriteLine("\nDESEJA ENVIAR A SOLICITAÇÃO? [S/N]: ");
            string envia = Console.ReadLine().ToLower();

            if(envia == "s")
            {
                //Envia os dados do solicitante e o valor para o diretório SolicitaçõesEmpréstimos para ser aprovado pelo cliente
                string[] solicitante = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\PBancoMorangao\\SolicitaçãoEmprest\\{cpfCnpj}.txt");
                arqPessoa.WriteLine($"{solicitante[0]}{valor};");
                arqPessoa.Close();
            }
            else
            {
                Console.WriteLine("Solicitação cancelada!");
            }

        }
    }
}
