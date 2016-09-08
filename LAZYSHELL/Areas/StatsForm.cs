using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LazyShell.Areas
{
    public partial class StatsForm : Form
    {
        // Constructor
        public StatsForm()
        {
            InitializeComponent();
            LoadStatistics();
        }

        // Methods
        private void LoadStatistics()
        {
            int count = 0;

            // NPCs
            var freqs = new Frequency[Model.NPCProperties.Length];
            foreach (var area in Model.Areas)
            {
                count += area.NPCObjects.Count;
                foreach (var npc in area.NPCObjects)
                {
                    freqs[npc.NPCID].Index = npc.NPCID;
                    freqs[npc.NPCID].Count++;
                }
            }
            Array.Sort<Frequency>(freqs, (x, y) => y.Count.CompareTo(x.Count));

            // NPCs - Set labels
            npcCountTotal.Text = count.ToString();
            npcCountAverage.Text = (count / 512).ToString();
            npcMostCommon.Text = freqs[0].Index + ", " + freqs[1].Index + ", " + freqs[2].Index;

            // Exits
            var freqs1 = new Frequency[Model.Areas.Length];
            var freqs2 = new Frequency[WorldMaps.Model.Locations.Length];
            foreach (var area in Model.Areas)
            {
                count += area.ExitTriggers.Count;
                foreach (var exit in area.ExitTriggers)
                {
                    if (exit.ExitType == 0)
                    {
                        freqs1[exit.Destination].Index = exit.Destination;
                        freqs1[exit.Destination].Count++;
                        freqs1[exit.Destination].Tag = exit.ExitType;
                    }
                    else
                    {
                        freqs2[exit.Destination].Index = exit.Destination;
                        freqs2[exit.Destination].Count++;
                        freqs2[exit.Destination].Tag = exit.ExitType;
                    }
                }
            }

            // Exits - Combine and sort
            freqs = new Frequency[freqs1.Length + freqs2.Length];
            freqs1.CopyTo(freqs, 0);
            freqs2.CopyTo(freqs, freqs1.Length);
            Array.Sort<Frequency>(freqs, (x, y) => y.Count.CompareTo(x.Count));

            // Exits - Set labels
            exitCountTotal.Text = count.ToString();
            exitCountAverage.Text = (count / 512).ToString();
            if ((byte)freqs[0].Tag == 0)
                exitMostCommon.Text = Model.Areas[freqs[0].Index].ToString();
            else if ((byte)freqs[0].Tag == 1)
                exitMostCommon.Text = WorldMaps.Model.Locations[freqs[0].Index].ToString();

            // Events
            freqs = new Frequency[EventScripts.Model.EventScripts.Length];
            foreach (var area in Model.Areas)
            {
                count += area.EventTriggers.Count;
                foreach (var trigger in area.EventTriggers)
                {
                    freqs[trigger.RunEvent].Index = trigger.RunEvent;
                    freqs[trigger.RunEvent].Count++;
                }
            }

            // Events - Sort and set labels
            Array.Sort<Frequency>(freqs, (x, y) => y.Count.CompareTo(x.Count));
            eventCountTotal.Text = count.ToString();
            eventCountAverage.Text = (count / 512).ToString();
            eventMostCommon.Text = freqs[0].Index + ", " + freqs[1].Index + ", " + freqs[2].Index;
        }
    }
}
