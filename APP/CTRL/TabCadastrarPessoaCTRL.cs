using Godot;
using System;
using System.Linq;

using DTO;
using BLL;

namespace CTRL
{
	public class TabCadastrarPessoaCTRL : Tabs
	{
		private CadastrarPessoaBLL BLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Sobrenome { get; set; }
		private LineEdit Genero { get; set; }
		private LineEdit Apelido { get; set; }
		private LineEdit Latitude { get ; set; }
		private LineEdit Longitude { get; set; }
		private Label Erro { get; set; }
		public override void _Ready()
		{
			BLL = new CadastrarPessoaBLL();
			Nome = GetNode<LineEdit>("./Inputs/Nome");
			Sobrenome = GetNode<LineEdit>("./Inputs/Sobrenome");
			Genero = GetNode<LineEdit>("./Inputs/Genero");
			Apelido = GetNode<LineEdit>("./Inputs/Apelido");
			Latitude = GetNode<LineEdit>("./Inputs/Latitude");
			Longitude = GetNode<LineEdit>("./Inputs/Longitude");
			Erro = GetNode<Label>("./Erro");
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			if (string.IsNullOrEmpty(Nome.Text))
			{
				Erro.Text = "Por favor preencher o Nome.";
				return;
			}
			if (string.IsNullOrEmpty(Sobrenome.Text))
			{
				Erro.Text = "Por favor preencher o Sobrenome.";
				return;
			}
			if (string.IsNullOrEmpty(Genero.Text))
			{
				Erro.Text = "Por favor preencher o Genero.";
				return;
			}
			if (!string.IsNullOrEmpty(Latitude.Text) || !string.IsNullOrEmpty(Longitude.Text))
				try
				{
					var latitude = double.Parse(Latitude.Text);
					var longitude = double.Parse(Longitude.Text);
				}
				catch
				{
					Erro.Text = "Por favor preencher um valor de Latitude e Longitude com valores válidos.";
					return;
				}
			Erro.Text = "";
		}
	}
}
