using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    public class TelaChamado : Tela
    {
        private ControladorChamado controladorChamado;
        private TelaEquipamento telaEquipamento;
        private TelaSolicitante telaSolicitante;

        public TelaChamado(ControladorChamado controlador, TelaEquipamento telaE, TelaSolicitante telaS)
        {
            controladorChamado = controlador;
            telaEquipamento = telaE;
            telaSolicitante = telaS;
        }

        public override void Excluir()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            controladorChamado.ExcluirChamado(idSelecionado);
        }

        public override void Editar()
        {
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            Console.Write("Digite o número do chamado que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Registrar(idSelecionado);
        }

        public override void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-30} | {2,-35} | {3,-25} | {4,-25}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Chamado[] chamados = controladorChamado.SelecionarTodosChamados();

            foreach (Chamado chamado in chamados)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-35} | {3,-25} | {4,-25}",
                    chamado.id, chamado.equipamento.nome, chamado.titulo, chamado.DiasEmAberto, chamado.solicitante.nome);
            }

            if (chamados.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum chamado registrado!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }        

        public override void Registrar(int idChamadoSelecionado)
        {
            Console.Clear();
            
            telaEquipamento.Visualizar();

            Console.Write("Digite o Id do equipamento para manutenção: ");
            int idEquipamentoChamado = Convert.ToInt32(Console.ReadLine());

            telaSolicitante.Visualizar();
            
            Console.Write("Digite o Id do Solicitante: ");
            int idSolicitanteChamado = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

            controladorChamado.RegistrarChamado(idChamadoSelecionado, idEquipamentoChamado, idSolicitanteChamado, titulo, descricao, dataAbertura);
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Equipamento", "Título", "Dias em aberto", "Solicitante");

            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }
}
