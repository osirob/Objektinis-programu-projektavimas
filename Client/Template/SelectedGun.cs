using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Template
{
    public abstract class SelectedGun
    {
        public abstract void ChangeNameToSelected();
        public abstract void UpdateCurrentGun();

        public SelectedGun()
        {

        }

        public void SelectNewGun()
        {
            ShowLabel();
            ChangeNameToSelected();
            UpdateCurrentGun();
            Task.Run(HideLabel);
        }

        private void ShowLabel()
        {
            Label? t = Application.OpenForms["Game"].Controls["updateWeaponNotif"] as Label;
            if(t != null)
            {
                t.Visible = true;
            }
        }

        private async void HideLabel()
        {
            Thread.Sleep(3000);
            Label? t = Application.OpenForms["Game"].Controls["updateWeaponNotif"] as Label;
            if (t != null)
            {
                t.Visible = false;
            }
        }

    }
}
