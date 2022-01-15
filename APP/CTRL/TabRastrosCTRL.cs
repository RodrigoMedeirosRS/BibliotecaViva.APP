using Godot;
using System;

using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabRastrosCTRL : Tabs, IDisposableCTRL
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
			SetProcess(false);
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
