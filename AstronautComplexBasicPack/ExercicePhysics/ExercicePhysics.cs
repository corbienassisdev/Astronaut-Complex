namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class ExercicePhysics : ExerciceQuestion
    {
        /// <summary>
        /// Builds an astronaut mathematic exercice.
        /// </summary>
        public ExercicePhysics() : base("Physique")
        {
            
        }

        /// <summary>
        /// Generates all possible questions for the mathematics exercice.
        /// </summary>
        /// <returns>The possible questions for the exercice.</returns>
        public override Question[] GeneratePossibleQuestions()
        {
            return new Question[]
            {
                new QuestionAtmosphereToPascal("Je suis arrivé sur une planète et mon baromètre indique que l'atmosphère a une pression de {0} Atmosphere ! Quelle est l'équivalent en Pascal ?", " Pa"),
                new QuestionCinetic("Ma voiture roulant à {0} m/s ({1} km/h) et pesant {2} kg va heurter un mur ! Comme je suis un bon scientifique, je vais calculer son énergie cinétique au moment de l'impact avant de me retrouver à l'hôpital. Alors, combien ?", "J")
            };
        }
    }
}
