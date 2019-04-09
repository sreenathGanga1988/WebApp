using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Extensions
{
    public static class Extensions
    {

        //public static string EmptyStringIfNull(this object value)
        //{
        //    if (value == null)
        //        return "";
        //    return value.ToString();
        //}


        public static decimal ZeroIfNullorEmpty(this object value)
        {
            if (value == null)
                return 0;
            return Decimal.Parse(value.ToString());
        }
    }

}