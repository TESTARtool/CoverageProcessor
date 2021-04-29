using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoverageCollectorApp
{
    class SaveGraphs
    {

        // Simply save values of one chart
        public static void saveChartArrayList(ArrayList alChart, string name, string path)
        {
                StreamWriter writer = new StreamWriter(path + "\\" + name + "Chart.txt");
                int index = 1;
                while (index < alChart.Count)
                {
                    writer.WriteLine(alChart[index]);
                    index++;
                }
                writer.Close();
        } // end graph


        // Save values of a collection of Charts
        public static void saveChartCollectionOfArrayLists(ArrayList alalCollection, string type, string path)
        {

            for (int countAL = 0; countAL < alalCollection.Count; countAL++)
            {
                ArrayList al = new ArrayList();
                al = (ArrayList)alalCollection[countAL];

                StreamWriter writer = new StreamWriter(path + "\\" + type + "Sequence" + (countAL + 1) + ".txt");
                int index = 0;
                while (index < al.Count)
                {
                    writer.WriteLine(al[index]);
                    index++;
                }
                writer.Close();
            }
        } // end graphs collection

        public void tet()
        {

        }
    }
}
