using Godot;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabBuscarCTRL : Tabs, IDisposableCTRL
	{
		private AcceptDialog PopErro { get; set; }
		private PessoaBoxCTRL PessoaBox { get; set; }
		private PesquisaCTRL Pesquisa { get; set; }
		private Node Container { get; set; }
		private IConsultarRegistroBLL RegistroBLL { get; set; }
		private IConsultarPessoaBLL PessoaBLL { get; set; }
		public override void _Ready()
		{
			PoularNodes();
			RealizarInjecaoDeDependencias();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PoularNodes()
		{
			Pesquisa = GetNode<PesquisaCTRL>("./Pesquisa");
			PopErro = GetNode<AcceptDialog>("./PopErro");
			Container = GetNode<Node>("./ColorRect/Dados/Container");
			PessoaBox = GetNode<PessoaBoxCTRL>("./PessoaBox");
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
			Task.Run(async () => await RealizarBusca());
		}
		private async Task RealizarBusca()
		{
			try
			{
				if (Pesquisa.ConsultaPessoa())
					RealizarConsultaPessoa();
				RealizarConsultaRegistro();
			}
			catch(Exception ex)
			{
				CallDeferred("ExibirErro", ex.Message);
			}
		}
		private void ExibirErro(string mensagem)
		{
			PopErro.DialogText = mensagem;
			PopErro.Popup_();
		}
		private void RealizarConsultaPessoa()
		{
			var resultado = PessoaBLL.RealizarConsulta(new PessoaConsulta()
			{
				Nome = Pesquisa.Nome.Text,
				Sobrenome = Pesquisa.Sobrenome.Text,
				Apelido = Pesquisa.Apelido.Text
			});
			var posicao = new Vector2(0, 0);
			foreach (var pessoa in resultado)
			{
				CallDeferred("InstanciarPessoaBox", new PessoaObject(pessoa), posicao);
				posicao.y += 290;
			}
		}
		private void InstanciarPessoaBox(PessoaObject pessoaObjct, Vector2 posicao)
		{
			var pessoaBox = PessoaBox.Duplicate();
			RemoveChild(PessoaBox);
			Container.AddChild(pessoaBox);
			pessoaBox._Ready();
			(pessoaBox as PessoaBoxCTRL).Preencher(pessoaObjct.Pessoa, posicao);
		}
		private void RealizarConsultaRegistro()
		{

		}
		private void InstanciarRegistroBox(List<RegistroDTO> resultado)
		{
			
		}
		public void FecharCTRL()
		{
			PopErro.QueueFree();
			Pesquisa.FecharCTRL();
			RegistroBLL.Dispose();
			PessoaBLL.Dispose();
			foreach(var box in Container.GetChildren())
				(box as IDisposableCTRL).FecharCTRL();
			Container.QueueFree();
			QueueFree();
		}
	}
}
