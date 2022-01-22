using Godot;
using System;

using BibliotecaViva.DTO;

namespace BibliotecaViva.CTRL
{
	public class LinhaRelacaoCTRL : Control
	{
		public RegistroDTO Registro { get; set; }
		public PessoaDTO Pessoa { get; set; }
		private bool Relacionado { get; set; }
		public override void _Ready()
		{
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		public bool ObterRelacao()
		{
			return Relacionado;
		}
		public void DefinirRelacao(bool relacionado)
		{
			Relacionado = relacionado;
		}
		private void _on_TextureButton_toggled(bool button_pressed)
		{
			Relacionado = button_pressed;
		}
	}
}
