using Godot;
using System;

using BibliotecaViva.DTO;
using BibliotecaViva.BLL;
using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.CTRL
{
	public class PesquisaCTRL : Control
	{
		private OptionButton Idioma { get; set; }
		private LineEdit Sobrenome { get; set; }
		private OptionButton Tipo { get; set; }
		public override void _Ready()
		{
			PopularNodes();
			PopularDropDowns();
			DesativarFuncoesDeAltoProcessamento();
		}
		private void PopularNodes()
		{
			Idioma = GetNode<OptionButton>("./Idioma");
			Sobrenome = GetNode<LineEdit>("./Sobrenome");
			Tipo = GetNode<OptionButton>("./Tipo");
		}
		private void PopularDropDowns()
		{
			PoularTipoDropDown();
		}
		private void PoularTipoDropDown()
		{
			Tipo.AddItem("Pessoa");
			Tipo.AddItem("Registro");
			Tipo.Select(0);
			AlternarOpcoesDeBusca(0);
		}
		private void DesativarFuncoesDeAltoProcessamento()
		{
			SetPhysicsProcess(false);
			SetProcess(false);
		}
		private void AlternarOpcoesDeBusca(int index)
		{
			Sobrenome.Visible = Tipo.GetItemText(index) == "Pessoa";
			Idioma.Visible = Tipo.GetItemText(index) == "Registro";
		}
		private void _on_Tipo_item_selected(int index)
		{
			AlternarOpcoesDeBusca(index);
		}
	}
}
