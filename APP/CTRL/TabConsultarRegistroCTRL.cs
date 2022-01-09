using Godot;
using System;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class TabConsultarRegistroCTRL : Tabs
	{
		private IConsultarRegistroBLL BLL { get; set; }
		private LineEdit Nome { get ; set; }
		private OptionButton Idioma { get; set; }
		private Label Erro { get ; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new ConsultarRegistroBLL();
		}
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Pesquisa/Nome");
			Erro = GetNode<Label>("./Dados/Erro");
		}

		private void _on_Pesquisar_button_up()
		{
			Erro.Text = BLL.ValidarPreenchimento(Nome.Text, Nome.Text);
		}
	}
}
