using System;

using BibliotecaViva.DTO.Dominio;


using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class ConsultarRegistroBLL : IConsultarRegistroBLL, IDisposable
    {
        public void ValidarPreenchimento(RegistroConsulta registroConsulta)
        {
            if (string.IsNullOrEmpty(registroConsulta.Nome) && string.IsNullOrEmpty(registroConsulta.Apelido))
                throw new Exception("Favor inserir nome ou apelido para realizar a consulta");
        }

        public void Dispose()
        {
            
        }
    }
}