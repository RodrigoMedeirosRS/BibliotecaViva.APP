using BibliotecaViva.DTO;

namespace BLL.Utils
{
    public class RegistroObject
    {
        public RegistroObject(RegistroDTO registro)
        {
            Registro = registro;
        }
        public RegistroDTO Registro { get; set; }
    }
}