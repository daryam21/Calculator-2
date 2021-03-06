﻿using System;

namespace Calculator.Models
{
    public class ElementEquation
    {
        public double Number { get; set; }
        public Operation Operation { get; set; }
        public string NestedEquation { get; set; }


        public ElementEquation(double number, OperatorType operatorType)
        {
            this.Number = number;
            this.Operation = new Operation(operatorType);
        }

        public ElementEquation( OperatorType operatorType, string nestedEquation)
        {
            this.Operation = new Operation(operatorType);
            this.NestedEquation = nestedEquation;
        }

        public ElementEquation(double number)
        {
            this.Number = number;
            this.Operation = new Operation(OperatorType.Empty);
        }

        public override bool Equals(object other)
        {
            if (other is ElementEquation)
            {
                var element = other as ElementEquation;
                return ( (Number == element.Number) && ( Operation.Equals(element.Operation) ) && (NestedEquation == element.NestedEquation) );
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)(Number * Operation.GetHashCode() * NestedEquation.GetHashCode());
        }
    }
}
