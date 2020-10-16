using System;

namespace TT.Extensions
{
    public static class GeoEx
    {
        //地球半径，单位米
        private const double EARTH_RADIUS = 6378137;

        /// <summary>
        ///     计算两点位置的距离，返回两点的距离，单位：米
        ///     该公式为GOOGLE提供，误差小于0.2米
        /// </summary>
        /// <param name="lng1">第一点经度</param>
        /// <param name="lat1">第一点纬度</param>
        /// <param name="lng2">第二点经度</param>
        /// <param name="lat2">第二点纬度</param>
        /// <returns></returns>
        public static int GetDistance(double lng1, double lat1, double lng2, double lat2)
        {
            var radLat1 = Rad(lat1);
            var radLng1 = Rad(lng1);
            var radLat2 = Rad(lat2);
            var radLng2 = Rad(lng2);
            var a = radLat1 - radLat2;
            var b = radLng1 - radLng2;
            var result =
                2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                                        Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2))) *
                EARTH_RADIUS;
            return Convert.ToInt32(result);
        }

        /// <summary>
        ///     经纬度转化成弧度
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private static double Rad(double d)
        {
            return d * Math.PI / 180d;
        }
    }

    public static class MapConverter
    {
        /// <summary>
        ///     圆周率
        /// </summary>
        private const double PI = 3.1415926535897932384626;

        private const double X_PI = PI * 3000.0 / 180.0;

        /// <summary>
        ///     地理位置是否位于中国以外
        /// </summary>
        /// <param name="wgLat">WGS-84坐标纬度</param>
        /// <param name="wgLon">WGS-84坐标经度</param>
        /// <returns>
        ///     true：国外
        ///     false：国内
        /// </returns>
        public static bool OutOfChina(double wgLat, double wgLon)
        {
            if (wgLon < 72.004 || wgLon > 137.8347)
            {
                return true;
            }

            if (wgLat < 0.8293 || wgLat > 55.8271)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     WGS-84坐标系转火星坐标系 (GCJ-02)
        /// </summary>
        /// <param name="wgLat">WGS-84坐标纬度</param>
        /// <param name="wgLon">WGS-84坐标经度</param>
        /// <param name="mgLat">输出：GCJ-02坐标纬度</param>
        /// <param name="mgLon">输出：GCJ-02坐标经度</param>
        public static void WGS84ToGCJ02(double wgLat, double wgLon, out double mgLat, out double mgLon)
        {
            if (OutOfChina(wgLat, wgLon))
            {
                mgLat = wgLat;
                mgLon = wgLon;
            }
            else
            {
                double dLat;
                double dLon;
                Delta(wgLat, wgLon, out dLat, out dLon);
                mgLat = wgLat + dLat;
                mgLon = wgLon + dLon;
            }
        }

        /// <summary>
        ///     火星坐标系 (GCJ-02)转WGS-84坐标系
        /// </summary>
        /// <param name="mgLat">GCJ-02坐标纬度</param>
        /// <param name="mgLon">GCJ-02坐标经度</param>
        /// <param name="wgLat">输出：WGS-84坐标纬度</param>
        /// <param name="wgLon">输出：WGS-84坐标经度</param>
        public static void GCJ02ToWGS84(double mgLat, double mgLon, out double wgLat, out double wgLon)
        {
            if (OutOfChina(mgLat, mgLon))
            {
                wgLat = mgLat;
                wgLon = mgLon;
            }
            else
            {
                double dLat;
                double dLon;
                Delta(mgLat, mgLon, out dLat, out dLon);
                wgLat = mgLat - dLat;
                wgLon = mgLon - dLon;
            }
        }

        /// <summary>
        ///     火星坐标系 (GCJ-02)转WGS-84坐标系
        /// </summary>
        /// <param name="mgLat">GCJ-02坐标纬度</param>
        /// <param name="mgLon">GCJ-02坐标经度</param>
        /// <param name="wgLat">输出：WGS-84坐标纬度</param>
        /// <param name="wgLon">输出：WGS-84坐标经度</param>
        public static void GCJ02ToWGS84Exact(double mgLat, double mgLon, out double wgLat, out double wgLon)
        {
            const double InitDelta = 0.01;
            const double Threshold = 0.000001;

            var dLat = InitDelta;
            var dLon = InitDelta;
            var mLat = mgLat - dLat;
            var mLon = mgLon - dLon;
            var pLat = mgLat + dLat;
            var pLon = mgLon + dLon;

            double nLat;
            double nLon;

            var i = 0;
            do
            {
                wgLat = (mLat + pLat) / 2;
                wgLon = (mLon + pLon) / 2;

                WGS84ToGCJ02(wgLat, wgLon, out nLat, out nLon);

                dLat = nLat - mgLat;
                dLon = nLon - mgLon;
                if (Math.Abs(dLat) < Threshold && Math.Abs(dLon) < Threshold)
                {
                    break;
                }

                if (dLat > 0)
                {
                    pLat = wgLat;
                }
                else
                {
                    mLat = wgLat;
                }

                if (dLon > 0)
                {
                    pLon = wgLon;
                }
                else
                {
                    mLon = wgLon;
                }
            } while (++i <= 30);
        }

        /// <summary>
        ///     百度坐标系 (BD-09)转火星坐标系 (GCJ-02)
        /// </summary>
        /// <param name="bdLat">百度坐标系纬度</param>
        /// <param name="bdLon">百度坐标系经度</param>
        /// <param name="mgLat">输出：GCJ-02坐标纬度</param>
        /// <param name="mgLon">输出：GCJ-02坐标经度</param>
        public static void BD09ToGCJ02(double bdLat, double bdLon, out double mgLat, out double mgLon)
        {
            var x = bdLon - 0.0065;
            var y = bdLat - 0.006;
            var z = Math.Sqrt(x * x + y * y) - 0.00002 * Math.Sin(y * X_PI);
            var theta = Math.Atan2(y, x) - 0.000003 * Math.Cos(x * X_PI);
            mgLat = z * Math.Sin(theta);
            mgLon = z * Math.Cos(theta);
        }

        /// <summary>
        ///     火星坐标系 (GCJ-02)转百度坐标系 (BD-09)
        /// </summary>
        /// <param name="mgLat">GCJ-02坐标纬度</param>
        /// <param name="mgLon">GCJ-02坐标经度</param>
        /// <param name="bdLat">输出：百度坐标系纬度</param>
        /// <param name="bdLon">输出：百度坐标系经度</param>
        public static void GCJ02ToBD09(double mgLat, double mgLon, out double bdLat, out double bdLon)
        {
            var x = mgLon;
            var y = mgLat;
            var z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * X_PI);
            var theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * X_PI);
            bdLat = z * Math.Sin(theta) + 0.006;
            bdLon = z * Math.Cos(theta) + 0.0065;
        }

        /// <summary>
        ///     WGS-84坐标系转百度坐标系 (BD-09)
        /// </summary>
        /// <param name="wgLat">WGS-84坐标纬度</param>
        /// <param name="wgLon">WGS-84坐标经度</param>
        /// <param name="bdLat">输出：百度坐标系纬度</param>
        /// <param name="bdLon">输出：百度坐标系经度</param>
        public static void WGS84ToBD09(double wgLat, double wgLon, out double bdLat, out double bdLon)
        {
            double mgLat;
            double mgLon;

            WGS84ToGCJ02(wgLat, wgLon, out mgLat, out mgLon);
            GCJ02ToBD09(mgLat, mgLon, out bdLat, out bdLon);
        }

        public static (double, double) WGS84ToBD09(this (double wgLat, double wgLon) data)
        {
            WGS84ToGCJ02(data.wgLat, data.wgLon, out var mgLat, out var mgLon);
            GCJ02ToBD09(mgLat, mgLon, out var bdLat, out var bdLon);
            return (bdLat, bdLon);
        }

        public static (double, double) GCJ02ToBD09(this (double gcLat, double gcLon) data)
        {
            GCJ02ToBD09(data.gcLat, data.gcLon, out var bdLat, out var bdLon);
            return (bdLat, bdLon);
        }

        public static (double, double) BD09ToGCJ02(this (double bdLat, double bdLon) data)
        {
            double mgLat;
            double mgLon;
            BD09ToGCJ02(data.bdLat, data.bdLon, out mgLat, out mgLon);
            return (mgLat, mgLon);
        }

        /// <summary>
        ///     百度坐标系 (BD-09)转WGS-84坐标系
        /// </summary>
        /// <param name="bdLat">百度坐标系纬度</param>
        /// <param name="bdLon">百度坐标系经度</param>
        /// <param name="wgLat">输出：WGS-84坐标纬度</param>
        /// <param name="wgLon">输出：WGS-84坐标经度</param>
        public static void BD09ToWGS84(double bdLat, double bdLon, out double wgLat, out double wgLon)
        {
            double mgLat;
            double mgLon;

            BD09ToGCJ02(bdLat, bdLon, out mgLat, out mgLon);
            GCJ02ToWGS84(mgLat, mgLon, out wgLat, out wgLon);
        }

        public static double Distance(double LatA, double LonA, double LatB, double LonB)
        {
            const double EarthR = 6371000.0;

            var x = Math.Cos(LatA * PI / 180.0) * Math.Cos(LatB * PI / 180.0) * Math.Cos((LonA - LonB) * PI / 180);
            var y = Math.Sin(LatA * PI / 180.0) * Math.Sin(LatB * PI / 180.0);
            var s = x + y;
            if (s > 1)
            {
                s = 1;
            }

            if (s < -1)
            {
                s = -1;
            }

            return Math.Acos(s) * EarthR;
        }

        public static double Distance(this (double LatA, double LonA) a, (double LatB, double LonB) b)
        {
            const double EarthR = 6371000.0;

            var x = Math.Cos(a.LatA * PI / 180.0) * Math.Cos(b.LatB * PI / 180.0) * Math.Cos((a.LonA - b.LonB) * PI / 180);
            var y = Math.Sin(a.LatA * PI / 180.0) * Math.Sin(b.LatB * PI / 180.0);
            var s = x + y;
            if (s > 1)
            {
                s = 1;
            }

            if (s < -1)
            {
                s = -1;
            }

            return Math.Acos(s) * EarthR;
        }

        private static void Delta(double Lat, double Lon, out double dLat, out double dLon)
        {
            const double AXIS = 6378245.0;
            const double EE = 0.00669342162296594323;

            dLat = TransformLat(Lon - 105.0, Lat - 35.0);
            dLon = TransformLon(Lon - 105.0, Lat - 35.0);
            var radLat = Lat / 180.0 * PI;
            var magic = Math.Sin(radLat);
            magic = 1 - EE * magic * magic;
            var sqrtMagic = Math.Sqrt(magic);
            dLat = dLat * 180.0 / (AXIS * (1 - EE) / (magic * sqrtMagic) * PI);
            dLon = dLon * 180.0 / (AXIS / sqrtMagic * Math.Cos(radLat) * PI);
        }

        private static double TransformLat(double x, double y)
        {
            var ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * PI) + 20.0 * Math.Sin(2.0 * x * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * PI) + 40.0 * Math.Sin(y / 3.0 * PI)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * PI) + 320 * Math.Sin(y * PI / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        private static double TransformLon(double x, double y)
        {
            var ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * PI) + 20.0 * Math.Sin(2.0 * x * PI)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * PI) + 40.0 * Math.Sin(x / 3.0 * PI)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * PI) + 300.0 * Math.Sin(x / 30.0 * PI)) * 2.0 / 3.0;
            return ret;
        }
    }
}