using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class RegistroBoxCTRL : Panel, IDisposableCTRL
	{
		private Label Nome { get; set; }
		private Label Apelido { get; set; }
		private RichTextLabel Descricao { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Nome = GetNode<Label>("./Nome");
			Apelido = GetNode<Label>("./VBoxContainer/Apelido/Conteudo");
			Descricao = GetNode<RichTextLabel>("./VBoxContainer/Descricao/ScrollContainer/Conteudo");
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		public void Preencher(RegistroDTO registroDTO, Vector2 posicao)
		{
			RectPosition = posicao;
			Nome.Text = registroDTO.Nome;
			PopularCampoOpcional(Apelido, registroDTO.Apelido);
			PopularCampoOpcional(Descricao, registroDTO.Descricao);
		}
		private void PopularCampoOpcional(Label campo, string conteudo)
		{
			(campo.GetParent() as Control).Visible = !string.IsNullOrEmpty(conteudo);
			campo.Text = conteudo;
		}
		private void PopularCampoOpcional(RichTextLabel campo, string conteudo)
		{
			(campo.GetParent().GetParent() as Control).Visible = !string.IsNullOrEmpty(conteudo);
			campo.Text = conteudo;
		}
		private void _on_Editar_button_up()
		{
			
		}
		private void _on_Exibir_button_up()
		{
			
		}
		private void _on_Maximizar_button_up()
		{
			
		}
		public void FecharCTRL()
		{
			QueueFree();
		}
	}
}
