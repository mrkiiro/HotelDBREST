using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    public class Facilitet
    {
        private string _navn;
        private int _faciliteter;

        public Facilitet()
        {
            
        }


        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public int Faciliteter
        {
            get { return _faciliteter; }
            set { _faciliteter = value; }
        }

        public override string ToString()
        {
            return $"{Navn} har id: {Faciliteter}";
        }
    }
}