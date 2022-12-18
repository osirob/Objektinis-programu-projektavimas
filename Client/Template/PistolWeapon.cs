using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Template
{
    public sealed class PistolWeapon : SelectedGun
    {
        public sealed override void ChangeNameToSelected()
        {
            Label? t = Application.OpenForms["Game"].Controls["updateWeaponNotif"] as Label;
            if (t != null)
            {
                t.Text = "Your purchased Pistol";
            }
        }

        public sealed override void UpdateCurrentGun()
        {
            Label? t = Application.OpenForms["Game"].Controls["weaponNameLabel"] as Label;
            if (t != null)
            {
                t.Text = "Pistol";
            }
        }
    }
}
