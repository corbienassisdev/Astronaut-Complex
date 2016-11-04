using System.Windows.Forms;

namespace AstronautComplex
{
    /// <summary>
    /// Represents an astronaut test.
    /// </summary>
    public class AstronautTest : UserControl
    {
        public string Description { get; set; }

        /// <summary>
        /// Builds an astronaut test. Empty constructor is mandatory for the interface designer.
        /// </summary>
        public AstronautTest()
        {
            Name = "PanelTest" + GetType().Name;
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Builds an astronaut test. The description shall be used to display the test in a menu, for instance.
        /// </summary>
        /// <param name="description">The short description.</param>
        public AstronautTest(string description) : this()
        {
            Description = description;
        }
    }
}
