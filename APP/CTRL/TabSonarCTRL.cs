using Godot;
using System;

using BibliotecaViva.CTRL.Interface;

namespace CTRL
{
	public class TabSonarCTRL : Tabs, IDisposableCTRL
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
