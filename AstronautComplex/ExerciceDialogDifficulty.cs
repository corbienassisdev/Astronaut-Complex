using System;
using System.Windows.Forms;

namespace AstronautComplex
{
    /// <summary>
    /// Represents an AstronautComplex difficulty selection dialog box.
    /// </summary>
    public partial class ExerciceDialogDifficulty : Form
    {
        public ExerciceDifficulty SelectedDifficulty { get; protected set; }

        /// <summary>
        /// Builds the dialog box.
        /// </summary>
        public ExerciceDialogDifficulty()
        {
            InitializeComponent();
            this.Width = 300;
            this.Height = 150;
        }

        /// <summary>
        /// Loads all difficulties.
        /// </summary>
        public void LoadDifficulties()
        {
            tableLayoutPanelDifficulties.ColumnCount = 0;

            ExerciceDifficulty[] difficulties = (ExerciceDifficulty[])Enum.GetValues(typeof(ExerciceDifficulty));
            for (int i = 0; i < difficulties.Length; i++)
            {
                ExerciceDifficulty difficulty = difficulties[i];

                Button button = new Button();
                button.Text = ExerciceForm.GetLangString(difficulty.ToString());
                button.Height = 40;
                button.Anchor = AnchorStyles.None;
                button.TabIndex = i;
                button.DialogResult = DialogResult.OK;
                button.Click += (sender, e) =>
                {
                    SelectedDifficulty = difficulty;
                };
                tableLayoutPanelDifficulties.ColumnCount++;
                tableLayoutPanelDifficulties.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100.0F));
                tableLayoutPanelDifficulties.Controls.Add(button, tableLayoutPanelDifficulties.ColumnCount - 1, 0);
            }
        }

        /// <summary>
        /// Called on dialog box loading.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void ExerciceDialogDifficulty_Load(object sender, EventArgs e)
        {
            LoadDifficulties();
        }
    }
}
