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

        private Dictionary<string, float> variablesWeightsDict = null;
        public float this[string variableName]
        {
            get
            {
                if(variablesWeightsDict.ContainsKey(variableName))
                    return variablesWeightsDict[variableName];

                return 0;
            }
        }
        

        private const string equationPattern = @"([-]?([0-9]*\.[0-9]+|[0-9]+)|[a-zA-Z]+|=)";
        public LinearEquation(string equation)
        {
            Equation = equation;
            variablesWeightsDict = new Dictionary<string, float>();
            PopulateVariablesWeightDict();
            
        }


        private void PopulateVariablesWeightDict()
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

                    float weight = 1;
                    if(match == "=")
                    {
                        variableName = "equals";
                        weight = float.Parse(matches[i + 1].Value);
                    }
                    else if(match != "-" && match !="+")
                    {
                        weight = float.Parse(match);
                    }

                    //Put it to Dictionary  
                    if (!variablesWeightsDict.ContainsKey(variableName))
                        variablesWeightsDict.Add(variableName, weight);
                    else
                        variablesWeightsDict[variableName] += weight;
                }
            }
            catch(Exception e)
            {
                throw new InvalidLinearEquation("Invalid Linear Equation: " + Equation);
            }
           
        }
    }
}
