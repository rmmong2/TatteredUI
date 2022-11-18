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
        public override Vector2 InitialSize
        {
            get
            {
                return new Vector2(1360f, 700f);
            }
        }
        public Tattered_MainTabWindow()
        {
            this.resizeable = false;
            this.draggable = false;
            this.forcePause = true;
            this.doCloseX = false;
        }
        protected override void SetInitialSizeAndPosition()
        {
            this.windowRect = new Rect(((float)UI.screenWidth - this.InitialSize.x) / 2f, ((float)UI.screenHeight - this.InitialSize.y) / 2f, this.InitialSize.x, this.InitialSize.y);
            this.windowRect = this.windowRect.Rounded();
        }
        public override void DoWindowContents(Rect inRect)
        {
            GetColonists();
            Text.Font = GameFont.Small;
            Rect rect = new Rect(0f, 0f, 80f, 60f);
            Widgets.CustomButtonText(ref rect, "TatteredUI.GUI.Icon".Translate(), UtilityClass.BgColorButton, Color.white, Color.white, false, 1, true, true);
            Rect rect2 = new Rect(rect.x + rect.width + 10f, rect.y, 300f, rect.height);
            Widgets.CustomButtonText(ref rect2, "TatteredUI.GUI.Label".Translate(), UtilityClass.BgColorButton, Color.white, Color.white, false, 1, true, true);
            Rect outRect = new Rect(0f, 100f, this.InitialSize.x - 40f, this.InitialSize.y - 140f);
            Rect viewRect = new Rect(0f, 0f, outRect.x, (float)(this.tatteredApparel.Count<Apparel>() * 70));
            int num = 0;
            Widgets.BeginScrollView(outRect, ref this.scrollPosition, viewRect, true);
            foreach(Apparel a in this.tatteredApparel)
            {
                Text.Anchor = TextAnchor.MiddleCenter;
                Rect rect12 = new Rect(0f, (float)(70 * num), outRect.width - 30f, 70f);
                Widgets.DrawBoxSolidWithOutline(rect12, UtilityClass.BgColorButton, Color.gray, 1);
                Rect rect13 = new Rect(rect.width + 15f, rect12.y + 5f, rect2.width - 10f, rect12.height - 10f);
                Widgets.Label(rect13, a.LabelCap);
                Text.Anchor = TextAnchor.UpperLeft;
                num++;
            }
            Widgets.EndScrollView();
        }

        private void GetColonists()
        {
            mainmap = Find.CurrentMap;
            this.m_Pawns.Clear();
            this.m_Pawns.AddRange(mainmap.mapPawns.FreeColonists);
            foreach (Pawn p in this.m_Pawns)
            {
                List<Apparel> tempApparel = p.apparel.WornApparel;
                for (int i = 0; i < tempApparel.Count; i++)
                {
                    string tempLabel = tempApparel[i].Label.ToString();
                    if ((tempApparel[i].HitPoints < (.5 * tempApparel[i].MaxHitPoints)) && !(tatteredApparel.Exists(e => e.Label == tempLabel)))
                    {
                        //Log.Message(tempApparel[i].Label);
                        tatteredApparel.Add(tempApparel.ElementAt(i));
                        Log.Message("The count in tatteredApparel is: " + tatteredApparel.Count);
                    }
                }
            }
        }

        public List<Pawn> m_Pawns = new List<Pawn>();
        public List<Apparel> tatteredApparel = new List<Apparel>();
        public Map mainmap;
        public Vector2 scrollPosition = Vector2.zero;
    }
 
}
