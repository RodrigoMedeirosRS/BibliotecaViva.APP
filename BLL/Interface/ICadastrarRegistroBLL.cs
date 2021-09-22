namespace BLL.Interface
{
    public interface ICadastrarRegistroBLL
    {
        string ValidarPreenchimento(string nome, string apelido, string latitude, string longitude, string descricao, string conteudo);
    }
}