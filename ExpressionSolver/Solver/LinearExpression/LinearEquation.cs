using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Beyond.ExpressionSolver.Solver.LinearExpression
{
    public class LinearEquation
    {
        private string m_Equation = string.Empty;
        public string Equation
        {
            get
            {
                return m_Equation;
            }
            set
            {
                m_Equation = value;
            }
        }

        private Dictionary<string, float> variablesCoefficientDict = null;
        public float this[string variableName]
        {
            get
            {
                if(variablesCoefficientDict.ContainsKey(variableName))
                    return variablesCoefficientDict[variableName];

                return 0;
            }
        }
        
        public int TotalNumberOfVariables
        {
            get
            {
                return variablesCoefficientDict.Count();
            }
        }

        private const string equationPattern = @"([+-]?([0-9]*\.[0-9]+|[0-9]+)|[+-]|[a-zA-Z]+|=)";
        public LinearEquation(string equation)
        {
            Equation = equation;
            variablesCoefficientDict = new Dictionary<string, float>();
            ParseEquation();
        }

        public void ParseEquation()
        {
            try
            {
                MatchCollection matches = Regex.Matches(Equation.Trim().Replace(" ", ""), equationPattern);
                for (int i = 0; i < matches.Count; i=i+2)
                {
                    //Parse the Weight
                    string match = matches[i].Value;

                    //Get the Variable Name
                    string variableName = matches[i + 1].Value;

                    float coefficient = 1;
                    if(match == "=")
                    {
                        variableName = "equals";
                        coefficient = float.Parse(matches[i + 1].Value);
                    }
                    else if(match != "-" && match !="+")
                    {
                        coefficient = float.Parse(match);
                    }
                    else if(match == "-")
                    {
                        coefficient = -1;
                    }

                    //Put it to Dictionary  
                    if (!variablesCoefficientDict.ContainsKey(variableName))
                        variablesCoefficientDict.Add(variableName, coefficient);
                    else
                        variablesCoefficientDict[variableName] += coefficient;
                }
            }
            catch(Exception e)
            {
                throw new InvalidLinearEquation("Invalid Linear Equation: " + Equation);
            }
           
        }

        public void PopulateVariableList(List<string> variablesList)
        {
            foreach(var variableName in variablesCoefficientDict.Keys)
            {
                if(!variablesList.Contains(variableName))
                {
                    variablesList.Add(variableName);
                }
            }
        }

        public bool ValidatePresenceOfVariablesInTheList(List<string> masterVariableList)
        {
            foreach(var variable in variablesCoefficientDict.Keys)
            {
                if (!masterVariableList.Contains(variable))
                    return false;
            }
            return true;
        }
    }
}
