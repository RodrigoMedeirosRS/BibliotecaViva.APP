using Godot;

namespace BibliotecaViva.BLL.Interface
{
    public interface IBuscarBLL
    {
        void InstanciarColuna();
        void RemoverColuna(Node linha);
        void Dispose();
    }
}