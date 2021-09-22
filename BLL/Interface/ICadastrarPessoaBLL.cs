namespace BLL.Interface
{
    public interface ICadastrarPessoaBLL
    {
        string ValidarPreenchimento(string nome, string sobrenome, string genero, string latitude, string longitude);
    }
}