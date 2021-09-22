using Godot;
using System;

namespace CTRL
{
	public class ControladorTabCTRL : Control
	{
		private void _on_Button_button_up()
		{
			GetParent().QueueFree();
		}
	}  
}
