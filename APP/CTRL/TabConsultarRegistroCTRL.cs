using Godot;

using BLL;
using BLL.Interface;
using CTRL.Interface;

namespace CTRL
{
	public class TabConsultarRegistroCTRL : Tabs, IDisposableCTRL
	{
		private IConsultarRegistroBLL BLL { get; set; }
		private LineEdit Nome { get ; set; }
		private OptionButton Idioma { get; set; }
		private Label Erro { get ; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new ConsultarRegistroBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Pesquisa/Nome");
			Erro = GetNode<Label>("./Dados/Erro");
			Idioma = GetNode<OptionButton>("./Pesquisa/Idioma");
		}
		private void _on_Pesquisar_button_up()
		{
			Erro.Text = BLL.ValidarPreenchimento(Nome.Text, Nome.Text);
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			Nome.QueueFree();
			Erro.QueueFree();
			Idioma.QueueFree();
			QueueFree();
		}
	}
}
