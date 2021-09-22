namespace DTO
{
    public class PessoaRegistroDTO : BaseDTO
    {
        public int? Pessoa { get; set; }
        public int? Registro { get; set; }
        public string TipoRelacao { get; set; }
    }
}