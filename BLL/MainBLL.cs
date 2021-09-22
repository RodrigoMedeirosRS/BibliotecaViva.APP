using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Utils;

namespace BLL
{
    public class MainBLL
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