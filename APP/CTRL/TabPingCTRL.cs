using Godot;
using System;

using BLL;
using BLL.Interface;
using CTRL.Interface;

namespace CTRL
{
	public class TabPingCTRL : Tabs, IDisposableCTRL
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
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
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
			try
			{
				BLL.VerificarMouseParado(MouseMovementAtual, MouseMovementAnterior);
				BLL.ControlarJanela(Mapa, MouseMovementAtual, delta);
			}
			catch(Exception ex)
			{
				GD.Print(ex.Message);
			}
		}
		public override void _Input(InputEvent @event)
		{
			if (@event.GetType().ToString() == "Godot.InputEventMouseMotion")
				MouseMovementAtual = (@event as InputEventMouseMotion).Relative;
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			Mapa.QueueFree();
			QueueFree();
		}
	}
}
