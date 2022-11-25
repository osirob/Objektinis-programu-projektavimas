using Client.Template;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Facade
{
    public class WeaponShop
    {
        Pistol pistol;
        Rifle rifle;
        Shotgun shotgun;
        Bazooka bazooka;
        public WeaponShop()
        {
            pistol = new Pistol("Pistol");
            rifle = new Rifle("Rifle");
            shotgun = new Shotgun("Shotgun");
            bazooka = new Bazooka("Bazooka");
        }

        public IShooting BuyWeapon(CurrentWeaponType weaponType, ref int money)
        {
            if (weaponType == CurrentWeaponType.Pistol && money >= pistol.Price)
            {
                if (pistol.Ammunition == 0)
                {
                    pistol.AddAmmunition(20);
                }
                money -= pistol.Price;
                SelectedGun selectedGun = new PistolWeapon();
                selectedGun.SelectNewGun();
                return pistol;
            }

            if (weaponType == CurrentWeaponType.Rifle && money >= rifle.Price)
            {
                if (rifle.Ammunition == 0)
                {
                    rifle.AddAmmunition(90);
                }
                money -= rifle.Price;
                SelectedGun selectedGun = new RifleWeapon();
                selectedGun.SelectNewGun();
                return rifle;
            }

            if (weaponType == CurrentWeaponType.Shotgun && money >= shotgun.Price)
            {
                if (shotgun.Ammunition == 0)
                {
                    shotgun.AddAmmunition(10);
                }
                money -= shotgun.Price;
                SelectedGun selectedGun = new ShotgunWeapon();
                selectedGun.SelectNewGun();
                return shotgun;
            }

            if (weaponType == CurrentWeaponType.Bazooka && money >= bazooka.Price)
            {
                if (bazooka.Ammunition == 0)
                {
                    bazooka.AddAmmunition(5);
                }
                money -= bazooka.Price;
                SelectedGun selectedGun = new BazookaWeapon();
                selectedGun.SelectNewGun();
                return bazooka;
            }

            return null;
        }

        public void BuyAmmunition(CurrentWeaponType type, ref IShooting weapon, ref int money)
        {
            if (weapon.Name == pistol.Name && type == CurrentWeaponType.Pistol)
            {
                if (money >= pistol.AmmoPrice)
                {
                    weapon.AddAmmunition(20);
                    money -= pistol.AmmoPrice;
                }
            }

            if (weapon.Name == rifle.Name && type == CurrentWeaponType.Rifle)
            {
                if (money >= rifle.AmmoPrice)
                {
                    weapon.AddAmmunition(90);
                    money -= rifle.AmmoPrice;
                }
            }

            if (weapon.Name == shotgun.Name && type == CurrentWeaponType.Shotgun)
            {
                if (money >= shotgun.AmmoPrice)
                {
                    weapon.AddAmmunition(10);
                    money -= shotgun.AmmoPrice;
                }
            }

            if (weapon.Name == bazooka.Name && type == CurrentWeaponType.Bazooka)
            {
                if (money >= bazooka.AmmoPrice)
                {
                    weapon.AddAmmunition(5);
                    money -= bazooka.AmmoPrice;
                }
            }
        }
    }
}
