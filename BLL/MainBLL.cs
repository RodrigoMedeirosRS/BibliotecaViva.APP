using Godot;
using System;

using BibliotecaViva.BLL.Utils;
using BibliotecaViva.BLL.Interface;

namespace BibliotecaViva.BLL
{
    public class MainBLL : IMainBLL, IDisposable
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

        public void Dispose()
        {
            
        }
    }
}