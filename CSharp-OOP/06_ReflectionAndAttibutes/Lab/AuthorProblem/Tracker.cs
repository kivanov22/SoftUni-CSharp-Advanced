using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
       public void PrintMethodsByAuthor()
        {
            Type[] classType =Assembly.GetExecutingAssembly().GetTypes();
           //typeof(StartUp)
            //MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in classType)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    Attribute[] attributes = method.GetCustomAttributes().ToArray();
                        //method.GetCustomAttributes(false);

                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine("{0} is written by {1}",method.Name,attr.Name);
                    }
                }
            }
        }
    }
}
