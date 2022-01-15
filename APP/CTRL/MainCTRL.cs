using Godot;

using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class MainCTRL : Node2D, IDisposableCTRL
	{
		private IMainBLL BLL { get ; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
			ReposicionarTela();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new MainBLL(GetNode<TabContainer>("./TabContainer"));
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void ReposicionarTela()
		{
			if (OS.GetName() == "Windows")
			{
				var screen_size = OS.GetScreenSize(0);
				var window_size = OS.WindowSize;
				OS.WindowPosition = screen_size * 0.5f - window_size * 0.5f;
			}
		}
		private void _on_CadastrarPessoa_button_up()
		{
			BLL.IntanciarTab("Cadastrar Pessoa", "res://RES/CENAS/TabCadastrarPessoa.tscn");
		}
		private void _on_CadatrarRegistro_button_up()
		{
			BLL.IntanciarTab("Cadastrar Registro", "res://RES/CENAS/TabCadastrarRegistro.tscn");
		}
		private void _on_Buscar_button_up()
		{
			BLL.IntanciarTab("Buscar", "res://RES/CENAS/TabBuscar.tscn");
		}
		private void _on_Sonar_button_up()
		{
			BLL.IntanciarTab("Sonar", "res://RES/CENAS/TabSonar.tscn");
		}
		private void _on_Rastros_button_up()
		{
			BLL.IntanciarTab("Rastros", "res://RES/CENAS/TabRastros.tscn");
		}
		private void _on_Ping_button_up()
		{
			BLL.IntanciarTab("Ping", "res://RES/CENAS/TabPing.tscn");
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			QueueFree();
		}
	}
}
