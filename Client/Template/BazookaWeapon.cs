using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Template
{
    public sealed class BazookaWeapon : SelectedGun
    {
        public override void ChangeNameToSelected()
        {
            Label? t = Application.OpenForms["Game"].Controls["updateWeaponNotif"] as Label;
            if (t != null)
            {
                t.Text = "Your purchased Bazooka";
            }
        }

        public override void UpdateCurrentGun()
        {
            Label? t = Application.OpenForms["Game"].Controls["weaponNameLabel"] as Label;
            if (t != null)
            {
                t.Text = "Bazooka";
            }
        }
    }
}
