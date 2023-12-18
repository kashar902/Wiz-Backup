using System.Data;

namespace App.Wiz.Common.Helper;

public static class ExpressionCalculationHelper
{
    // This method will be used when Formula Needs Calculation
    public static double EvaluateExpression(string expression, decimal param, decimal environmentVariable)
    {
        expression = expression.Replace("@", param.ToString())
                               .Replace("#", environmentVariable.ToString());

        DataTable table = new();
        _ = table.Columns.Add("expression", typeof(string), expression);

        DataRow row = table.NewRow();
        table.Rows.Add(row);

        return double.Parse((string)row["expression"]);
    }
}
