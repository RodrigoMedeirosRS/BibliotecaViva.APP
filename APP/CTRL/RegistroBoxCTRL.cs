using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Utils;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class RegistroBoxCTRL : Panel, IDisposableCTRL
	{
		private bool Maximizado { get; set; }
		private Label Nome { get; set; }
		private Label Apelido { get; set; }
		private RichTextLabel Descricao { get; set; }
		private RichTextLabel ConteudoTextual { get; set; }
		private ColorRect FundoBox { get; set; }
		private RegistroDTO Registro { get; set; }
		private Control CampoDescricao { get; set; }
		private Control CampoImagem { get; set; }
		private Control CampoTextual { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Maximizado = false;
			Nome = GetNode<Label>("./Nome");
			Apelido = GetNode<Label>("./VBoxContainer/Apelido/Conteudo");
			Descricao = GetNode<RichTextLabel>("./VBoxContainer/Descricao/ScrollContainer/Conteudo");
			ConteudoTextual = GetNode<RichTextLabel>("./VBoxContainer/Texto/ScrollContainer/Conteudo");
			
			FundoBox = GetNode<ColorRect>("./Controladores/ColorRect");
			CampoTextual = GetNode<Control>("./VBoxContainer/Texto");
			CampoImagem = GetNode<Control>("./VBoxContainer/Imagem");
			CampoDescricao = GetNode<Control>("./VBoxContainer/Descricao");
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		public void Preencher(RegistroDTO registroDTO, Vector2 posicao)
		{
			RectPosition = posicao;
			Registro = registroDTO;
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
			GD.Print(TipoExecucao.Audio.ToString() + " " + Registro.Tipo);
			if (Maximizado)
				ExibirDescricao();
			else
				ExibirCampo();
			
		}
		private void ExibirCampo()
		{
			if (Registro.Tipo == TipoExecucao.Audio.ToString())
			{
				CampoTextual.Visible = false;
				CampoDescricao.Visible = false;
				CampoImagem.Visible = false;
			}
			else if (Registro.Tipo == TipoExecucao.Imagem.ToString())
			{
				CampoImagem.Visible = true;
				CampoDescricao.Visible = false;
				CampoTextual.Visible = false;
			}

			else if (Registro.Tipo == TipoExecucao.Texto.ToString())
			{
				
				ExibirRegistroTextual();
			}

			else if (Registro.Tipo == TipoExecucao.Arquivo.ToString())
			{
				CampoDescricao.Visible = false;
				CampoImagem.Visible = false;
				CampoTextual.Visible = true;
			}
			else if (Registro.Tipo == TipoExecucao.URL.ToString())
			{
				CampoDescricao.Visible = false;
				CampoImagem.Visible = false;
				CampoTextual.Visible = true;
			}
		}
		private void ExibirDescricao()
		{
			CampoDescricao.Visible = true;
			CampoImagem.Visible = false;
			CampoTextual.Visible = false;
			FundoBox.RectSize = new Vector2(400, 303);
			RectSize = new Vector2(400, 303);
		}
		private void ExibirRegistroTextual()
		{
			CampoTextual.Visible = true;
			CampoDescricao.Visible = false;
			CampoImagem.Visible = false;
			FundoBox.RectSize = new Vector2(400, 535);
			RectSize = new Vector2(400, 535);
			
			ConteudoTextual.Text = Registro.Conteudo;
		}
		private void ExibirRegistroImagem()
		{
			
		}
		public void FecharCTRL()
		{
			QueueFree();
		}
	}
}
