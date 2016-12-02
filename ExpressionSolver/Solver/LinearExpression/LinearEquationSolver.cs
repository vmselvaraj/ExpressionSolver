using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Beyond.ExpressionSolver.Solver.LinearExpression
{
    public class LinearEquationSolver
    {
        public List<LinearEquation> Equations { get; set; }
        public List<LinearEquationAnswer> Answers { get; set; }
        public LinearEquationSolver()
        {
            Equations = new List<LinearEquation>();
            Answers = new List<LinearEquationAnswer>();
        }

        public void AddEquation(string equation)
        {
            var eqn = new LinearEquation(equation);
            Equations.Add(eqn);
        }

        public string Solve()
        {
            Equations = Equations.OrderBy(i => i.TotalNumberOfVariables).ToList();
            //Populate the Variable List
            List<string> variablesList = new List<string>();
            foreach (var equation in Equations)
                equation.PopulateVariableList(variablesList);

            //Validate the Number of Variables and Number of Equations
            if ((variablesList.Count() - 1) < Equations.Count())
                throw new Exception("Number of Equations and Variables should be same for Linear Equation Solver");


            double[,] gaussMatrix = new double[Equations.Count(), variablesList.Count()]; //+1 for Vector

            //Populate Matrix
            for(int i = 0;i< Equations.Count(); i++)
            {
                var equation = Equations[i];
                for(int j = 0; j < variablesList.Count();j++)
                {
                    gaussMatrix[i, j] = equation[variablesList[j]];
                }
            }

            //Solve it by Gauss Elimincation Method

            return ToString();
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
