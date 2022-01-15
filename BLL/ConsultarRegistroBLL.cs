using System;

using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class ConsultarRegistroBLL : IConsultarRegistroBLL, IDisposable
    {
        public string ValidarPreenchimento(string nome, string apelido)
        {
            if (string.IsNullOrEmpty(nome) && string.IsNullOrEmpty(apelido))
                return "Favor inserir nome ou apelido para a consulta";
            return string.Empty;
        }

        public void Dispose()
        {
            
        }
    }
}