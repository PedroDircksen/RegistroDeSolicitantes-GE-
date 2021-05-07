using System;
using GestaoEquipamentos.ConsoleApp.Dominio;
using GestaoEquipamentos.ConsoleApp.Controladores;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaSolicitante : Tela
    {
        private ControladorSolicitante controladorSolicitante;

        public TelaSolicitante(ControladorSolicitante controlador)
        {
            controladorSolicitante = controlador;
        }


        public override void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do solicitante que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public override void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do solicitante que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorSolicitante.ExcluirSolicitante(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Solicitante excluído com sucesso");
                Console.ReadLine();
            }
        }

        public override void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-30} | {2,-55} | {3,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Solicitante[] solicitantes = controladorSolicitante.SelecionarTodosSolicitantes();

            for (int i = 0; i < solicitantes.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   solicitantes[i].id, solicitantes[i].nome, solicitantes[i].email, solicitantes[i].telefone);

                Console.WriteLine();
            }

            if (solicitantes.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum solicitante cadastrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }

        public override void Registrar(int id)
        {
            Console.Clear();

            string resultadoValidacao = "";

            do
            {
                Console.Write("Digite o nome do solicitante: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o email do solicitante: ");
                string email = Console.ReadLine();

                Console.Write("Digite o telefone do equipamento: ");
                string telefone= Console.ReadLine();

                resultadoValidacao = controladorSolicitante.RegistrarSolicitante(
                    id, nome, email, telefone);

                if (resultadoValidacao != "SOLICITANTE_VALIDO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(resultadoValidacao);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Registro gravado com sucesso!");
                }

                Console.ReadLine();
                Console.Clear();
                Console.ResetColor();

            } while (resultadoValidacao != "SOLICITANTE_VALIDO");
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "email", "Telefone");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion

    }
}
