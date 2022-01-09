namespace BLL
{
    public interface IConsultarRegistroBLL
    {
        string ValidarPreenchimento(string nome, string apelido);
        void Dispose();
    }
}