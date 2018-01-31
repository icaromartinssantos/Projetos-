using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using SimpleInjector;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftp
{
    class Program
    {
        static readonly Container container;

        static Program() {

            //Cria dependentes 
            //Injeção de dependentes instância classes
            container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Register<IFTPRobot, SFTPRobot>(Lifestyle.Singleton);
        }

        static void Main(string[] args)
        {   

            using (AsyncScopedLifestyle.BeginScope(container))
            {

                try
                {
                    using (var robot = container.GetInstance<IFTPRobot>())
                    {
                        robot.ListarDiretorioLocalEEnviar();
                        Console.ReadKey();
                    }

                }
                catch(Exception ex)
                {
                    Console.Write("Ocorreu um problema: "+ ex + "\n");
                }
            }
            
        }
    }
}
