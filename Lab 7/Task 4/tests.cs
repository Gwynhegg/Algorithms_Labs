using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class tests
    {

        StreamWriter data_stream;
        Random rnd;
        public tests()
        {
            data_stream = new StreamWriter("input.txt");
            rnd = new Random();
            createChecked();
            createCheckedv2();
            createMedium();
            createHard();
            data_stream.Close();
        }

        private void createChecked()
        {
            data_stream.WriteLine("6 10");
        }

        private void createCheckedv2()
        {
            data_stream.WriteLine("28 12");
        }

        private void createMedium()
        {
            data_stream.WriteLine(2 * rnd.Next(20, 40) + " " + rnd.Next(2, 26));
        }

        private void createHard()
        {
            data_stream.WriteLine(140 + " " + rnd.Next(2, 26));
        }
    }
}
