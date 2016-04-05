using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap4.HRHolidayBook.Service
{
    public class HolidayService
    {
        public static bool BookHolidayFor(int employeeId, DateTime from, DateTime to)
        {
            bool booked = false;
            TimeSpan numberOfDaysRequestdForHoliday = to - from;
            if(numberOfDaysRequestdForHoliday.Days > 0)
            {
                if(RequestHolidayDoesNotClashWithExistingHoliday(employeeId, from, to))
                {
                    int holidayAvailable = GetHolidayRemaining(employeeId);
                }
            }

            return true;
        }

        private static bool RequestHolidayDoesNotClashWithExistingHoliday(int employeeId, DateTime from, DateTime to)
        {
            // Check new holiday no grap with existing holiday
            return true;
        }

        private static int GetHolidayRemaining(int employeeId)
        {
            return 3;
        }

    }
}
