using BLL.Interface;

namespace BLL
{
    public class ConsultarPessoaBLL : IConsultarPessoaBLL
    {
        public string ValidarPreenchimento(string nome, string sobrenome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sobrenome))
                return "Favor inserir nome e sobrenome para a consulta";
            return string.Empty;
        }
    }
}