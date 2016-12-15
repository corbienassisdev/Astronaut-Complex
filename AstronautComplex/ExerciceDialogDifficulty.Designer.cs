namespace AstronautComplex
{
    partial class ExerciceDialogDifficulty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDescription = new System.Windows.Forms.Label();
            this.tableLayoutPanelDifficulties = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelDescription.Location = new System.Drawing.Point(10, 10);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(197, 13);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "Veuillez choisir la difficulté de l\'exercice :";
            // 
            // tableLayoutPanelDifficulties
            // 
            this.tableLayoutPanelDifficulties.ColumnCount = 1;
            this.tableLayoutPanelDifficulties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDifficulties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDifficulties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDifficulties.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelDifficulties.Location = new System.Drawing.Point(10, 23);
            this.tableLayoutPanelDifficulties.Name = "tableLayoutPanelDifficulties";
            this.tableLayoutPanelDifficulties.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.tableLayoutPanelDifficulties.RowCount = 1;
            this.tableLayoutPanelDifficulties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDifficulties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDifficulties.Size = new System.Drawing.Size(264, 48);
            this.tableLayoutPanelDifficulties.TabIndex = 1;
            // 
            // ExerciceDialogDifficulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 71);
            this.Controls.Add(this.tableLayoutPanelDifficulties);
            this.Controls.Add(this.labelDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExerciceDialogDifficulty";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Astronaut Complex - Choix de difficulté";
            this.Load += new System.EventHandler(this.ExerciceDialogDifficulty_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDifficulties;
    }
}