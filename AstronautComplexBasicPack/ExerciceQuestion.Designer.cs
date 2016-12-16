namespace AstronautComplexBasicPack
{
    partial class ExerciceQuestion
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
            this.panelDrawing = new System.Windows.Forms.Panel();
            this.tableLayoutPanelAnswers = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxQuestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxQuestion.Location = new System.Drawing.Point(27, 0);
            this.textBoxQuestion.Multiline = true;
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.ReadOnly = true;
            this.textBoxQuestion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxQuestion.Size = new System.Drawing.Size(1158, 96);
            this.textBoxQuestion.TabIndex = 1;
            this.textBoxQuestion.Text = "textBoxQuestionTitle";
            // 
            // panelQuestion
            // 
            this.panelQuestion.Controls.Add(this.textBoxQuestion);
            this.panelQuestion.Controls.Add(this.panelDrawing);
            this.panelQuestion.Controls.Add(this.tableLayoutPanelAnswers);
            this.panelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelQuestion.Location = new System.Drawing.Point(0, 70);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Padding = new System.Windows.Forms.Padding(27, 0, 27, 20);
            this.panelQuestion.Size = new System.Drawing.Size(1212, 646);
            this.panelQuestion.TabIndex = 2;
            // 
            // panelDrawing
            // 
            this.panelDrawing.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDrawing.Location = new System.Drawing.Point(27, 139);
            this.panelDrawing.Name = "panelDrawing";
            this.panelDrawing.Size = new System.Drawing.Size(1158, 419);
            this.panelDrawing.TabIndex = 3;
            // 
            // tableLayoutPanelAnswers
            // 
            this.tableLayoutPanelAnswers.ColumnCount = 1;
            this.tableLayoutPanelAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelAnswers.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.tableLayoutPanelAnswers.Location = new System.Drawing.Point(27, 558);
            this.tableLayoutPanelAnswers.Name = "tableLayoutPanelAnswers";
            this.tableLayoutPanelAnswers.RowCount = 1;
            this.tableLayoutPanelAnswers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelAnswers.Size = new System.Drawing.Size(1158, 68);
            this.tableLayoutPanelAnswers.TabIndex = 0;
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.labelTitle.Size = new System.Drawing.Size(1212, 70);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "labelTitle";
            // 
            // ExerciceQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelQuestion);
            this.Controls.Add(this.labelTitle);
            this.Name = "ExerciceQuestion";
            this.Size = new System.Drawing.Size(1212, 716);
            this.panelQuestion.ResumeLayout(false);
            this.panelQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuestion;
        private System.Windows.Forms.Panel panelQuestion;
        protected System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAnswers;
        private System.Windows.Forms.Panel panelDrawing;
    }
}
