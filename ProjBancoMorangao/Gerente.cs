using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Gerente : Funcionario
    {
        private int Senha { get; set; }

        public Gerente()
        {
            this.Senha = 666;
        }
        //método para verificar a senha do gerente
        public bool Autentica(int senha)
        {
            if(this.Senha == senha)
                return true;
            else
                return false;
        }

        public void AprovaConta()
        {
            //verifica a quantidade de solicitações dentro da pasta
            List<string> solicitacoes = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name);
            }
             
            //verifica caso não tenha solicitacao no diretorio ele sai do metodo
            if(solicitacoes.Count == 0)
            {
                Console.WriteLine("Não há solicitações no momento!");
                return;
            }
            else
            {
                Console.WriteLine($"Há {solicitacoes.Count} solicitações pendentes!");
            }

            //busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new();

            Console.WriteLine($"\nDADOS DA SOLICITAÇÃO: ");

            //laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for(int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }
            }
            Console.WriteLine("Aprovar conta? [S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //condição para abrir o tipo de conta solicitado pelo atendente
            if (ler.Contains('s'))
            {
                System.IO.StreamWriter arqId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                arqId.WriteLine($"{solicita[0]}0;");
                arqId.Close();
                File.Move($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\AguarAprov\\{solicitacoes.First()}",
                            $"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco\\{solicitacoes.First()}");
            }
            else
                return;
        }
        
        public void AprovaEmprestimo()
        {
            //verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\SolicitaçãoEmprest");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name); //faz a contagem de quantas solicitações tem
            }

            //caso nao tenha tenha solicitações no directório ele saíra do método
            if(solicitacoes.Count == 0)
            {
                Console.WriteLine("não há solicitações no momento!");
                return;
            }
            else
            {
                Console.WriteLine($"Há {solicitacoes.Count} solicitações pendentes!");
            }

            //busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\PBancoMorangao\\SolicitaçãoEmprest\\{solicitacoes.First()}.txt");
            string[] solicitacao = new string[19]; //[19] são os dados do cliente e acrescenta o valor do emprestimo

            List<string> solicitacaoList = new();

            Console.WriteLine("\nDADOS DA SOLICITAÇÃO: ");

            //laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for(int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }
            }

            Console.WriteLine(solicitacoes.First());
            Console.WriteLine("Aprovar empréstimo? [S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //condição para aprovar o empréstimo
            if (ler.Contains('s'))
            {
                //busca o arquivo com os dados do solicitante
                DirectoryInfo dirEmp = new DirectoryInfo("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco");
                var arq = dir.GetFiles($"{solicitacao[6]}.*");
                string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\PBancoMorangao\\SolicitaçãoEmprest\\{solicitacoes.First()}.txt");
                string[] dados = new string[18];
                foreach (string dado in conta)
                    dados = dado.Split(';');

                //altera o saldo conforme o valor do empréstimo
                float saldoContaDestino = float.Parse(dados[17]);
                Console.WriteLine(dados[17]);
                Console.ReadKey();
                float valor = float.Parse(dados[18]);
                saldoContaDestino += valor;
                dados[17] = saldoContaDestino.ToString();

                //sobrescreve o mesmo arquivo com o saldo atualizado
                System.IO.StreamWriter arqId = new StreamWriter("C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\ContasBanco");
                arqId.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                    $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
                arqId.Close();
            }
            else
                return;
        }
         
    }
}




