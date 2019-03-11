using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib.model
{
    class HotelFaciliteter
    {
        private int Hotel_No;
        private int _facilitet;

        private int antal;

        public HotelFaciliteter(int hotelNo, int facilitet, int antal)
        {
            HotelNo = hotelNo;
            Facilitet = facilitet;
            Antal = antal;
        }

        public HotelFaciliteter()
        {
            
        }

        public int HotelNo
        {
            get { return Hotel_No; }
            set { Hotel_No = value; }
        }

        public int Facilitet
        {
            get { return _facilitet; }
            set { _facilitet = value; }
        }

        public int Antal
        {
            get { return antal; }
            set { antal = value; }
        }
    }
}
