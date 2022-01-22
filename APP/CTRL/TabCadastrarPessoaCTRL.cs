using Godot;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL;
using BibliotecaViva.DTO.Utils;
using BibliotecaViva.DTO.Dominio;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;

namespace BibliotecaViva.CTRL
{
	public class TabCadastrarPessoaCTRL : Tabs, IDisposableCTRL
	{
		public int CodigoPessoa { get; set; }
		private ICadastrarPessoaBLL BLL { get; set; }
		private IConsultarTipoBLL TipoBLL { get; set; }
		private IConsultarRegistroBLL RegistroBLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Sobrenome { get; set; }
		private LineEdit NomeBusca { get; set; }
		private LineEdit Genero { get; set; }
		private LineEdit Apelido { get; set; }
		private LineEdit LatLong { get ; set; }
		private Label Erro { get; set; }
		private Label Sucesso { get; set; }
		private VBoxContainer ContainerRelacao { get; set; }
		private OptionButton DropdownIdioma { get ; set; }
		private List<TipoRelacaoDTO> TiposRelacao { get; set; }
		private List<IdiomaDTO> Idiomas { get; set; }
		private LinhaRelacaoCTRL LinhaRelacao { get; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new CadastrarPessoaBLL();
			TipoBLL = new ConsultarTipoBLL();
			RegistroBLL = new ConsultarRegistroBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Inputs/Nome");
			NomeBusca = GetNode<LineEdit>("./BuscaRelacoes/Nome");
			Sobrenome = GetNode<LineEdit>("./Inputs/Sobrenome");
			Genero = GetNode<LineEdit>("./Inputs/Genero");
			Apelido = GetNode<LineEdit>("./Inputs/Apelido");
			LatLong = GetNode<LineEdit>("./Inputs/Latitude");
			Sucesso = GetNode<Label>("./Sucesso");
			Erro = GetNode<Label>("./Erro");
			DropdownIdioma = GetNode<OptionButton>("./BuscaRelacoes/Idioma");
			ContainerRelacao = GetNode<VBoxContainer>("./Inputs/ScrollContainer/VBoxContainer");
			LinhaRelacao = GetNode<LinhaRelacaoCTRL>("./LinhaRelacao");
			TiposRelacao = TipoBLL.ConsultarTiposRelacao();
			Idiomas = TipoBLL.PopularDropDownIdioma(DropdownIdioma);
			CodigoPessoa = 0;
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			Task.Run(async () => await RelizarEnvioRegistro());
		}
		private void _on_Buscar_button_up()
		{
			Task.Run(async () => await BuscarRegistros());
		}
		private void _on_Limpar_button_up()
		{
			NomeBusca.Text = string.Empty;
			LimparItensNaoRelacionados(false);
		}
		private void LimparItensNaoRelacionados(bool limparTudo)
		{
			foreach(var relacao in ContainerRelacao.GetChildren())
				if (!(relacao as LinhaRelacaoCTRL).ObterRelacao() || limparTudo)
					(relacao as LinhaRelacaoCTRL).RemoverLinha();
		}
		private async Task BuscarRegistros()
		{
			LimparItensNaoRelacionados(false);
			var resultado = RegistroBLL.RealizarConsulta(new RegistroConsulta()
			{
				Nome = NomeBusca.Text,
				Apelido = string.Empty,
				Idioma = DropdownIdioma.GetItemText(DropdownIdioma.Selected)
			});
			foreach (var registro in resultado)
			{
				CallDeferred("InstanciarPessoaBox", new RegistroObject(registro));
			}
		}
		private void InstanciarPessoaBox(RegistroObject registro)
		{
			var linhaRelacao = LinhaRelacao.Duplicate();
			ContainerRelacao.AddChild(linhaRelacao);
			linhaRelacao._Ready();
			(linhaRelacao as LinhaRelacaoCTRL).PopularRelacoes(TiposRelacao);
			(linhaRelacao as LinhaRelacaoCTRL).Nome.Text = registro.Registro.Nome;
			(linhaRelacao as LinhaRelacaoCTRL).CodigoRelacao = registro.Registro.Codigo;

		}
		public async Task RelizarEnvioRegistro()
		{
			try
			{
				var pessoa = BLL.PopularPessoa(Nome.Text, Sobrenome.Text, Genero.Text, Apelido.Text, LatLong.Text, CodigoPessoa, ObterListaDeRelacoes());
				LimparPreenchimento();
				LimparItensNaoRelacionados(true);
				var retorno = BLL.CadastrarPessoa(pessoa);
				CallDeferred("Feedback", retorno, true);
			}
			catch(Exception ex)
			{
				CallDeferred("Feedback", ex.Message, false);
			}
		}
		private List<RelacaoDTO> ObterListaDeRelacoes()
		{
			var lista = new List<RelacaoDTO>();

			foreach(var relacao in ContainerRelacao.GetChildren())
				if ((relacao as LinhaRelacaoCTRL).ObterRelacao())
					lista.Add(new RelacaoDTO()
					{
						RelacaoID = (relacao as LinhaRelacaoCTRL).CodigoRelacao,
						TipoRelacao = (relacao as LinhaRelacaoCTRL).ObterTipoRelacao().Nome
					});
		
			return lista;
		}
		private void Feedback(string mensagem, bool sucesso)
		{
			Sucesso.Text = sucesso ? mensagem : string.Empty;
			Erro.Text = sucesso ? string.Empty : mensagem;
		}
		public void PopularPreenchiento(PessoaDTO pessoa)
		{
			CodigoPessoa = pessoa.Codigo;
			Nome.Text = pessoa.Nome;
			Sobrenome.Text = pessoa.Sobrenome;
			Genero.Text = pessoa.Genero;
			Apelido.Text = pessoa.Apelido;
			LatLong.Text = pessoa.Latitude + ", " + pessoa.Longitude;
		}
		private void LimparPreenchimento()
		{
			CodigoPessoa = 0;
			Nome.Text = string.Empty;
			Sobrenome.Text = string.Empty;
			Genero.Text = string.Empty;
			Apelido.Text = string.Empty;
			LatLong.Text = string.Empty;
			NomeBusca.Text = string.Empty;
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			RegistroBLL.Dispose();
			TipoBLL.Dispose();
			Nome.QueueFree();
			NomeBusca.QueueFree();
			Sobrenome.QueueFree();
			Genero.QueueFree();
			Apelido.QueueFree();
			LatLong.QueueFree();
			Sucesso.QueueFree();
			Erro.QueueFree();
			foreach(var linha in ContainerRelacao.GetChildren())
				(linha as LinhaRelacaoCTRL).RemoverLinha();
			LinhaRelacao.RemoverLinha();
			ContainerRelacao.QueueFree();
			DropdownIdioma.QueueFree();
			Desalocador.DesalocarLista<TipoRelacaoDTO>(TiposRelacao);
			Desalocador.DesalocarLista<IdiomaDTO>(Idiomas);
			QueueFree();
		}
	}
}
