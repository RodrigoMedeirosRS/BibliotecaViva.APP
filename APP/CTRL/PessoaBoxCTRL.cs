using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class PessoaBoxCTRL : Panel, IDisposableCTRL
	{
		private PessoaDTO Pessoa { get; set; }
		private Label NomeCompleto { get; set; }
		private Label NomeSocial { get; set; }
		private Label Genero { get; set; }
		private Label Apelido { get; set; }
		private Label Localizacao { get ;set; }
		public override void _Ready()
		{
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void PopularNodes()
		{
			NomeCompleto = GetNode<Label>("./NomeCompleto/Conteudo");
			NomeSocial = GetNode<Label>("./VBoxContainer/NomeSocial/Conteudo");
			Genero = GetNode<Label>("./VBoxContainer/Genero/Conteudo");
			Apelido = GetNode<Label>("./VBoxContainer/Apelido/Conteudo");
			Localizacao = GetNode<Label>("./VBoxContainer/GeoLocalizacao/Conteudo");
		}
		public void Preencher(PessoaDTO pessoaDTO, Vector2 posicao)
		{
			RectPosition = posicao;
			Pessoa = pessoaDTO;
			NomeCompleto.Text = Pessoa.Nome + " " + Pessoa.Sobrenome;
			PopularCampoOpcional(NomeSocial, Pessoa.NomeSocial);
			PopularCampoOpcional(Genero, Pessoa.Genero);
			PopularCampoOpcional(Apelido, Pessoa.Apelido);
			PopularCampoOpcional(Localizacao, Pessoa.Latitude + " , " + Pessoa.Longitude);
		}
		private void PopularCampoOpcional(Label campo, string conteudo)
		{
			(campo.GetParent() as Control).Visible = !string.IsNullOrEmpty(conteudo);
			campo.Text = conteudo;
		}
		private void _on_Editar_button_up()
		{
			MainCTRL.EditarPessoa(Pessoa);
		}
		private void _on_Button_button_up()
		{
			
		}
		public void FecharCTRL()
		{
			NomeCompleto.QueueFree();
			NomeSocial.QueueFree();
			Genero.QueueFree();
			Apelido.QueueFree();
			Localizacao.QueueFree();
			if (Pessoa != null)
				Pessoa.Dispose();
			QueueFree();
		}
	}
}
