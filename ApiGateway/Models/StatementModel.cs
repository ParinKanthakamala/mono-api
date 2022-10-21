using System;
using System.Collections.Generic;
using ApiGateway.Core;

namespace ApiGateway.Models
{
    public class StatementModel : MyModel
    {
        public List<object> GetStatement(int customer_id, DateTime from, DateTime to)
        {
            return null;
        }

        public bool SendStatementToEmail(int customer_id, string send_to, string from, string to, string cc = "")
        {
            return false;
        }
    }
}