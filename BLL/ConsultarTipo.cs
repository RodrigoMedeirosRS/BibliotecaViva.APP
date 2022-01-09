using Godot;
using System;
using System.Collections.Generic;

using BLL.Utils;
using BLL.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.SAL;
using BibliotecaViva.DTO.Interface;
using BibliotecaViva.SAL.Interface;

namespace BLL
{
    public class ConsultarTipo : IConsultarTipo, IDisposable
    {
        private IRequisicao SAL { get; set; }
        private string URLConsultarIdioma { get; set; }
        private string URLConsultarTipo { get; set; }
        private string URLConsultarTipoRelacao { get; set; }
        public ConsultarTipo()
        {
            SAL = new Requisicao();
            URLConsultarIdioma = Apontamentos.URLApi + "/Tipo/ConsultarIdiomas";
            URLConsultarTipo = Apontamentos.URLApi + "/Tipo/ConsultarTipos";
            URLConsultarTipoRelacao = Apontamentos.URLApi + "/Tipo/ConsultarTiposRelacao";
        }
        public List<TipoDTO> ConsultarTipos()
        {
            return SAL.ExecutarPost<string, List<TipoDTO>>(URLConsultarTipo, "Consultar");
        }
        public List<TipoRelacaoDTO> ConsultarTiposRelacao()
        {
            return SAL.ExecutarPost<string, List<TipoRelacaoDTO>>(URLConsultarTipoRelacao, "Consultar");
        }
        public List<IdiomaDTO> ConsultarIdiomas()
        {
            return SAL.ExecutarPost<string, List<IdiomaDTO>>(URLConsultarIdioma, "Consultar");
        }
        public void PopularDropDownTipo(OptionButton dropdown)
        {
            PopularDropdown<TipoDTO>(ConsultarTipos(), dropdown);
        }
        public void PopularDropDownTipoRelacao(OptionButton dropdown)
        {
            PopularDropdown<TipoRelacaoDTO>(ConsultarTiposRelacao(), dropdown);
        }
        public void PopularDropDownIdioma(OptionButton dropdown)
        {
            PopularDropdown<IdiomaDTO>(ConsultarIdiomas(), dropdown); 
        }
        private void PopularDropdown<T>(List<T> itens, OptionButton dropdown) where T : INomeado
        {
            foreach(var item in itens)
                dropdown.AddItem(item.Nome);
        }

        public void Dispose()
        {
            SAL.Dispose();
            URLConsultarTipo = null;
            URLConsultarTipoRelacao = null;
            URLConsultarIdioma = null;
        }
    }
}