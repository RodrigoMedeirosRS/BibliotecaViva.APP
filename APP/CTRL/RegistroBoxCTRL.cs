using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class RegistroBoxCTRL : Panel, IDisposableCTRL
	{
		public override void _Ready()
		{
			DesativarFuncoesDeAltoProcessamento();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		public void FecharCTRL()
		{
			QueueFree();
		}
	}
}
