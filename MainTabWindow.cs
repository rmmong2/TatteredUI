using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace TatteredUI
{
    public class Tattered_MainTabWindow : MainTabWindow
    {
        public override void DoWindowContents(Rect inRect)
        {
            mainmap = Find.CurrentMap;
            this.m_Pawns.Clear();
            this.m_Pawns.AddRange(mainmap.mapPawns.FreeColonists);
            foreach(Pawn p in this.m_Pawns)
            {
                List<Apparel> tempApparel = p.apparel.WornApparel; 
                for (int i = 0; i < tempApparel.Count; i++)
                {
                    double percent = 0;
                    percent = (tempApparel[i].HitPoints / tempApparel[i].MaxHitPoints);
                    if(percent < 0.5)
                    {
                        Log.Message(tempApparel[i].Label);
                    }
                }
            }
        }

        public List<Pawn> m_Pawns = new List<Pawn>();
        public Map mainmap;
    }
 
}
