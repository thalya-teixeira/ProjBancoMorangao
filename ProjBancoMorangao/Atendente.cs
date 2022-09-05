using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Atendente : Funcionario
    {
        //public string Agencia { get; set; }

        public Atendente()
        {

        }
        public Atendente(string agencia)
        {
            if (agencia.Contains('1'))
            {
                Nome = "Louise";
                Cargo = "Atendente";
            }
            else if (agencia.Contains('2'))
            {
                Nome = "Thalya";
                Cargo = "Atendente";
            }
            else if (agencia.Contains('3'))
            {
                Nome = "Weslen";
                Cargo = "Atendente";
            }
        }

        public void AbreConta()
        {
            //verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>();
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao");

            foreach (var file in dir.GetFiles()) //pega da pasta
            {
                solicitacoes.Add(file.Name);
            }

            if (solicitacoes.Count == 0)
            { 
                Console.WriteLine("Não há nenhuma solicitação no momento!");
                return;
            }
            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações pendentes!");

            //mostra na tela os dados da solicitação
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new List<string>();

            Console.WriteLine($"\nDados da solicitação: ");

            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';'); //para aparecer certinho com os ";" para separar na lista

                for (int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }
            }
            Console.WriteLine("Criar conta para o cliente? [S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            if (ler.Contains("s"))
            {
                Console.WriteLine("Digite o tipo de conta:\n\n1 - Para Conta Universitária\n2 - Para Conta Normal\n3 - Para conta VIP");
                int tipo = int.Parse(Console.ReadLine());

                //switch para inserir o tipo de conta que o atendente escolher e depois envia o arquivo para o diretório AguardAprov para ser aprovado pelo gerente
                switch (tipo)
                {
                    case 1:
                        System.IO.StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}");
                        arqId.WriteLine($"{solicita[0]}Tipo de conta: Conta Universitária;");
                        arqId.Close();
                        File.Move($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}",
                                    $"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                        break;

                    case 2:
                        System.IO.StreamWriter arqPessoa1 = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}");
                        arqPessoa1.WriteLine($"{solicita[0]}Tipo de conta: Conta Normal;");
                        arqPessoa1.Close();
                        File.Move($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}",
                                    $"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                        break;

                    case 3:
                        System.IO.StreamWriter arqPessoa2 = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}");
                        arqPessoa2.WriteLine($"{solicita[0]}Tipo de conta: Conta VIP;");
                        arqPessoa2.Close();
                        File.Move($"\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\Solicitacao\\{solicitacoes.First()}",
                                    $"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                        break;

                }
            }
        }
    }
}
