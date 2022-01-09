using Godot;
using System.Collections.Generic;

using BibliotecaViva.DTO;

namespace BLL.Interface
{
    public interface ICadastrarRegistroBLL
    {
        RegistroDTO PopularRegistro(string nome, string apelido, string latlong, string descricao, string conteudo, OptionButton tipoDropdown, OptionButton idiomaDropdown);
        string ValidarPreenchimento(string nome, string latlong, string descricao, string conteudo);
        string CadastrarRegistro(RegistroDTO registro);
        void Dispose();
    }
}