using Godot;

using BLL.Interface;

namespace BLL
{
    public class MapaBLL : IMapaBLL
    {
        public void VerificarMouseParado(Vector2 mouseMovementAtual, Vector2 mouseMovementAnterior)
        {
			if (mouseMovementAtual == mouseMovementAnterior)
				mouseMovementAtual = new Vector2(0,0);
			else
				mouseMovementAnterior = mouseMovementAtual;
        }
        public void ControlarJanela(Sprite mapa, Vector2 mouseMovement, float delta)
		{
			Zoom(mapa, delta);
			Drag(mapa, mouseMovement, delta);
		}
        private void Zoom(Sprite mapa, float delta)
		{
			if (Input.IsActionJustReleased("ui_page_down"))
				AplicarZoom(mapa, 5f * delta);
			if (Input.IsActionJustReleased("ui_page_up"))
				AplicarZoom(mapa, -5f * delta);
		}

		private void AplicarZoom(Sprite mapa, float incremento)
		{
			mapa.Scale += new Vector2(incremento, incremento);
		}
		
		private void Drag(Sprite mapa, Vector2 mouseMovement, float delta)
		{
			if (Input.IsActionPressed("ui_accept"))
			{
				mapa.MoveLocalX(mouseMovement.x);
				mapa.MoveLocalY(mouseMovement.y);
			}
		}
    }
}