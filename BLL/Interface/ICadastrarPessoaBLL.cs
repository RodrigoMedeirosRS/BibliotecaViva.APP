using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Interface
{
    public interface ICadastrarPessoaBLL
    {
        PessoaDTO PopularPessoa(string nome, string sobrenome, string genero, string apelido, string latlong);
        string CadastrarPessoa(PessoaDTO pessoa);
        
        void Dispose();
    }
}