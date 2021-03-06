﻿using Calculator.Models;
using System;
using System.Collections.Generic;

namespace Calculator.Functional.Arithmetic
{
    public class ArithmeticSeparationEquation : ISeparationEquation
    {
        private int GetNextElementAfterNestedEquation(string[] arrayElements, int item)
        {
            int skipCloseBraket = 0;

            for (int i = item + 1; i < arrayElements.Length; i++)
            {
                if (arrayElements[i] == "(")
                {
                    skipCloseBraket++;
                    continue;
                }

                if (arrayElements[i] == ")")
                {
                    if (skipCloseBraket > 0)
                    {
                        skipCloseBraket--;
                        continue;
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        private string GetNestedEquation(string[] arrayElements, int startItem, int endItem)
        {
            string nestedEquation = "";

            for (int i = startItem + 1; i <= endItem; i++)
            {
                nestedEquation += arrayElements[i] + ' ';
            }

            nestedEquation = nestedEquation.Remove(nestedEquation.Length - 3);
            return nestedEquation;
        }

        public List<ElementEquation> GetElementsEquation(string equation)
        {
            List<ElementEquation> elements = new List<ElementEquation>();

            string[] arrayElements = equation.Split(' ');

            double number = 0;
            bool isNumber = false;

            for (int i = 0; i < arrayElements.Length; i++)
            {
  
                switch (arrayElements[i])
                {
                    case "(":
                        int nextItem = GetNextElementAfterNestedEquation(arrayElements, i);
                        string nestedEquation = GetNestedEquation(arrayElements, i, nextItem);
                        elements.Add(new ElementEquation(OperatorType.Brackets, nestedEquation));

                        i = nextItem;
                        break;
                    case "*":
                        elements.Add(new ElementEquation(number, OperatorType.Mul));
                        break;
                    case "/":
                        elements.Add(new ElementEquation(number, OperatorType.Del));
                        break;
                    case "+":
                        elements.Add(new ElementEquation(number, OperatorType.Sum));
                        break;
                    case "-":
                        elements.Add(new ElementEquation(number, OperatorType.Sub));
                        break;
                }

                isNumber = Double.TryParse(arrayElements[i], out number);
            }

            if (isNumber)
            {
                elements.Add(new ElementEquation(number));
            }

            return elements;
        }
    }
}
