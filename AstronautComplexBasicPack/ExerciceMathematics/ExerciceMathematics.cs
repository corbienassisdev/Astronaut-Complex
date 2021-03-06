﻿namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class ExerciceMathematics : ExerciceQuestion
    {
        /// <summary>
        /// Builds an astronaut mathematic exercice.
        /// </summary>
        public ExerciceMathematics() : base("Mathématiques")
        {
            
        }

        /// <summary>
        /// Gets the exercice instructions.
        /// </summary>
        /// <returns>The instructions.</returns>
        public override string GetInstructions()
        {
            return base.GetInstructions() + "\n\nCet exercice concerne des problèmes de mathématiques.";
        }

        /// <summary>
        /// Generates all possible questions for the mathematics exercice.
        /// </summary>
        /// <returns>The possible questions for the exercice.</returns>
        public override Question[] GeneratePossibleQuestions()
        {
            return new Question[]
            {
                new QuestionPercentage("Hors saison, un hôtel propose un chambre double à {0}€. En pleine saison, le prix augmente de {1}%. Quel est le prix d'une chambre double en pleine saison ?", "€", QuestionPercentageType.Greater),
                new QuestionPercentage("Ma facture d'électricité a augmenté de {1}% ! Avant, elle était de {0}€. Combien vais-je devoir payer maintenant ?", "€", QuestionPercentageType.Greater),
                new QuestionPercentage("C'est les soldes ! Les chaussures que je voulaient, et qui coûtent habituellement {0}€, sont soldées à {1}%. Combien coûtent-elles maintenant ?", "€", QuestionPercentageType.Lesser),
                new QuestionHypothenuse("Pour aller à la piscine, je dois emprunter un chemin pendant {0}m, puis tourner de 90° vers l'est et continuer pendant encore {1}m. Quelle est la distance à vol d'oiseau entre mon point de départ et la piscine ?", "m"),
                new QuestionVolume("Quel est l'objet qui a le plus petit volume ?", "m3", QuestionVolumeType.Minimum),
                new QuestionVolume("Quel est l'objet qui a le plus gros volume ?", "m3", QuestionVolumeType.Maximum)
            };
        }
    }
}
