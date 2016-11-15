using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstronautComplexBasicPack.ExercicePerception
{
    /// <summary>
    /// Represents a screen with components inside. During the perception test, there are many successive masks
    /// </summary>
    public class Mask
    {
        public List<Component> Components { get; protected set; }

        /// <summary>
        /// Builds a multiple-answer question.
        /// </summary>
        /// <param name="components">A list of some components.</param>
        public Mask(List<Component> components)
        {
            Components = components;
        }
    }
}
