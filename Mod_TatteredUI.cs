using System;
using RimWorld;
using Verse;
using UnityEngine;

namespace TatteredUI
{
    [StaticConstructorOnStartup]
    public class Mod_Tattered_UI : Mod
    {
        public Mod_Tattered_UI(ModContentPack content) : base(content)
        {
            base.GetSettings<ModSettings_Tattered_UI>();
            LongEventHandler.QueueLongEvent(delegate()
            {
                UtilityClass.Setup();
            }, null, false, null, true);
        }
    }
}
