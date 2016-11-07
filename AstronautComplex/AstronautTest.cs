using System;
using System.Windows.Forms;

namespace AstronautComplex
{
    /// <summary>
    /// Represents an astronaut test.
    /// </summary>
    public class AstronautTest : UserControl
    {
    
        public string Title { get; set; }
        public AstronautTestDifficulty Difficulty { get; set; }
        public AstronautTestForm Form { get; set; }
        protected Random Random { get; set; }

        /// <summary>
        /// Builds an astronaut test. Empty constructor is mandatory for the interface designer.
        /// </summary>
        public AstronautTest()
        {
            Name = "PanelTest" + GetType().Name;
            Dock = DockStyle.Fill;
            Random = new Random();
        }

        /// <summary>
        /// Builds an astronaut test. The description shall be used to display the test in a menu, for instance.
        /// </summary>
        /// <param name="title">The short description.</param>
        public AstronautTest(string title) : this()
        {
            Title = title;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AstronautTest
            // 
            this.Name = "AstronautTest";
            this.ResumeLayout(false);

        }
    }
}
