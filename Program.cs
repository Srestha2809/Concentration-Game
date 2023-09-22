using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Project2_Group_24
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = "C:\\Users\\srest\\Downloads\\Project2_Group_24\\Project2_Group_24\\Data\\Project 2_INFO_5101.csv";
            List<string> csvContent = CSVFile.CSVDeserialize(csvFilePath);

            List<string> postfixExpressions = new List<string>();
            List<string> prefixExpressions = new List<string>();

            Console.WriteLine("Infix to Postfix Conversion and Evaluation:");
            try
            {
                foreach (string infix in csvContent.Skip(1))
                {
                    string postfix = InfixToPostfixConvertor.Convert(infix);
                    postfixExpressions.Add(postfix);
                    double postfixResult = ExpressionEvaluation.EvaluatePostfix(postfix);
                    Console.WriteLine($"{infix} -> {postfix} = {postfixResult}");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Error while evaluating postfix expression: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nInfix to Prefix Conversion and Evaluation:");
            foreach (string infix in csvContent.Skip(1))
            {
                string prefix = InfixToPrefixConvertor.Convert(infix);
                prefixExpressions.Add(prefix);
                double prefixResult = ExpressionEvaluation.EvaluatePrefix(prefix);
                Console.WriteLine($"{infix} -> {prefix} = {prefixResult}");
            }

            CompareExpressions comparer = new CompareExpressions();
            postfixExpressions.Sort(comparer);
            prefixExpressions.Sort(comparer);

            XDocument xmlDocument = new XDocument();
            xmlDocument.WriteStartDocument("1.0", "utf-8");
            XElement rootElement = xmlDocument.WriteStartRootElement("Expressions");

            for (int i = 0; i < postfixExpressions.Count; i++)
            {
                XElement expressionElement = rootElement.WriteStartElement("Expression");
                expressionElement.WriteAttribute("id", (i + 1).ToString());
                expressionElement.WriteAttribute("postfix", postfixExpressions[i]);
                expressionElement.WriteAttribute("prefix", prefixExpressions[i]);
            }

            string xmlFilePath = "C:\\Users\\srest\\Downloads\\Project2_Group_24\\Project2_Group_24\\Data\\project2.xml";
            xmlDocument.Save(xmlFilePath);

            Console.WriteLine("\nXML file has been generated and saved.");
        }
    }
}
