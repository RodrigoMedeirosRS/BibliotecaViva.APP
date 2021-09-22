using Godot;
using System;
using System.Linq;

using DTO;
using BLL;
using BLL.Interface;

namespace CTRL
{
	public class TabCadastrarPessoaCTRL : Tabs
	{
		private ICadastrarPessoaBLL BLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Sobrenome { get; set; }
		private LineEdit Genero { get; set; }
		private LineEdit Apelido { get; set; }
		private LineEdit Latitude { get ; set; }
		private LineEdit Longitude { get; set; }
		private Label Erro { get; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
		}

		private void RealizarInjecaoDeDependencias()
		{
			BLL = new CadastrarPessoaBLL();
		}

		private void PopularNodes()
		{
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
			Erro.Text = BLL.ValidarPreenchimento(Nome.Text, Sobrenome.Text, Genero.Text, Latitude.Text, Longitude.Text);
		}
	}
}
