namespace BLL.Interface
{
    public interface ICadastrarRegistroBLL
    {
        string ValidarPreenchimento(string nome, string apelido, string latlong, string descricao, string conteudo);
        void Dispose();
    }
}