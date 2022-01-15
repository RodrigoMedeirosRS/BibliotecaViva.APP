using Godot;
using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BLL.Interface
{
    public interface ICadastrarRegistroBLL
    {
        RegistroDTO PopularRegistro(string nome, string apelido, string latlong, string descricao, string conteudo, TipoDTO tipoSelecionado, OptionButton idiomaDropdown);
        string ValidarPreenchimento(string nome, string latlong, string descricao, string conteudo, TipoDTO tipoSelecionado);
        void ValidarConteudoBinario(string caminhoConteudo, string extensao);
        string CadastrarRegistro(RegistroDTO registro);
        void Dispose();
    }
}