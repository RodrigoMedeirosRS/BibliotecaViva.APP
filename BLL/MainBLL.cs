using Godot;
using BLL.Utils;

using BLL.Interface;

namespace BLL
{
    public class MainBLL : IMainBLL
    {
        private TabContainer Container { get; set; }
        public MainBLL(TabContainer container)
        {
            Container = container;
        }
        public void IntanciarTab(string nomeTab, string caminhoTab)
        {
            InstanciadorUtil.InstanciarTab(Container, nomeTab, caminhoTab, false);
        }
    }
}