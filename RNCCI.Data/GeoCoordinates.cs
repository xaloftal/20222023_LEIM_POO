using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNCCI.Modelos
{
    public static class GeoCoordinates
    {

        public static double DistanceTo(double[] coordenadas1, double[] coordenadas2)
        {
            double rlat1 = Math.PI * coordenadas1[0] / 180;
            double rlat2 = Math.PI * coordenadas2[0] / 180;
            double theta = coordenadas1[1] - coordenadas2[1];
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            return dist * 1.609344;
               
        }
    }
}
