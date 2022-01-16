using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interface
{
    public interface IConsultarRegistroBLL
    {
        void ValidarPreenchimento(RegistroConsulta registroConsulta);
        void Dispose();
    }
}