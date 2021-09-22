using Godot;
using System;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class TabPingCTRL : Tabs
	{
		private Sprite Mapa { get ; set; }
		private IMapaBLL BLL { get; set; }
		private Vector2 MouseMovementAtual { get; set; }
		private Vector2 MouseMovementAnterior { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			RealizarInjecaoDeDependencias();
		}
		public void PopularNodes()
		{
			MouseMovementAtual = new Vector2(0,0);
			MouseMovementAnterior = new Vector2(0,0);
			Mapa = GetNode<Sprite>("./AreaDoMapa/Mapa");
		}
		public void RealizarInjecaoDeDependencias()
		{
			BLL = new MapaBLL();
		}
		public override void _Process(float delta)
		{
			BLL.VerificarMouseParado(MouseMovementAtual, MouseMovementAnterior);
			BLL.ControlarJanela(Mapa, MouseMovementAtual, delta);
		}
		public override void _Input(InputEvent @event)
		{
			if (@event.GetType().ToString() == "Godot.InputEventMouseMotion")
				MouseMovementAtual = (@event as InputEventMouseMotion).Relative;
		}
	}
}
