using Godot;
using System;

namespace CTRL
{
	public class TabConsultarRegistroCTRL : Tabs
	{
		private LineEdit Nome { get ; set; }
		private OptionButton Idioma { get; set; }
		private Label Erro { get ; set; }
		public override void _Ready()
		{
			Nome = GetNode<LineEdit>("./Pesquisa/Nome");
			Erro = GetNode<Label>("./Dados/Erro");
		}
		private void _on_Pesquisar_button_up()
		{
			if(string.IsNullOrEmpty(Nome.Text))
			{
				Erro.Text = "Por favor preencher o Nome.";
				return;
			}
			Erro.Text = string.Empty;
				
			
		}
	}
}
