using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Pessoa 
    {
        protected string Nome  { get; set; }
        protected DateTime Data { get; set; }
        protected string Telefone { get; set; }
        protected int IdPessoa { get; set; }
        public string Agencia { get; set; }

        public Pessoa()
        {

        }

        //metodo para pegar o valor de ID no arquivo, pois eu já criei um arquivo do tipo txt iniciando no valor que eu quero
        protected int getIdPessoa()
        {
            string[] contador = System.IO.File.ReadAllLines($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\IDPessoa\\id.txt");
            string[] num = new string[1];

            foreach (string cont in contador)
            
                num[0] = cont;
            Console.WriteLine(num[0]);
            int id = int.Parse(num[0]);

            return id;
        }

        //metodo para devolver o ID no arquivo 
        protected void SaveID(int id)
        {
            StreamWriter devolveId = new StreamWriter($"C:\\Users\\Thalya\\source\\repos\\ProjBancoMorangao\\IDPessoa\\id.txt"); //sw.WriteLine();  Escreve uma linha no Arquivo
            devolveId.WriteLine(id);
            devolveId.Close(); // comando para fechar o arquivo
        }

    }
}
