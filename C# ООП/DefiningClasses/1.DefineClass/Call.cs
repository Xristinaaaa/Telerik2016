using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    class Call
    {
        public const double PricePerMinute = 0.37;

        private string date;
        private string time;
        private string mobileNumber;
        private int duration;

        public Call(string date, string time, string mobileNumber, int duration)
        {
            this.Date = date;
            this.Time = time;
            this.MobileNumber = mobileNumber;
            this.Duration = duration;
        }
        public string Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
        public string Time
        {
            get
            {
                return this.time;
            }
            set
            {
                this.time = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return this.mobileNumber;
            }
            set
            {
                this.mobileNumber = value;
            }
        }
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        public override string ToString()
        {
            return (Date+" "+Time+ " "+MobileNumber+ " "+Duration).ToString();
        }
    }
}
