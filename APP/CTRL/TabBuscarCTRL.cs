using Godot;
using System;

using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabBuscarCTRL : Tabs, IDisposableCTRL
	{
		public PesquisaCTRL Pesquisa { get; set; }
		public override void _Ready()
		{
			DesativarFuncoesDeAltoProcessamento();
			PoularNodes();
		}
		private void PoularNodes()
		{
			Pesquisa = GetNode<PesquisaCTRL>("./Pesquisa");
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void _on_Pesquisar_button_up()
		{
			// Replace with function body.
		}
		public void FecharCTRL()
		{
			Pesquisa.FecharCTRL();
			QueueFree();
		}
	}
}
