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
    public partial class ExerciceForm : Form
    {
        public const string DirectoryPlugins = @"\Plugins";

        public List<Exercice> Exercices { get; protected set; }
        public int Exercice { get; protected set; }

        /// <summary>
        /// Builds an AstronautComplex main form.
        /// </summary>
        public ExerciceForm()
        {
            InitializeComponent();
            Exercices = new List<Exercice>();
        }

        /// <summary>
        /// Loads all exercices located in the Plugins folder.
        /// </summary>
        public void LoadExercices()
        {
            try
            {
                foreach (string pathPlugin in Directory.GetFiles(Directory.GetCurrentDirectory() + DirectoryPlugins, "*.dll", SearchOption.AllDirectories))
                {
                    foreach (Type type in Assembly.LoadFile(pathPlugin).GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Exercice)))
                        {
                            foreach(ExerciceDifficulty difficulty in Enum.GetValues(typeof(ExerciceDifficulty)))
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

                                Exercice exercice = (Exercice)Activator.CreateInstance(type);
                                exercice.Difficulty = difficulty;
                                exercice.Form = this;
                                Exercices.Add(exercice);

                                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                                menuItem.Name = key + type.Name;
                                menuItem.Text = exercice.Title;
                                menuItem.Click += (sender, e) =>
                                {
                                    panelExercice.Controls.Clear();
                                    panelExercice.Controls.Add(exercice);
                                    exercice.Initialize();
                                    exercice.Run();
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
        /// Clears the exercice panel.
        /// </summary>
        public void ClearPanel()
        {
            panelExercice.Controls.Clear();
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
            LoadExercices();
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
