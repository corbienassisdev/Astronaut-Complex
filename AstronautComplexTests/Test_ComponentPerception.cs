using System;
using AstronautComplex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstronautComplexBasicPack.ExercicePerception;
using System.Collections.Generic;
using System.Drawing;

namespace AstronautComplexTests
{
    [TestClass]
    public class Test_ComponentPerception
    {
        [TestMethod]
        public void Test_RandomDigitGenerationWithSpecifiedShape()
        {
            Shape testShape = Shape.Circle;
            Color testColor = Color.Red;

            List<ComponentPerception> components = new List<ComponentPerception>();
            
            for (int i = 0; i< 100; i++)
            {
                components.Add(ComponentPerception.RandomComponentWith(testShape, testColor));
            }

            bool isOk = true;

            foreach(ComponentPerception c in components)
            {
                if (c.Shape != testShape || c.Color != testColor)
                    isOk = false;
            }

            Assert.AreEqual(true, isOk);
        }
    }
}
