using System;

using BibliotecaViva.BLL.Utils;
using BibliotecaViva.BLL.Interface;
using BibliotecaViva.DTO;
using BibliotecaViva.SAL;
using BibliotecaViva.SAL.Interface;

namespace BibliotecaViva.BLL
{
    public class CadastrarPessoaBLL : ICadastrarPessoaBLL, IDisposable
    {
        private IRequisicao SAL { get; set; }
        private string URLCadastroPessoa { get; set; }
        public CadastrarPessoaBLL()
        {
            URLCadastroPessoa = Apontamentos.URLApi + "/Pessoa/Cadastrar";
            SAL = new Requisicao();
        }
        private void ValidarPreenchimento(string nome, string sobrenome, string genero, string latlong)
        {
            if (string.IsNullOrEmpty(nome))
            	throw new Exception("Por favor preencher o Nome.");
            if (string.IsNullOrEmpty(sobrenome))
            	throw new Exception("Por favor preencher o Sobrenome.");
            if (string.IsNullOrEmpty(genero))
            	throw new Exception("Por favor preencher o Genero.");
            if (!string.IsNullOrEmpty(latlong))
                try
                {
                    var coordenadas = TratadorUtil.ProcessarLatLong(latlong);
                }
                catch(Exception ex)
                {
                    throw new Exception("Por favor preencher um valor de Latitude e Longitude com valores válidos.");
                }
        }
        public PessoaDTO PopularPessoa(string nome, string sobrenome, string genero, string apelido, string latlong)
        {
            ValidarPreenchimento(nome, sobrenome, genero, latlong);

            var pessoa = new PessoaDTO()
            {
                Nome = nome,
                Sobrenome = sobrenome,
                Apelido = apelido,
                NomeSocial = string.Empty,
                Genero = genero
            };

            return string.IsNullOrEmpty(latlong) ? pessoa : PopularCoordenadas(pessoa, latlong);
        }
        private PessoaDTO PopularCoordenadas(PessoaDTO pessoa, string latlong)
        {
            var coordenadas = TratadorUtil.ProcessarLatLong(latlong);
            pessoa.Latitude = coordenadas[0];
            pessoa.Longitude = coordenadas[1];
            return pessoa;
        }
        public string CadastrarPessoa(PessoaDTO pessoa)
        {    
            return SAL.ExecutarPost<PessoaDTO, string>(URLCadastroPessoa, pessoa);
        }
        public void Dispose()
        {
            URLCadastroPessoa = null;
            SAL.Dispose();
        }
    }
}