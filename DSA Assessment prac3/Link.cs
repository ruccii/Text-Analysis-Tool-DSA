using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assessment
{
    internal class Link
    {
        private string data;
        private List<int> lines;
        private Link next;

        public Link(string word, int line, Link nextLink = null)
        {
            data = word;
            lines = new List<int> { line };
            next = nextLink;
        }

        public string Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public List<int> Lines
        {
            get { return this.lines; }
            set { this.lines = value; }
        }

        public Link Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }

}
