using Cerebro14.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cerebro14.Services
{
    public static class EventLogic
    {
        public static bool EventIsInsideZone(Event zone, Event eve)
        {
            return DistanceBetween(zone.Latitude, zone.Longitude, eve.Latitude, eve.Longitude) > zone.Radio;
        }        
        
        static double DistanceBetween(double latA, double longA, double latB, double longB)
        {
            var RadianLatA = Math.PI * latA / 180;
            var RadianLatb = Math.PI * latB / 180;
            var RadianLongA = Math.PI * longA / 180;
            var RadianLongB = Math.PI * longB / 180;

            return (Math.Sin(RadianLatA)) *
                    Math.Sin(RadianLatb) +
                    Math.Cos(RadianLatA) *
                    Math.Cos(RadianLatb) *
                    Math.Cos(RadianLongA - RadianLongB);
        }
    }
}