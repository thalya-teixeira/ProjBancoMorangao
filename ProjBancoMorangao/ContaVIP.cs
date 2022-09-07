using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class ContaVIP : ContaCorrente
    {
        public ContaVIP(string cpfCnpj)
        {
            //busca o cpf/cnpj
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
            else
            {
                ClientePJ empresa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], dados[7], float.Parse((dados[8])));
                Empresa = empresa;
                NumConta = int.Parse(dados[0]);
                DadoCliente = dados[6]; //cnpj
            }
            //cria o objeto do tipo endereço com os dados do arquivo
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;

        }

        public bool SacarCVIP(float valor)
        {
            //verifica se o saldo ficar mais que R$ -5000,00 não permite o método
            if (this.Saldo - valor < -5000)
            {
                Console.WriteLine("\tVocê não possui limite para realizar essa transação!");
                return false;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("\tDébito/Pagamento realizado com sucesso!");
                return true;
            }
        }

        //método para realizar transferência
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            if (SacarCVIP(valorSolicitado))
            {
                Depositar(valorSolicitado, cpfCnpjDestino);
                AddExtrato(DadoCliente, $"TRANSFERÊNCIA PARA O CPF/CNPJ {cpfCnpjDestino}: {DateTime.Now} ---------- R${valorSolicitado:N2}");
            }
        }

        //método para realizar pagamentos
        public void RealizarPagamento(float valor)
        {
            if (SacarCVIP(valor))
                AddExtrato(DadoCliente, $"PAGAMENTO DE CONTA: {DateTime.Now} ---------- R${valor:N2}");
        }

        public void OpCaixaEletronica()
        {
            int operacao;
            do
            {
                operacao = MenuCaixaEletronico();

                switch (operacao)
                {

                    case 1:
                        Console.Write("\tInforme o valor do saque desejado: ");
                        float saque = float.Parse(Console.ReadLine());
                        if (SacarCVIP(saque))
                            AddExtrato(DadoCliente, $"SAQUE REALIZADO: {DateTime.Now} ---------- R${saque:N2}");
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 2:
                        Console.Write("\tInforme o valor que deseja depositar: ");
                        float deposito = float.Parse(Console.ReadLine());
                        try
                        {
                            Depositar(deposito, DadoCliente);
                            AddExtrato(DadoCliente, $"DEPÓSITO EM CONTA: {DateTime.Now} ---------- R${deposito:N2}");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Não foi possível realizar depósito.");
                        }
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 3:
                        Console.Write("\tInforme o CPF do destinatário: ");
                        string cpf = Console.ReadLine();
                        Console.Write("\nInforme o valor que deseja transferir: ");
                        float transfere = float.Parse(Console.ReadLine());
                        Transferir(cpf, transfere);
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Write("\tInforme o valor do boleto para pagamento: ");
                        float pagamento = float.Parse(Console.ReadLine());
                        RealizarPagamento(pagamento);
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        GetExtrato(DadoCliente);
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        SolicitaEmprestimo(DadoCliente);
                        Console.WriteLine("\n\tPressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            } while (operacao != 0);
        }
    }
}
