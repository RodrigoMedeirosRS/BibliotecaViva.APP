using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL.Interface
{
    public interface IConsultarPessoaBLL
    {
        void ValidarPreenchimento(PessoaConsulta pessoaConsulta);
        void Dispose();
    }
}