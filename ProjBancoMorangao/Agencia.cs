using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBancoMorangao
{
    internal class Agencia
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }

        public void AcessoAtendente()
        {
            int agencia = 0;


            Console.WriteLine("\t°°°°°°°   ACESSO ADMINISTRATIVO RESPONSÁVEL   °°°°°°°°");
            Console.WriteLine(" ♦ Digite o número da agência operante: [1], [2] OU [3]: ");
            agencia = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (agencia == 1)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Louise");
                Console.WriteLine(Cargo = "Cargo: Atendente");
                Console.WriteLine();

            }
            else if (agencia == 2)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Thalya ");
                Console.WriteLine(Cargo = "Cargo: Atendente ");
                Console.WriteLine();
            }
            else if (agencia == 3)
            {
                Console.WriteLine(Nome = "Nome do funcionário: Weslen ");
                Console.WriteLine(Cargo = "Cargo: Atendente ");
                Console.WriteLine();
            }
            else if (agencia != 1 || agencia != 2 || agencia != 3)
            {
                Console.WriteLine("COMANDO INVÁLIDO! TENTE NOVAMENTE!");
            }
        }
    }
}
