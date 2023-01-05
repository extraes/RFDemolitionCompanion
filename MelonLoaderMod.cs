using MelonLoader;
using Jevil.Prefs;
using Jevil.Patching;
using SLZ.Props.Weapons;
using System.Collections.Generic;
using RayFire;
using BoneLib;
using UnityEngine;
using Jevil;
using SLZ.Marrow.Data;

namespace RFDemolitionCompanion
{
    public static class BuildInfo
    {
        public const string Name = "RFDemolitionCompanion"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "extraes"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    [Preferences("RFDemolition", false)]
    public class RFDemolitionCompanion : MelonMod
    {
        public RFDemolitionCompanion() : base() => instance = this;
        internal static RFDemolitionCompanion instance;
        static Dictionary<Gun, RayfireGun> gunGuns = new();

        [RangePref(0, 10, 0.5f)] static float damageMultiplier = 1;

        public override void OnInitializeMelon()
        {
            Preferences.Register<RFDemolitionCompanion>();

            Hook.OntoMethod(typeof(Gun).GetMethod(nameof(Gun.Start)), GunAwake);
            Hooking.OnPostFireGun += GunFired;
        }

        private void GunFired(Gun firedGun)
        {
            Transform t = firedGun.firePointTransform;
            if (gunGuns.TryGetValue(firedGun, out RayfireGun rfGun))
            {
                SetDamage(rfGun, firedGun);
                rfGun.Shoot(t.position, t.forward);
#if DEBUG
                Log($"SLZ Gun fire successfully forwarded to RayfireGun! fullpath = {firedGun.transform.GetFullPath()}");
#endif
            }
#if DEBUG
            else
                Warn($"SLZ Gun fired but does not have a corresponding RayfireGun! Why? fullpath = {firedGun.transform.GetFullPath()}");
#endif

        }

        static void GunAwake(Gun newGun)
        {
            RayfireGun rfGun = newGun.gameObject.AddComponent<RayfireGun>();
            SetDamage(rfGun, newGun);
            gunGuns[newGun] = rfGun;
#if DEBUG
            Log($"Gun woke up, adding RayfireGun component now. Dmg = {rfGun.damage} fullpath = {newGun.transform.GetFullPath()}");
#endif
        }

        static void SetDamage(RayfireGun rfGun, Gun gun)
        {
            ProjectileData projData = gun.MagazineState?.cartridgeData?.projectile;
            if (projData)
                rfGun.damage = projData.damageMultiplier * projData.count * damageMultiplier;
            else
                rfGun.damage = -1;
        }

        #region MelonLogger replacements

        internal static void Log(string str) => instance.LoggerInstance.Msg(str);
        internal static void Log(object obj) => instance.LoggerInstance.Msg(obj?.ToString() ?? "null");
        internal static void Warn(string str) => instance.LoggerInstance.Warning(str);
        internal static void Warn(object obj) => instance.LoggerInstance.Warning(obj?.ToString() ?? "null");
        internal static void Error(string str) => instance.LoggerInstance.Error(str);
        internal static void Error(object obj) => instance.LoggerInstance.Error(obj?.ToString() ?? "null");

        #endregion
    }
}
