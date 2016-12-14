using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// Builds the form.
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
            MenuItemNew.DropDownItems.Clear();
            panelExercice.Controls.Clear();

            try
            {
                AxWMPLib.AxWindowsMediaPlayer wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
                panelExercice.Controls.Add(wmPlayer);
                wmPlayer.Dock = DockStyle.Right;
                wmPlayer.Width = 664;
                wmPlayer.CreateControl();
                wmPlayer.enableContextMenu = false;
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
                wmPlayer.Name = "wmPlayer";
                wmPlayer.Enabled = true;
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
                wmPlayer.uiMode = "none";
                wmPlayer.URL = "earth.mp4";
                wmPlayer.settings.setMode("loop", true);
                wmPlayer.Ctlcontrols.play();

                Panel panelMenu = new Panel();
                panelMenu.Dock = DockStyle.Left;
                panelMenu.Padding = new Padding(20, 0, 0, 0);
                panelMenu.Width = 326;
                panelExercice.Controls.Add(panelMenu);

                Label labelMenuTitle = new Label();
                labelMenuTitle.Dock = DockStyle.Top;
                labelMenuTitle.AutoSize = true;
                labelMenuTitle.Padding = new Padding(0, 20, 0, 20);
                labelMenuTitle.Text = "Astronaut Complex";
                labelMenuTitle.Font = new Font(SystemFonts.DefaultFont.FontFamily, 24, FontStyle.Bold);
                panelMenu.Controls.Add(labelMenuTitle);

                foreach (string pathPlugin in Directory.GetFiles(Directory.GetCurrentDirectory() + DirectoryPlugins, "*.dll", SearchOption.AllDirectories))
                {
                    foreach (Type type in Assembly.LoadFile(pathPlugin).GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Exercice)))
                        {
                            Exercice exercice = (Exercice)Activator.CreateInstance(type);
                            exercice.Form = this;
                            Exercices.Add(exercice);

                            Action<object, EventArgs> onClick = new Action<object, EventArgs>((sender, e) =>
                            {
                                ExerciceDialogDifficulty dialog = new ExerciceDialogDifficulty();
                                dialog.Width = 300;
                                dialog.Height = 150;
                                dialog.Text = "Difficulté";
                                if(dialog.ShowDialog() == DialogResult.OK)
                                {
                                    panelExercice.Controls.Clear();
                                    panelExercice.Controls.Add(exercice);
                                    exercice.Difficulty = dialog.SelectedDifficulty;
                                    exercice.Initialize();
                                    exercice.Run();
                                }
                            });

                            ToolStripMenuItem menuItem = new ToolStripMenuItem();
                            menuItem.Name = "MenuItemNew" + type.Name;
                            menuItem.Text = exercice.Title;
                            menuItem.Click += onClick.Invoke;
                            MenuItemNew.DropDownItems.Add(menuItem);

                            Button menuButton = new Button();
                            menuButton.Name = "MenuButton" + type.Name;
                            menuButton.Text = exercice.Title;
                            menuButton.Dock = DockStyle.Top;
                            menuButton.Height = 64;
                            menuButton.Click += onClick.Invoke;
                            panelMenu.Controls.Add(menuButton);
                            menuButton.BringToFront();
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

        /// <summary>
        /// Gets the index localized string in the resources file.
        /// </summary>
        /// <param name="index">The lang string index.</param>
        /// <returns>The string to translate (original index if not found).</returns>
        public static string GetLangString(string index)
        {
            string str = Properties.Resources.ResourceManager.GetString("lang" + index);
            return (str != null) ? str : index;
        }
    }
}
