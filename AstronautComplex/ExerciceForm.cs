using AxWMPLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WMPLib;
using AstronautComplex.Properties;

namespace AstronautComplex
{
    /// <summary>
    /// Represents an AstronautComplex main form.
    /// </summary>
    public partial class ExerciceForm : Form
    {
        public const string MessageError = "Erreur";
        public const string MessageReturnHomeTitle = "Astronaut Complex - Retourner au menu principal";
        public const string MessageReturnHomeContent = "Êtes-vous sûr de vouloir retourner au menu principal ? Toute progression dans cet exercice sera perdue.";
        public const string DirectoryPlugins = @"\Plugins";
        public const string FileVideoTemp = "temp.mp4";

        public List<Exercice> Exercices { get; protected set; }
        public int CurrentExercice { get; protected set; }

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
            menuItemNew.DropDownItems.Clear();
            menuItemHome.Enabled = false;
            panelExercice.Controls.Clear();

            try
            {
                DisplayBackground();

                TableLayoutPanel tableLayoutPanelMenu = new TableLayoutPanel();
                tableLayoutPanelMenu.Dock = DockStyle.Left;
                tableLayoutPanelMenu.AutoSize = true;
                tableLayoutPanelMenu.Padding = new Padding(20, 0, 0, 0);
                tableLayoutPanelMenu.BackColor = Color.Transparent;
                tableLayoutPanelMenu.ColumnCount = 1;
                tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                panelExercice.Controls.Add(tableLayoutPanelMenu);

                Panel pictureBoxTitle = new Panel();
                pictureBoxTitle.Dock = DockStyle.Top;
                pictureBoxTitle.Width = 300;
                pictureBoxTitle.Padding = new Padding(0, 20, 0, 20);
                pictureBoxTitle.BackgroundImage = Resources.logo_title;
                pictureBoxTitle.BackgroundImageLayout = ImageLayout.Zoom;
                tableLayoutPanelMenu.Controls.Add(pictureBoxTitle, 0, 0);

                int indexLoading = 0;

                foreach (string pathPlugin in Directory.GetFiles(Directory.GetCurrentDirectory() + DirectoryPlugins, "*.dll", SearchOption.AllDirectories))
                {
                    foreach (Type type in Assembly.LoadFile(pathPlugin).GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(Exercice)))
                        {
                            Exercice exercice = (Exercice)Activator.CreateInstance(type);
                            exercice.Form = this;
                            Exercices.Add(exercice);

                            Action<object, EventArgs> onClick = new Action<object, EventArgs>((sender, e) => { LoadExercice(exercice); });

                            ToolStripMenuItem menuItem = new ToolStripMenuItem();
                            menuItem.Name = "menuItemNew" + type.Name;
                            menuItem.Text = exercice.Title;
                            menuItem.Click += onClick.Invoke;
                            menuItemNew.DropDownItems.Add(menuItem);

                            Button menuButton = new Button();
                            menuButton.Name = "menuButton" + type.Name;
                            menuButton.Text = exercice.Title;
                            menuButton.Height = 60;
                            menuButton.Dock = DockStyle.Top;
                            menuButton.Click += onClick.Invoke;
                            tableLayoutPanelMenu.Controls.Add(menuButton);

                            tableLayoutPanelMenu.RowCount++;
                            tableLayoutPanelMenu.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
                            tableLayoutPanelMenu.Controls.Add(menuButton, 0, indexLoading + 1);

                            indexLoading++;
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
        /// Loads an exercice by asking its difficulty.
        /// </summary>
        /// <param name="exercice">The exercice to load.</param>
        public void LoadExercice(Exercice exercice)
        {
            ExerciceDialogDifficulty dialog = new ExerciceDialogDifficulty();
            dialog.Width = 300;
            dialog.Height = 150;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                menuItemHome.Enabled = true;
                panelExercice.Controls.Clear();
                panelExercice.Controls.Add(exercice);
                exercice.Difficulty = dialog.SelectedDifficulty;
                exercice.Initialize();
                exercice.Run();
            }
        }

        /// <summary>
        /// Finishes an exercice, displaying its score if asked to and reloading.
        /// </summary>
        /// <param name="exercice"></param>
        public void FinishExercice(Exercice exercice, bool displayScore = true)
        {
            if(displayScore)
            {
                MessageBox.Show(string.Format("L'exercice est fini ! Vous avez obtenu un score de {0} !", exercice.Score), "Exercice terminé !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadExercices();
        }

        /// <summary>
        /// Displays the background. Will try to load the video by creating a hidden temporary file, and will delete the file if an exception is raised.
        /// </summary>
        public void DisplayBackground()
        {
            try
            {
                File.WriteAllBytes(FileVideoTemp, Resources.earth_video);
                File.SetAttributes(FileVideoTemp, FileAttributes.Temporary | FileAttributes.Hidden);
                
                AxWindowsMediaPlayer wmPlayer = new AxWindowsMediaPlayer();
                wmPlayer.Dock = DockStyle.Right;
                wmPlayer.Width = 664;
                wmPlayer.CreateControl();
                wmPlayer.enableContextMenu = false;
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
                wmPlayer.Name = "wmPlayer";
                wmPlayer.Enabled = true;
                ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
                wmPlayer.uiMode = "none";
                wmPlayer.URL = FileVideoTemp;
                wmPlayer.settings.setMode("loop", true);
                wmPlayer.Ctlcontrols.play();
                panelExercice.Controls.Add(wmPlayer);

                MinimumSize = new Size(1024, 650);
                MaximumSize = new Size(1024, 650);
            }
            catch (Exception)
            {
                DeleteVideo();
            };
        }

        /// <summary>
        /// Displays an error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void DisplayError(string message)
        {
            MessageBox.Show(message, MessageError, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Deletes the home video and frees memory.
        /// </summary>
        public void DeleteVideo()
        {
            if (File.Exists(FileVideoTemp))
            {
                File.Delete(FileVideoTemp);
            }
        }

        /// <summary>
        /// Called on main form loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExerciceForm_Load(object sender, EventArgs e)
        {
            LoadExercices();
        }

        /// <summary>
        /// Called on main form closing.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExerciceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DeleteVideo();
        }

        /// <summary>
        /// Called on clicking the "Home" menu item.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MenuItemHome_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(MessageReturnHomeContent, MessageReturnHomeTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                FinishExercice(Exercices[CurrentExercice], false);
            }
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
