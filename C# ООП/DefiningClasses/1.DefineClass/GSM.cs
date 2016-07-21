using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    class GSM
    {
        private static GSM iphone4S = new GSM("Iphone4S", "Apple");

        private string model;
        private string manufacturer;
        private double price;
        private string owner;

        private Battery battery;
        private Display display;

        public GSM(string model, string manufacturer)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
        }
        public GSM(string model, string manufacturer, double price, string owner)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
        }
        public GSM(string model, string manufacturer, double price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.battery = battery;
            this.display = display;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }
        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        public static GSM Iphone4S
        {
            get
            {
                return iphone4S;
            }
        }
        public List<Call> CallHistory = new List<Call>();

        public void add(string date, string time, string mobile, int duration)
        {
            Call call = new Call(date, time, mobile, duration);
            CallHistory.Add(call);
        }
        public void delete()
        {
            int duration = 0;
            int index=0;
            for (int i = 0; i < CallHistory.Count; i++)
            {
                if (CallHistory[i].Duration>duration)
                {
                    duration=CallHistory[i].Duration;
                    index = i;
                }
            }
            CallHistory.RemoveAt(index);
        }
        public void clearHistory()
        {
            CallHistory.Clear();
        }
        public double callPrice()
        {
            double sumOfCalls = 0;
            for (int i = 0; i < CallHistory.Count; i++)
            {
                sumOfCalls += CallHistory[i].Duration/60 * Call.PricePerMinute;
            }
            return sumOfCalls;
        }

        public override string ToString()
        {
            return (this.Model + " " + this.Manufacturer + " " + this.Price + " " + this.Owner).ToString();
        }
    }
}
