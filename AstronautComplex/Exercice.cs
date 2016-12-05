using System;
using System.Windows.Forms;

namespace AstronautComplex
{
    public partial class Exercice : UserControl
    {
        public string Title { get; set; }
        public ExerciceDifficulty Difficulty { get; set; }
        public ExerciceForm Form { get; set; }
        protected ExerciceScore Score { get; set; }
        protected Random Random { get; set; }

        /// <summary>
        /// Builds an astronaut exercice. Empty constructor is mandatory for the interface designer.
        /// </summary>
        public Exercice()
        {
            InitializeComponent();
            Name = "PanelExercice" + GetType().Name;
            Dock = DockStyle.Fill;
            Random = new Random();
        }

        /// <summary>
        /// Builds an astronaut exercice. The description shall be used to display the exercice in a menu, for instance.
        /// </summary>
        /// <param name="title">The short description.</param>
        public Exercice(string title) : this()
        {
            Title = title;
        }

        /// <summary>
        /// Initializes the exercice. Needs to be implemented.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Runs the exercice. Needs to be implemented.
        /// </summary>
        public virtual void Run() { }

        /// <summary>
        /// Finishes the exercice, displays the score and goes back to the home page.
        /// </summary>
        public void Finish()
        {
            MessageBox.Show(string.Format("L'exercice est fini ! Vous avez obtenu un score de {0} !", Score), "Exercice terminé !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Form.LoadExercices();
        }
    }
}
