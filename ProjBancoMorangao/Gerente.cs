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
                if(solicitacaoList.Contains("Tipo de conta: Conta Universitária"))
                {
                    Console.WriteLine("Conta Universitária criada com sucesso!");
                }
                else if(solicitacaoList.Contains("Tipo de conta: Conta Normal"))
                {
                    Console.WriteLine("Conta Normal criada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Conta VIP criada com sucesso!");
                }
            }

        }





    }
}
