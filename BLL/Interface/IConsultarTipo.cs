using Godot;
using System;
using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BLL.Interface
{
    public interface IConsultarTipo
    {
        List<TipoDTO> ConsultarTipos();
        List<TipoRelacaoDTO> ConsultarTiposRelacao();
        List<IdiomaDTO> ConsultarIdiomas();
        void PopularDropDownTipo(OptionButton dropdown);
        void PopularDropDownTipoRelacao(OptionButton dropdown);
        void PopularDropDownIdioma(OptionButton dropdown);

        void Dispose();
    }
}