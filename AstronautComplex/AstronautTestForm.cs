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

        public List<AstronautTest> Tests { get; set; }

        /// <summary>
        /// Builds an AstronautComplex main form.
        /// </summary>
        public AstronautTestForm()
        {
            InitializeComponent();
            Tests = new List<AstronautTest>();
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
                            foreach(AstronautTestDifficulty difficulty in Enum.GetValues(typeof(AstronautTestDifficulty)))
                            {
                                string key = "MenuItemNew" + difficulty.ToString();

                                ToolStripMenuItem menuItemDifficulty;
                                if(!MenuItemNew.DropDownItems.ContainsKey(key))
                                {
                                    menuItemDifficulty = new ToolStripMenuItem();
                                    menuItemDifficulty.Name = key;
                                    menuItemDifficulty.Text = difficulty.ToString();
                                    MenuItemNew.DropDownItems.Add(menuItemDifficulty);
                                }
                                else
                                {
                                    menuItemDifficulty = (ToolStripMenuItem)MenuItemNew.DropDownItems[key];
                                }

                                AstronautTest test = (AstronautTest)Activator.CreateInstance(type);
                                test.Difficulty = difficulty;
                                test.Form = this;
                                Tests.Add(test);

                                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                                menuItem.Name = key + type.Name;
                                menuItem.Text = test.Description;
                                menuItem.Click += (sender, e) =>
                                {
                                    panelTest.Controls.Clear();
                                    panelTest.Controls.Add(test);
                                };
                                menuItemDifficulty.DropDownItems.Add(menuItem);
                            }
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
