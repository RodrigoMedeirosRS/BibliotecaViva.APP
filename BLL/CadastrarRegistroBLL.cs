using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BLL.Utils;
using BLL.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.SAL;
using BibliotecaViva.BLL.Utils;
using BibliotecaViva.SAL.Interface;

namespace BLL
{
    public class CadastrarRegistroBLL : ICadastrarRegistroBLL, IDisposable
    {
        private IRequisicao SAL { get; set; }
        private string URLCadastroRegistro { get; set; }
        public CadastrarRegistroBLL()
        {
            URLCadastroRegistro = Apontamentos.URLApi + "/Registro/Cadastrar";
            SAL = new Requisicao();
        }
        public string ValidarPreenchimento(string nome, string latlong, string descricao, string conteudo, TipoDTO tipoSelecionado)
        {
            if (string.IsNullOrEmpty(nome))
            	return "Por favor preencher o Nome.";
            if (string.IsNullOrEmpty(descricao))
            	return "Por favor preencher o Descrição.";
            if (tipoSelecionado.Binario)
            {
                try
                {
                    if (string.IsNullOrEmpty(conteudo))
                        throw new Exception("Por favor selecione um arquivo para envio");
                    ValidarConteudoBinario(conteudo, tipoSelecionado.Extensao);
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(conteudo))
            	    return "Por favor preencher o Conteúdo.";
            }    
            if (!string.IsNullOrEmpty(latlong))
            {
                try
                {
                    var coordenadas = TratadorUtil.ProcessarLatLong(latlong);
                }
                catch
                {
                    return "Por favor preencher um valor de Latitude e Longitude com valores válidos.";
                }
            }
            return string.Empty;
        }
        public void ValidarConteudoBinario(string caminhoConteudo, string extensao)
        {
            if(!string.IsNullOrEmpty(caminhoConteudo) && !caminhoConteudo.Contains(extensao))
                throw new Exception("Arquivo inválido! Por favor selecione um arquivo do tipo " + extensao);
        }
        public RegistroDTO PopularRegistro(string nome, string apelido, string latlong, string descricao, string conteudo, TipoDTO tipoSelecionado, OptionButton idiomaDropdown)
        {
            ValidarPreenchimento(nome, latlong, descricao, conteudo, tipoSelecionado);

            var registro = new RegistroDTO()
            {
                Nome = nome,
                Descricao = descricao,
                Conteudo = conteudo,
                Apelido = apelido,
                Tipo = tipoSelecionado.Nome,
                Idioma = idiomaDropdown.GetItemText(idiomaDropdown.Selected)
            };

            return string.IsNullOrEmpty(latlong) ? registro : PopularCoordenadas(registro, latlong);
        }
        private RegistroDTO PopularCoordenadas(RegistroDTO registro, string latlong)
        {
            var coordenadas = TratadorUtil.ProcessarLatLong(latlong);
            registro.Latitude = coordenadas[0];
            registro.Longitude = coordenadas[1];
            return registro;
        }
        public string CadastrarRegistro(RegistroDTO registro)
        {    
            return SAL.ExecutarPost<RegistroDTO, string>(URLCadastroRegistro, registro);
        }
        public void Dispose()
        {
            URLCadastroRegistro = null;
            SAL.Dispose();
        }
    }
}