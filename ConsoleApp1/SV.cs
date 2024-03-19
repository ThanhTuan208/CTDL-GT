using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SV
    {
        private string Nhap;

        public string nhap { get => nhap; set => nhap = value; }
        public SV()
        {

        }
        public SV(in string nhap)
        {
            Nhap = nhap;
        }
    }
}
