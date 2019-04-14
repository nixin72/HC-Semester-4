using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HulkHvkBLL;

namespace pdumaresq_E21_A04_avg_per_week {
    class Program {
        static void Main( string[] args ) {
            Reservation res = new Reservation();
            List<DateTime> dates = new List<DateTime>();

            res.ListReservations().ForEach(r => {
                dates.Add(r.sDate);
            });

            TimeSpan span = dates.Max() - dates.Min();

            double timesPerWeek = span.TotalDays / dates.Count;

            Console.WriteLine("Total days between first and last reservation start date: " + span.TotalDays);
            Console.WriteLine("Total number of weeks between first and last reservation: " + span.TotalDays / 7);
            Console.WriteLine("                            Total number of reservations: " + dates.Count);            
            Console.WriteLine("                  Average reservations starting per week: " + span.TotalDays / 7 / dates.Count);
            Console.ReadKey();
        }
    }
}
