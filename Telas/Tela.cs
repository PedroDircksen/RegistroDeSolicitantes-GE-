using System;

namespace GestaoEquipamentos.ConsoleApp
{
    public class Tela
    {
        public string ObterOpcaoCadastro()
        {
            //apresenta as opções
            Console.WriteLine("Digite 1 para registrar ");
            Console.WriteLine("Digite 2 para visualizar histórico ");
            Console.WriteLine("Digite 3 para editar ");
            Console.WriteLine("Digite 4 para excluir ");

            Console.WriteLine("Digite S para sair");

            //solicita qual opção
            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void Registrar(int id)
        {

        }

        public virtual void Visualizar()
        {

        }

        public virtual void Editar()
        {

        }

        public virtual void Excluir()
        {

        }        
    }
}
