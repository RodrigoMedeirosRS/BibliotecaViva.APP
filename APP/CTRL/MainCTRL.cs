using Godot;

using BLL;
using BLL.Interface;

namespace CTRL
{
	public class MainCTRL : Node2D
	{
		private IMainBLL BLL { get ; set; }
		public override void _Ready()
		{
			BLL = new MainBLL(GetNode<TabContainer>("./TabContainer"));
		}
		private void _on_CadastrarPessoa_button_up()
		{
			BLL.IntanciarTab("Cadastrar Pessoa", "res://RES/CENAS/TabCadastrarPessoa.tscn");
		}
		private void _on_CadatrarRegistro_button_up()
		{
			BLL.IntanciarTab("Cadastrar Registro", "res://RES/CENAS/TabCadastrarRegistro.tscn");
		}
		private void _on_ConsultarPessoa_button_down()
		{
			BLL.IntanciarTab("Consultar Pessoa", "res://RES/CENAS/TabConsultarPessoa.tscn");
		}
		private void _on_ConsultarRegistro_button_down()
		{
			BLL.IntanciarTab("Consultar Registro", "res://RES/CENAS/TabConsultarRegistro.tscn");
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
	}
}
