using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.DefineClass
{
    class GSMCallHistoryTest
    {
        public static void CallHistory()
        {
            GSM callTest = new GSM("3310", "Nokia", 10, "Stamat",
                new Battery(BatteryType.NiCd, 999999999, 99999999),
                new Display(1, 2));

            callTest.add("22.03", "23:03", "0884324234", 240);
            callTest.add("21.04", "03:03", "0888567235", 600);
            callTest.add("10.00", "08:45", "0854345567", 720);
            callTest.add("02.12", "09:32", "0875678678", 3240);

            for (int i = 0; i < callTest.CallHistory.Count; i++)
            {
                Console.WriteLine(callTest.CallHistory[i]);
            }
            Console.WriteLine(callTest.callPrice());

            callTest.delete();
            Console.WriteLine(callTest.callPrice());

            callTest.clearHistory();
            for (int i = 0; i < callTest.CallHistory.Count; i++)
            {
                Console.WriteLine(callTest.CallHistory[i]);
            }
        }
    }
}
