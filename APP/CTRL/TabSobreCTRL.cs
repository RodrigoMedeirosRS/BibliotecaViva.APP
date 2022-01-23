using Godot;

using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabSobreCTRL : Tabs, IDisposableCTRL
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
