using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActionGenerator;
using EvidenciaObjektovManazer;
using K_DTree;

namespace MVC2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EvidenciaObjektov1 evidencia = new EvidenciaObjektov1();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(ref evidencia));

            //KdTree<int, int> strom = new KdTree<int, int>(2);

            //new Generator().GeneratorForTree(ref strom,1000000,0,0,0);
            //int a = 2;
            //strom.FindInterval(new int[] {0, 0}, new int[] {10000, 10000});
            //a = 3;
        }
    }
}
