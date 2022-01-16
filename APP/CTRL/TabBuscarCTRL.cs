using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabBuscarCTRL : Tabs, IDisposableCTRL
	{
		private ConfirmationDialog PopErro { get; set; }
		private PesquisaCTRL Pesquisa { get; set; }
		private IConsultarRegistroBLL RegistroBLL { get; set; }
		private IConsultarPessoaBLL PessoaBLL { get; set; }
		public override void _Ready()
		{
			DesativarFuncoesDeAltoProcessamento();
			PoularNodes();
		}
		private void PoularNodes()
		{
			Pesquisa = GetNode<PesquisaCTRL>("./Pesquisa");
			PopErro = GetNode<ConfirmationDialog>("./PopErro");
			GD.Print(Pesquisa.Name);
		}
		private void RealizarInjecaoDeDependencias()
		{
			RegistroBLL = new ConsultarRegistroBLL();
			PessoaBLL = new ConsultarPessoaBLL();	
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void _on_Pesquisar_button_up()
		{
			try
			{
				if (Pesquisa.ConsultaPessoa())
					RealizarConsultaPessoa();
				RealizarConsultaRegistro();
			}
			catch(Exception ex)
			{
				PopErro.DialogText = ex.Message;
				PopErro.Popup_();
			}
		}
		private void RealizarConsultaPessoa()
		{
			
		}
		private void RealizarConsultaRegistro()
		{

		}
		public void FecharCTRL()
		{
			PopErro.QueueFree();
			Pesquisa.FecharCTRL();
			RegistroBLL.Dispose();
			PessoaBLL.Dispose();
			QueueFree();
		}
	}
}
