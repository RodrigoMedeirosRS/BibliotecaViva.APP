using Godot;
using BibliotecaViva.DTO;

namespace BibliotecaViva.DTO
{
    public class RegistroObject : Object
    {
        public RegistroObject(RegistroDTO registro)
        {
            Registro = registro;
        }
        public RegistroDTO Registro { get; set; }
    }
}