using Godot;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.CTRL.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.DTO.Utils;
using BibliotecaViva.BLL.Utils;

namespace BibliotecaViva.CTRL
{
	public class TabCadastrarRegistroCTRL : Tabs, IDisposableCTRL
	{
		private IConsultarTipoBLL BLLTipo { get; set; }
		private ICadastrarRegistroBLL BLL { get; set; }
		private LineEdit Nome { get; set; }
		private LineEdit Apelido { get; set; }
		private LineEdit LatLong { get ; set; }
		private Label Erro { get; set; }
		private Label Sucesso { get; set; }
		private OptionButton Idioma { get ; set; }
		private OptionButton Tipo { get; set; }
		private List<TipoDTO> Tipos { get; set; }
		private TipoDTO TipoSelecionado { get; set; }
		private TextEdit Descricao { get; set; }
		private TextEdit ConteudoASCII { get; set; }
		private Button ConteudoBIN { get; set; }
		private LineEdit CaminhoBIN { get; set; }
		private FileDialog ModalDeBusca { get; set; }
		public override void _Ready()
		{
			RealizarInjecaoDeDependencias();
			PopularNodes();
			DesativarFuncoesDeAltoProcessamento();
			PopularDropDowns();
		}
		private void RealizarInjecaoDeDependencias()
		{
			BLL = new CadastrarRegistroBLL();
			BLLTipo = new ConsultarTipoBLL();
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}		
		private void PopularNodes()
		{
			Nome = GetNode<LineEdit>("./Inputs/Nome");
			Apelido = GetNode<LineEdit>("./Inputs/Apelido");
			LatLong = GetNode<LineEdit>("./Inputs/LatLong");
			Idioma = GetNode<OptionButton>("./Inputs/Idioma");
			Tipo = GetNode<OptionButton>("./Inputs/Tipo");
			Erro = GetNode<Label>("./Inputs/Erro");
			Sucesso = GetNode<Label>("./Inputs/Sucesso");
			Descricao = GetNode<TextEdit>("./Inputs/Descricao");
			ConteudoASCII = GetNode<TextEdit>("./Inputs/Conteudo/ConteudoASCII");
			ConteudoBIN = GetNode<Button>("./Inputs/Conteudo/ConteudoBIN");
			CaminhoBIN = GetNode<LineEdit>("./Inputs/Conteudo/ConteudoBIN/CaminhoBIN");
			ModalDeBusca = GetNode<FileDialog>("./ModalDeBusca");
		}
		private void _on_SalvarAlteracoes_button_up()
		{
			Task.Run(async () => await RelizarEnvioRegistro());
		}
		public async Task RelizarEnvioRegistro()
		{
			try
			{
				var registro = new RegistroDTO();
				if (TipoSelecionado.Binario)
					registro = BLL.PopularRegistro(Nome.Text, Apelido.Text, LatLong.Text, Descricao.Text, CarregarArquivoBinario(), TipoSelecionado, Idioma);
				else
					registro = BLL.PopularRegistro(Nome.Text, Apelido.Text, LatLong.Text, Descricao.Text, ConteudoASCII.Text, TipoSelecionado, Idioma);
				LimparPreenchimento();
				var retorno = BLL.CadastrarRegistro(registro);
				CallDeferred("Feedback", retorno, true);
			}
			catch(Exception ex)
			{
				CallDeferred("Feedback", ex.Message, false);
			}
		}
		private string CarregarArquivoBinario()
		{
			return ImportadorDeBinariosUtil.ObterBase64(CaminhoBIN.Text);
		}
		private void Feedback(string mensagem, bool sucesso)
		{
			Sucesso.Text = sucesso ? mensagem : string.Empty;
			Erro.Text = sucesso ? string.Empty : mensagem;
		}
		public void PopularDropDowns()
		{
			BLLTipo.PopularDropDownIdioma(Idioma);
			Tipos = BLLTipo.PopularDropDownTipo(Tipo);
			ObterDadosExtensao(Tipo.GetItemText(0));
		}
		private void _on_Tipo_item_selected(int index)
		{
			ObterDadosExtensao(Tipo.GetItemText(index));
			AlternarVisibulidadeCampoConteudo();
		}
		private void ObterDadosExtensao(string nomeTipo)
		{
			TipoSelecionado = (from tipo in Tipos where tipo.Nome == nomeTipo select tipo).FirstOrDefault();
		}
		private void AlternarVisibulidadeCampoConteudo()
		{
			ConteudoBIN.Visible = TipoSelecionado.Binario;
			ConteudoASCII.Visible = !TipoSelecionado.Binario;
		}
		private void LimparPreenchimento()
		{
			Nome.Text = string.Empty;
			Apelido.Text = string.Empty; 
			LatLong.Text = string.Empty; 
			Descricao.Text = string.Empty; 
			ConteudoASCII.Text = string.Empty;
			CaminhoBIN.Text = string.Empty;
		}
		private void _on_CaminhoBIN_text_changed(String new_text)
		{
			ValidarArquivoBinario(new_text);
		}
		private void _on_ModalDeBusca_file_selected(String path)
		{
			CaminhoBIN.Text = path;
		}
		private void ValidarArquivoBinario(string new_text)
		{
			try
			{
				BLL.ValidarConteudoBinario(new_text, TipoSelecionado.Extensao);
				Erro.Text = string.Empty;
			}
			catch (Exception ex)
			{
				Feedback(ex.Message, false);
			}
		}
		private void _on_ConteudoBIN_button_up()
		{
			ModalDeBusca.Popup_();
		}
		public void FecharCTRL()
		{
			BLL.Dispose();
			BLLTipo.Dispose();
			TipoSelecionado.Dispose();
			Nome.QueueFree();
			Apelido.QueueFree();
			LatLong.QueueFree();
			Idioma.QueueFree();
			Tipo.QueueFree();
			Erro.QueueFree();
			Sucesso.QueueFree();
			Descricao.QueueFree();
			ConteudoASCII.QueueFree();
			ConteudoBIN.QueueFree();
			CaminhoBIN.QueueFree();
			ModalDeBusca.QueueFree();
			Desalocador.DesalocarLista<TipoDTO>(Tipos);
			QueueFree();
		}
	}
}
