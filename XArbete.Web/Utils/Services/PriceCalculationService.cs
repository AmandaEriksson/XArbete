using System;
using XArbete.Web.DogHotel.Models;
using XArbete.Web.Utils.Constants;

namespace XArbete.Web.Utils.Services
{
    public class PriceCalculationService
    {
        static int HourOfDayPrice(int hourOfday, bool weekend = false)
        {
            if (weekend)
                return PriceContants.HallWeekendPricePerHour;

            else if (hourOfday >= 6 && hourOfday < 8)
                return PriceContants.HallDayEarlyBird;

            else if (hourOfday >= 8 && hourOfday < 17)
                return PriceContants.HallDayPricePerHour;

            else if (hourOfday >= 17 && hourOfday < 21)
                return PriceContants.HallEveningPricePerHour;

            else
                return PriceContants.HallDayEarlyBird;

        }

        static bool IsWeekend(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday)
                return true;
            else
                return false;
        }

        static int AllDayCalculation(bool weekend)
        {
            if (weekend)
                return PriceContants.HallAllDayOnWeekendPrice;
            else
                return PriceContants.HallAllDayPrice;
        }
        public static int TrainingHallPriceCalculation(DateTime start, DateTime end, bool allday)
        {
            int price = 0;
            if (allday)
            {
                price += AllDayCalculation(IsWeekend(start.DayOfWeek));
            }
            else
            {
                for (int i = start.Hour; i < end.Hour; i++)
                {
                    if (IsWeekend(start.DayOfWeek))
                    {
                        price += HourOfDayPrice(i, true);
                    }
                    else
                    {
                        price += HourOfDayPrice(i);
                    }
                }
            }

            return price;
        }

        public static int HotelPriceCalculation(HotelBooking booking)
        {
            int sum = PriceContants.HotelPriceOneNight * (booking.To - booking.From).Days;

            if (booking.Grooming)
                sum += PriceContants.Grooming;
            if (booking.Training)
                sum += PriceContants.Training;
            if (booking.ExtraWalk)
                sum += PriceContants.ExtraWalk;

            return sum;
        }
    }
}
