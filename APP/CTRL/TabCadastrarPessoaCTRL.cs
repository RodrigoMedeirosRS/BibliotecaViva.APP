using Godot;
using System;
using System.Linq;

using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.DTO;

namespace BibliotecaViva.CTRL
{
	public class TabCadastrarPessoaCTRL : Tabs
	{
		private ICadastrarPessoaBLL BLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Sobrenome { get; set; }
		private LineEdit Genero { get; set; }
		private LineEdit Apelido { get; set; }
		private LineEdit LatLong { get ; set; }
		private Label Erro { get; set; }
		private Label Sucesso { get; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new CadastrarPessoaBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Inputs/Nome");
			Sobrenome = GetNode<LineEdit>("./Inputs/Sobrenome");
			Genero = GetNode<LineEdit>("./Inputs/Genero");
			Apelido = GetNode<LineEdit>("./Inputs/Apelido");
			LatLong = GetNode<LineEdit>("./Inputs/Latitude");
			Sucesso = GetNode<Label>("./Sucesso");
			Erro = GetNode<Label>("./Erro");
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			try
			{
				var pessoa = BLL.PopularPessoa(Nome.Text, Sobrenome.Text, Genero.Text, Apelido.Text, LatLong.Text);
				LimparPreenchimento();
				Feedback(BLL.CadastrarPessoa(pessoa), true);
			}
			catch(Exception ex)
			{
				Feedback(ex.Message, false);
			}
		}
		private void Feedback(string mensagem, bool sucesso)
		{
			Sucesso.Text = sucesso ? mensagem : string.Empty;
			Erro.Text = sucesso ? string.Empty : mensagem;
		}
		private void LimparPreenchimento()
		{
			Nome.Text = string.Empty;
			Sobrenome.Text = string.Empty;
			Genero.Text = string.Empty;
			Apelido.Text = string.Empty;
			LatLong.Text = string.Empty;
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			Nome.QueueFree();
			Sobrenome.QueueFree();
			Genero.QueueFree();
			Apelido.QueueFree();
			LatLong.QueueFree();
			Sucesso.QueueFree();
			Erro.QueueFree();
			QueueFree();
		}
	}
}
