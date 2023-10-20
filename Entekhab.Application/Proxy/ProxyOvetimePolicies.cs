using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Entekhab.Application.Proxy
{
    public class ProxyOvetimePolicies
    {
        public ProxyOvetimePolicies()
        {
            OverTime = new OvetimePolicies.OverTime();
        }

        public OvetimePolicies.OverTime OverTime { get; set; }
        public decimal OverTimeCalculator(decimal basicSalary,
                                          decimal allowance,
                                          decimal Transportation,
                                          string methodCalculator)
        {
            object[] parametersArray = new object[] { basicSalary, allowance };

            decimal? resultOverTime = GetMethodInvoke(
                                                     methodCalculator: methodCalculator,
                                                     parametersArray: parametersArray);

            decimal result = basicSalary + allowance + Transportation + resultOverTime.Value;

            return result;
        }

        public decimal? GetMethodInvoke( string methodCalculator, object[] parametersArray)
        {
            System.Type oType = OverTime.GetType();
            decimal? result = 0;


            foreach (MethodInfo oMethodInfo in oType.GetMethods())
            {

                if (oMethodInfo.Name == methodCalculator)
                {
                    result = oMethodInfo.Invoke(OverTime, parametersArray) as decimal?;
                }

            }

            return result;
        }

        public bool CheckIsMethod(string methodCalculator)
        {
            System.Type oType = OverTime.GetType();

            foreach (MethodInfo oMethodInfo in oType.GetMethods())
            {

                if (oMethodInfo.Name == methodCalculator)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
