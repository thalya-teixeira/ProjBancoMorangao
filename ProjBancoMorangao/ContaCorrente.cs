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
        public void Depositar(float valor, string cpfCnpj)
        {
            //busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco");
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
            System.IO.StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
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

        public void SolicitarEmprestimo(string cpfCnpj)
        {
            float valorParcela;

            Console.WriteLine("\tDigite o valor do empréstimo: R$");
            float valor = float.Parse(Console.ReadLine());

            Console.Write("\tDigite a quantidade de parcelas (máximo 36x): ");
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

            if (envia == "s")
            {
                //Envia os dados do solicitante e o valor para o diretório SolicitaçõesEmpréstimos para ser aprovado pelo cliente
                string[] solicitante = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\SolicitaçãoEmprest\\{cpfCnpj}.txt");
                arqPessoa.WriteLine($"{solicitante[0]}{valor};");
                arqPessoa.Close();
            }
            else
            {
                Console.WriteLine("Solicitação cancelada!");
            }
            Console.WriteLine("\t--------------------------------------------------------");
            Console.WriteLine("\t|              EMPRÉSTIMO SOLICITADO                   |");
            Console.WriteLine("\t|        O GERENTE IRÁ ANALISAR SUA SOLICITAÇÃO        |");
            Console.WriteLine("\t|         PRESSIONE ENTER PARA VOLTAR AO MENU          |");
            Console.WriteLine("\t|______________________________________________________|");
        }

        protected void AddExtrato(string cpfCnpj, string extrato) //adicionar o extrato na conta após movimentacoes nas contas
        {
            try
            {
                string caminho = $"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Extrato\\{cpfCnpj}.txt";

                string texto = $"{extrato}\n";

                File.AppendAllText(caminho, texto);

            }
            catch (Exception e)
            {
                Console.WriteLine($"\tNão foi possível adicionar extrato! Contate o suporte. Erro: {e.Message}");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

        }

        public void GetExtrato(string cpfCnpj) // imprimi o extrato na tela
        {
            try
            {
                string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                string[] dados = new string[18];
                foreach (string dado in conta)
                    dados = dado.Split(';');

                FileStream fs = File.OpenRead($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Extrato\\{cpfCnpj}.txt");

                byte[] b = new byte[1024];
                UTF8Encoding temp = new (true);

                Console.WriteLine("\n°°°°°°°°°°°°°°°°°°°°°°°°°°°   EXTRATO DA CONTA  °°°°°°°°°°°°°°°°°°°°°°°°°°°°");
                Console.WriteLine($"CPF/CNPJ: {DadoCliente}");
                Console.WriteLine($"Nome: { dados[3]}\n"); //posicao 3 

                while (fs.Read(b, 0, b.Length) > 0)
                {
                    Console.WriteLine(temp.GetString(b));
                }
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("                                                                            ");
                Console.WriteLine($"SALDO ATUAL DA CONTA: R${dados[17]:N2}                                         ");
                Console.WriteLine($"                                                                           ");
                Console.WriteLine("____________________________________________________________________________");

            }
            catch (Exception)
            {
                Console.WriteLine($"\tNão há impressões disponíveis no momento!\n\tO cliente não efetuou nenhum tipo de movimentação em sua conta. ");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }
        }

        protected int MenuCaixaEletronico()
        {
            int opc;
            do
            {
                Console.WriteLine("\t|°°°°°°°°°°°°°  MENU CAIXA ELETRÔNICO  °°°°°°°°°°°°°°°°|");
                Console.WriteLine("\t|                                                      |");
                Console.WriteLine("\t|   opção 1 : Realizar Saque                           |");
                Console.WriteLine("\t|   opção 2 : Realizar Depósito                        |");
                Console.WriteLine("\t|   opção 3 : Realizar Transferências                  |");
                Console.WriteLine("\t|   opção 4 : Realizar Pagamentos                      |");
                Console.WriteLine("\t|   opção 5 : Consultar Extrato                        |");
                Console.WriteLine("\t|   opção 6 : Solicitar Empréstimo                     |");
                Console.WriteLine("\t|                                                      |");
                Console.WriteLine("\t|   opção 0 : Sair                                     |");
                Console.WriteLine("\t|______________________________________________________|");
                Console.Write("Opção: ");

                opc = int.Parse(Console.ReadLine());
                return opc;

            } while (opc != 0);

            Console.WriteLine("\tOBRIGADO! VOLTE SEMPRE");
            return 0;
        }
    }
}
