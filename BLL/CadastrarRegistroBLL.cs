using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.Interface;
using BibliotecaViva.BLL.Utils;

namespace BLL
{
    public class CadastrarRegistroBLL : ICadastrarRegistroBLL, IDisposable
    {
        public string ValidarPreenchimento(string nome, string apelido, string latlong, string descricao, string conteudo)
        {
            if (string.IsNullOrEmpty(nome))
            	return "Por favor preencher o Nome.";
            if (string.IsNullOrEmpty(apelido))
            	return "Por favor preencher o Apelido.";
            if (string.IsNullOrEmpty(descricao))
            	return "Por favor preencher o Descrição.";
            if (string.IsNullOrEmpty(conteudo))
            	return "Por favor preencher o Conteúdo.";
            if (!string.IsNullOrEmpty(latlong))
                try
                {
                    var coordenadas = TratadorUtil.ProcessarLatLong(latlong);
                }
                catch
                {
                    return "Por favor preencher um valor de Latitude e Longitude com valores válidos.";
                }
            return string.Empty;
        }
        public void Dispose()
        {
            
        }
    }
}