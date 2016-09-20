using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    public enum BatteryType { LiIon, NiMH, NiCd};
    class Battery
    {
        private BatteryType batteryModel;
        private int hoursIdle;
        private int hoursTalk;

        public Battery(BatteryType battery, int idle, int talk)
        {
            this.BatteryM = battery;
            this.HoursIdle = idle;
            this.HoursTalk = talk;
        }

        public BatteryType BatteryM
        {
            get
            {
                return batteryModel;
            }
            set
            {
                this.batteryModel = value;
            }
        }
        public int HoursIdle
        {
            get
            {
                return hoursIdle;
            }
            set
            {
                this.hoursIdle = value;
            }
        }
        public int HoursTalk
        {
            get
            {
                return hoursTalk;
            }
            set
            {
                this.hoursTalk = value;
            }
        }

        public override string ToString()
        {
            return (BatteryM+" "+ HoursIdle+" "+ HoursTalk).ToString();
        }
    }
}
