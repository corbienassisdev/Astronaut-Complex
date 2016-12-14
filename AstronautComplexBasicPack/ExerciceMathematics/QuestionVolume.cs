using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AstronautComplex;
using System.Drawing;

namespace AstronautComplexBasicPack.ExerciceMathematics
{
    public class QuestionVolume : Question
    {
        public Type[] PossiblePolygons = new Type[]
        {
            typeof(Polygon3DCube),
            typeof(Polygon3DCylinder),
            typeof(Polygon3DSphere)
        };

        public QuestionVolumeType Type { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question on an hypothenuse problem.
        /// </summary>
        /// <param name="titleFormat">The question title format.</param>
        /// <param name="suffixeAnswers">The answer suffixe (usually a measure unit).</param>
        /// <param name="type">The question variant type.</param>
        public QuestionVolume(string titleFormat, string suffixeAnswer, QuestionVolumeType type) : base(titleFormat, suffixeAnswer)
        {
            Type = type;
        }

        /// <summary>
        /// Builds the question, setting the possible answers and the good answer, depending on the difficulty.
        /// </summary>
        /// <param name="difficulty">The exercice difficulty.</param>
        /// <param name="random">The exercice random number generator.</param>
        public override void Build(ExerciceDifficulty difficulty, Random random)
        {
            decimal maximum = 0;
            decimal minimum = decimal.MaxValue;

            Answers = new Polygon3D[random.Next(3, PossiblePolygons.Length + 1)];
            for (int i = 0; i < Answers.Length; i++)
            {
                Polygon3D polygon = (Polygon3D)Activator.CreateInstance(PossiblePolygons[random.Next(0, PossiblePolygons.Length)], random);
                polygon.Name += string.Format(" {0}", i);

                decimal volume = (decimal)polygon.ComputeVolume();
                switch (Type)
                {
                    case QuestionVolumeType.Maximum:
                        if (maximum < volume)
                        {
                            maximum = volume;
                            Answer = i;
                        }
                        break;

                    case QuestionVolumeType.Minimum:
                        if (minimum > volume)
                        {
                            minimum = volume;
                            Answer = i;
                        }
                        break;
                }

                Answers[i] = polygon;
            }

            GenerateTitle();
        }

        /// <summary>
        /// Builds the question drawing.
        /// </summary>
        /// <param name="graphics">The calling form graphics.</param>
        /// <param name="containerWidth">The container width.</param>
        /// <param name="containerHeight">The container height.</param>
        public override void BuildDrawing(Graphics graphics, int containerWidth, int containerHeight)
        {
            for (int i = 0; i < Answers.Length; i++)
            {
                Polygon3D polygon = (Polygon3D)Answers[i];

                int subContainerWidth = containerWidth / Answers.Length;
                int x = i * subContainerWidth + subContainerWidth / 2;
                polygon.Draw(graphics, x, 300, 5);
            }
        }
    }
}
