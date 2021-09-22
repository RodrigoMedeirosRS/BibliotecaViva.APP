using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.Interface;

namespace BLL
{
    public class CadastrarRegistroBLL : ICadastrarRegistroBLL
    {
        public string ValidarPreenchimento(string nome, string apelido, string latitude, string longitude, string descricao, string conteudo)
        {
            if (string.IsNullOrEmpty(nome))
            	return "Por favor preencher o Nome.";
            if (string.IsNullOrEmpty(apelido))
            	return "Por favor preencher o Apelido.";
            if (string.IsNullOrEmpty(descricao))
            	return "Por favor preencher o Descrição.";
            if (string.IsNullOrEmpty(conteudo))
            	return "Por favor preencher o Conteúdo.";
            if (!string.IsNullOrEmpty(latitude) || !string.IsNullOrEmpty(longitude))
                try
                {
                    var lat = double.Parse(latitude);
                    var lon = double.Parse(longitude);
                }
                catch
                {
                    return "Por favor preencher um valor de Latitude e Longitude com valores válidos.";
                }
            return string.Empty;
        }
    }
}