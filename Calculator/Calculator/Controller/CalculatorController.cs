﻿using Calculator.Repositories;
using System;

namespace Calculator.Controller
{
    public class CalculatorController
    {
        protected IInputRepository inputRepository;
        protected ICalculatorRepository calculatorRepository;
        protected IPrintRepository printRepository;

        public CalculatorController(IInputRepository inputRepository, IPrintRepository printRepository, ICalculatorRepository calculatorRepository)
        {
            this.inputRepository = inputRepository;
            this.printRepository = printRepository;
            this.calculatorRepository = calculatorRepository;
        }

        public void SolveEquation()
        {
            string equation = inputRepository.GetEquation();
            double result = calculatorRepository.SolveEquation(equation);
            printRepository.Print(result);
        }
    }
}
