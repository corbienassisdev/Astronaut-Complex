using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AstronautComplexBasicPack.ExercicePerception;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AstronautComplexTests
{
    [TestClass]
    public class Test_Mask
    {
        [TestMethod]
        public void Test_ResetMask()
        {
            TableLayoutPanel tlp = new TableLayoutPanel();

            Mask mask = new Mask();
            mask.ResetMask(tlp); //give a mask with components

            List<ComponentPerception> oldComponents = new List<ComponentPerception>(mask.Components);

            mask.ResetMask(tlp);

            List<ComponentPerception> newComponents = new List<ComponentPerception>(mask.Components);

            bool isSame = true;

            int i = 0;
            while (isSame && i < oldComponents.Count - 1)
            {
                if (oldComponents[i].Color != newComponents[i].Color)
                    isSame = false;
                if (oldComponents[i].Shape != newComponents[i].Shape)
                    isSame = false;
                if (oldComponents[i].Digit != newComponents[i].Digit)
                    isSame = false;
                if (oldComponents[i].Letter != newComponents[i].Letter)
                    isSame = false;
            }

            Assert.AreEqual(isSame, false);
        }
    }
}
