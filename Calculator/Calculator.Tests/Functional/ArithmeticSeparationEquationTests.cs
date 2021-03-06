﻿using Calculator.Functional.Arithmetic;
using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests.Functional
{
    [TestClass]
    public class ArithmeticSeparationEquationTests
    {
        private ArithmeticSeparationEquation arithmeticSeparation;

        [TestInitialize]
        public void ClassInitialize()
        {
            arithmeticSeparation = new ArithmeticSeparationEquation();
        }

        [TestMethod]
        public void GetElementsEquation_Equation_ReturnListElementsEquation()
        {
            // arrange
            string equation = "42 + 18 / ( 6 + 12 / 4 )";
            List<ElementEquation> exectedElements = new List<ElementEquation>()
            {
                new ElementEquation(42, OperatorType.Sum),
                new ElementEquation(18, OperatorType.Del),
                new ElementEquation(OperatorType.Brackets, "6 + 12 / 4")
            };

            // act
            List<ElementEquation> actualElements = arithmeticSeparation.GetElementsEquation(equation);

            // assert
            CollectionAssert.AreEqual(exectedElements, actualElements);
        }
    }
}
