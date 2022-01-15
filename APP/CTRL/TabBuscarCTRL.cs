using Godot;
using System;

namespace CTRL
{
	public class TabBuscarCTRL : Tabs
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
	}
}
