namespace BibliotecaViva.BLL.Interface
{
    public interface IConsultarRegistroBLL
    {
        string ValidarPreenchimento(string nome, string apelido);
        void Dispose();
    }
}