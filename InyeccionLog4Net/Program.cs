using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using log4net;

namespace InyeccionLog4Net
{
    public class Program
    {

        private static IContainer Container { get; set; }
        //static ILog Log;

        static void Main(string[] args)
        {
            ConfigureContainer();

            int num1 = 4000;
            int num2 = 0;

            Calcular(num1, num2);
        }
        
        private static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Log
            builder.RegisterModule(new LoggingModule());
            //builder.RegisterModule<LoggingModule>();

            // Clase calculo
            builder.RegisterType<Calculadora>().SingleInstance();
            
            Container = builder.Build();
        }

        public static void Calcular(int num1, int num2)
        {
            using (var scope = Container.BeginLifetimeScope())
            {
                var res = scope.Resolve<Calculadora>().Division(num1, num2);
                Console.WriteLine(res);
            }
        }

       
        
    }
}
