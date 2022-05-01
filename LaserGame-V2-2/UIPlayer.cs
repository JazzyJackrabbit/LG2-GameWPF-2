using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaserGame_V2_2
{
    public class UIPlayer
    {
        MainService main;
        Material material;
        Materials materials;

        public bool isSelected = false;

        public UIPlayer(MainService main, Material parent)
        {
            this.main = main;
            this.materials = main.materials;
            this.material = parent;
        }

        internal void selectPlayer()
        {
            bool select = isSelected;
            foreach (Material material in materials.materials)
            {
                material.uiPlayer.isSelected = false;
            }
            isSelected = !select;
        }
    }
}
