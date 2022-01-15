namespace BibliotecaViva.BLL.Interface
{
    public interface IConsultarPessoaBLL
    {
        string ValidarPreenchimento(string nome, string sobrenome);
        void Dispose();
    }
}