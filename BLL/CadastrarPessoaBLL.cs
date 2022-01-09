using BLL.Interface;
using BibliotecaViva.DTO;

namespace BLL
{
    public class CadastrarPessoaBLL : ICadastrarPessoaBLL
    {
        public string ValidarPreenchimento(string nome, string sobrenome, string genero, string latitude, string longitude)
        {
            if (string.IsNullOrEmpty(nome))
            	return "Por favor preencher o Nome.";
            if (string.IsNullOrEmpty(sobrenome))
            	return "Por favor preencher o Sobrenome.";
            if (string.IsNullOrEmpty(genero))
            	return "Por favor preencher o Genero.";
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