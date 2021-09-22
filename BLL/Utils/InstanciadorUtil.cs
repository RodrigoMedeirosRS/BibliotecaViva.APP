using Godot;

namespace BLL.Utils
{
    public static class InstanciadorUtil
    {
        public static PackedScene CarregarCena(string caminho)
        {
            return ResourceLoader.Load(caminho) as PackedScene;
        }
        public static Node InstanciarObjeto(Node container, PackedScene cena, Vector2? posicao)
        {
            var cenaInstanciada = cena.Instance();
            container.AddChild(cenaInstanciada);
            return SetConstrolData(cenaInstanciada, posicao);
        }
        private static Node SetConstrolData(Node cenaInstanciada, Vector2? posicao)
        {
            if (posicao != null)
                (cenaInstanciada as Control).RectPosition = (Vector2)posicao;
            return cenaInstanciada;
        }
        public static void DecarregarFilhos(Node container)
        {
            if (container.GetChildCount() > 0)
                container.GetChild(0).QueueFree();
        }
        public static void InstanciarTab(TabContainer container, string nomeTab, string caminhoTab, bool permitirDuplicada)
        {
            var cena = InstanciadorUtil.CarregarCena(caminhoTab);
            if (!VerificarTabDuplicada(container, nomeTab) || permitirDuplicada)
            {
                var tab = InstanciadorUtil.InstanciarObjeto(container, cena, null);
                tab.Name = nomeTab;
                container.CurrentTab = container.GetChildCount() -1;   
            }             
        }
        private static bool VerificarTabDuplicada(Node container, string nomeTab)
        {
            foreach(var node in container.GetChildren())
                if ((node as Node).Name == nomeTab)
                    return true;
            return false;
        }
    }
}