using System;
using BibliotecaViva.BLL.Interface;

using BibliotecaViva.SAL;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.SAL.Interface;
using BibliotecaViva.DTO.Dominio;

namespace BibliotecaViva.BLL
{
    public class ConsultarPessoaBLL : IConsultarPessoaBLL, IDisposable
    {
        private IRequisicao SAL { get; set; }
        private string URLConsultarPessoa { get; set; }
        public void ValidarPreenchimento(PessoaConsulta pessoaConsulta)
        {
            if (string.IsNullOrEmpty(pessoaConsulta.Nome) && string.IsNullOrEmpty(pessoaConsulta.Sobrenome) && string.IsNullOrEmpty(pessoaConsulta.Apelido))
                throw new Exception("Favor inserir nome, sobrenome ou apelido para realizar a consulta");
        }
        public ConsultarPessoaBLL()
        {
            SAL = new Requisicao();
            URLConsultarPessoa = Apontamentos.URLApi + "/Pessoa/Consultar";
        }

        public void Dispose()
        {
            
        }
    }
}