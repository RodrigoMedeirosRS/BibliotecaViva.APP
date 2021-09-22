using Godot;
using System;

namespace CTRL
{
	public class MainCTRL : Node2D
	{
		private TabContainer Container { get ; set; }
		public override void _Ready()
		{
			Container = GetNode<TabContainer>("./TabContainer");
		}
		private void _on_CadastrarPessoa_button_up()
		{
			// Replace with function body.
		}
		private void _on_CadatrarRegistro_button_up()
		{
			// Replace with function body.
		}
		private void _on_ConsultarPessoa_button_down()
		{
			// Replace with function body.
		}
		private void _on_ConsultarRegistro_button_down()
		{
			// Replace with function body.
		}
	}
}
