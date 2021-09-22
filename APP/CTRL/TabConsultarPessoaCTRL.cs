using Godot;
using System;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class TabConsultarPessoaCTRL : Tabs
	{
		private IConsultarPessoaBLL BLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Sobrenome { get; set; }
		private Label Erro { get; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new ConsultarPessoaBLL();
			
		}
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Pesquisa/Nome");
			Sobrenome = GetNode<LineEdit>("./Pesquisa/Sobrenome");
			Erro = GetNode<Label>("./Dados/Erro");
		}
		private void _on_Pesquisar_button_up()
		{
			Erro.Text = BLL.ValidarPreenchimento(Nome.Text, Sobrenome.Text);
		}
	}
}
