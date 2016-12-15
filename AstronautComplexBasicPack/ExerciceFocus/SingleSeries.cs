using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AstronautComplexBasicPack.ExerciceFocus
{
    public class SingleSeries
    {
        public List<ComponentFocus> Components { get; set; }
        public List<Button> Buttons { get; set; }

        public SingleSeries()
        {
            Components = new List<ComponentFocus>();
            Buttons = new List<Button>();
        }

        public SingleSeries(List<ComponentFocus> components, List<Button> buttons)
        {
            this.Components = new List<ComponentFocus>(components); //we don't just give a reference
            this.Buttons = new List<Button>(buttons);
        }
    }
}
