using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using log4net;

namespace InyeccionLog4Net
{
    public class Calculadora : ICalculos
    {
        private readonly log4net.ILog _logger;

        public Calculadora(ILog logger)
        {
            _logger = logger;
        }


        public int Division(int num1, int num2)
        {
            try
            {
                int res = num1 / num2;
                return res;
            }
            catch (Exception ex)
            {
                _logger.Error("No se puede dividir entre 0. -> num1= "+ num1 + ", num = "+ num2);
                throw new Exception("No se puede dividir entre 0.");
            }
        }

    }
}
