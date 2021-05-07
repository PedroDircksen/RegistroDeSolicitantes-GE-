using System;
using GestaoEquipamentos.ConsoleApp.Controladores;
using GestaoEquipamentos.ConsoleApp.Dominio;

namespace GestaoEquipamentos.ConsoleApp.Telas
{
    /// <summary>
    /// encarregada pela interação com usuário 
    /// (inputs, mensagens na tela)
    /// 
    /// VIEW == VISUALIZAÇÃO
    /// </summary>
    public class TelaEquipamento : Tela
    {
        //atributo
        private ControladorEquipamento controladorEquipamento;

        public TelaEquipamento(ControladorEquipamento controlador)
        {
            controladorEquipamento = controlador;
        }
        

        public override void Editar()
        {
            //visualiza os equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento atualizar
            Console.Write("Digite o número do equipamento que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            //atualiza o equipamento
            Registrar(idSelecionado);
        }

        public override void Excluir()
        {
            //visualização dos equipamentos
            Console.Clear();

            Visualizar();

            Console.WriteLine();

            //solicita qual equipamento excluir
            Console.Write("Digite o número do equipamento que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorEquipamento.ExcluirEquipamento(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.WriteLine("Registro excluído com sucesso");
                Console.ReadLine();
            }
        }

        public override void Visualizar()
        {
            Console.Clear();

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Equipamento[] equipamentos = controladorEquipamento.SelecionarTodosEquipamentos();

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Console.Write(configuracaColunasTabela,
                   equipamentos[i].id, equipamentos[i].nome, equipamentos[i].fabricante);

                Console.WriteLine();
            }

            if (equipamentos.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum equipmaneto cadastrado!");
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
                Console.Write("Digite o nome do equipamento: ");
                string nome = Console.ReadLine();                

                Console.Write("Digite o preço do equipamento: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.Write("Digite o número do equipamento: ");
                string numeroSerie = Console.ReadLine();

                Console.Write("Digite a data de fabricação do equipamento: ");
                DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Digite o fabricante do equipamento: ");
                string fabricante = Console.ReadLine();

                resultadoValidacao =controladorEquipamento.RegistrarEquipamento(
                    id, nome, preco, numeroSerie, dataFabricacao, fabricante);

                if (resultadoValidacao != "EQUIPAMENTO_VALIDO")
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

            } while (resultadoValidacao != "EQUIPAMENTO_VALIDO");
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Fabricante");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
        #endregion
    }

}
