using Godot;

using BLL;

namespace CTRL
{
	public class MainCTRL : Node2D
	{
		private MainBLL BLL { get ; set; }
		public override void _Ready()
		{
			BLL = new MainBLL(GetNode<TabContainer>("./TabContainer"));
		}
		private void _on_CadastrarPessoa_button_up()
		{
			BLL.IntanciarTab("Cadastrar Pessoa", "res://TabCadastrarPessoa.tscn");
		}
		private void _on_CadatrarRegistro_button_up()
		{
			BLL.IntanciarTab("Cadastrar Registro", "res://TabCadastrarRegistro.tscn");
		}
		private void _on_ConsultarPessoa_button_down()
		{
			BLL.IntanciarTab("Consultar Pessoa", "res://TabConsultarPessoa.tscn");
		}
		private void _on_ConsultarRegistro_button_down()
		{
			BLL.IntanciarTab("Consultar Registro", "res://TabConsultarRegistro.tscn");
		}
	}
}
