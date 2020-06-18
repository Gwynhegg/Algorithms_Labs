using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Milestones
    {
        private int final_indexes;
        private char first_letters;

        public Milestones(int index, char letter)
        {
            this.final_indexes = index;
            this.first_letters = letter;
        }

        public int getIndex()
        {
            return final_indexes;
        }

        public char getLetter()
        {
            return first_letters;
        }
    }
}
