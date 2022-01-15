using System;
using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class ConsultarPessoaBLL : IConsultarPessoaBLL, IDisposable
    {
        public string ValidarPreenchimento(string nome, string sobrenome)
        {
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(sobrenome))
                return "Favor inserir nome e sobrenome para a consulta";
            return string.Empty;
        }

        public void Dispose()
        {
            
        }
    }
}