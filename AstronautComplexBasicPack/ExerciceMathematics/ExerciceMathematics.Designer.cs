namespace AstronautComplexBasicPack.ExerciceMathematics
{
    partial class ExerciceMathematics
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQuestion.Location = new System.Drawing.Point(20, 0);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxQuestion.Size = new System.Drawing.Size(1353, 586);
            this.textBoxQuestion.TabIndex = 1;
            this.textBoxQuestion.Text = "textBoxQuestionTitle";
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.textBoxQuestion);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(0, 70);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
            this.panelQuestion.Size = new System.Drawing.Size(1393, 606);
            this.panelQuestion.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.labelTitle.Size = new System.Drawing.Size(1393, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "labelTitle";
            // 
            // AstronautTestMathematics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelQuestion);
            this.Controls.Add(this.labelTitle);
            this.Name = "AstronautTestMathematics";
            this.Size = new System.Drawing.Size(1393, 676);
            this.Load += new System.EventHandler(this.AstronautTestMathematics_Load);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Panel panelQuestion;
        protected System.Windows.Forms.Label labelTitle;
    }
}
