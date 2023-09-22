using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_24
{
    public class CompareExpressions: IComparer<string>
    {
        public int Compare(string x, string y)
        {
            double resultX = ExpressionEvaluation.EvaluatePostfix(x);
            double resultY = ExpressionEvaluation.EvaluatePostfix(y);

            return resultX.CompareTo(resultY);
        }
    }
}
