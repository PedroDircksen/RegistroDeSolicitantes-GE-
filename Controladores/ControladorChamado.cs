using GestaoEquipamentos.ConsoleApp.Dominio;
using System;

namespace GestaoEquipamentos.ConsoleApp.Controladores
{
    public class ControladorChamado : Controlador
    {
        private ControladorEquipamento controladorEquipamento;
        private ControladorSolicitante controladorSolicitante;

        public ControladorChamado(int capacidadeRegistros, ControladorEquipamento controladorE, ControladorSolicitante controladorS)
            : base(capacidadeRegistros)
        {
            controladorEquipamento = controladorE;
            controladorSolicitante = controladorS;
        }

        public void RegistrarChamado(int idChamadoSelecionado, int idEquipamentoChamado, int idSolicitanteChamado, 
            string titulo, string descricao, DateTime dataAbertura)
        {
            Chamado chamado;
            int posicao = 0;

            if (idChamadoSelecionado == 0)
            {
                chamado = new Chamado();
                posicao = ObterPosicaoVazia();
            }
            else
            {                
                posicao = ObterPosicaoOcupada(new Chamado(idChamadoSelecionado));
                chamado = (Chamado)registros[posicao];
            }

            chamado.solicitante = controladorSolicitante.SelecionarSolicitantePorId(idSolicitanteChamado);
            chamado.equipamento = controladorEquipamento.SelecionarEquipamentoPorId(idEquipamentoChamado);
            chamado.titulo = titulo;
            chamado.descricao = descricao;
            chamado.dataAbertura = dataAbertura;

            registros[posicao] = chamado;
        }

        public bool ExcluirChamado(int idSelecionado)
        {
            return ExcluirRegistro(new Chamado(idSelecionado));
        }        

        public Chamado[] SelecionarTodosChamados()
        {
            Chamado[] chamadosAux = new Chamado[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), chamadosAux, chamadosAux.Length);

            return chamadosAux;
        }
    }
}
