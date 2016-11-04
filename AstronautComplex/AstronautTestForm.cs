using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AstronautComplex
{
    /// <summary>
    /// Represents an AstronautComplex main form.
    /// </summary>
    public partial class AstronautTestForm : Form
    {
        public const string DirectoryPlugins = @"\Plugins";

        public Dictionary<string, AstronautTest> Tests { get; set; }

        /// <summary>
        /// Builds an AstronautComplex main form.
        /// </summary>
        public AstronautTestForm()
        {
            InitializeComponent();
            Tests = new Dictionary<string, AstronautTest>();
        }

        /// <summary>
        /// Loads all tests located in the Plugins folder.
        /// </summary>
        public void LoadTests()
        {
            try
            {
                foreach (string pathPlugin in Directory.GetFiles(Directory.GetCurrentDirectory() + DirectoryPlugins, "*.dll", SearchOption.AllDirectories))
                {
                    foreach (Type type in Assembly.LoadFile(pathPlugin).GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(AstronautTest)))
                        {
                            AstronautTest test = (AstronautTest)Activator.CreateInstance(type);
                            test.Form = this;
                            Tests.Add(type.Name, test);

                            ToolStripMenuItem menuItem = new ToolStripMenuItem();
                            menuItem.Name = "MenuItem" + type.Name;
                            menuItem.Text = test.Description;
                            menuItem.Click += (sender, e) =>
                            {
                                panelTest.Controls.Clear();
                                panelTest.Controls.Add(test);
                            };
                            MenuItemNew.DropDownItems.Add(menuItem);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
            }
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void DisplayError(string message)
        {
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Called on main form loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AstronautComplex_Load(object sender, EventArgs e)
        {
            LoadTests();
        }

        /// <summary>
        /// Called on clicking the "Quit" menu item.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MenuItemQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
