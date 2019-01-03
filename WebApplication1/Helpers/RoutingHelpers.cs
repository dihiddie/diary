using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dihiddieDiary.Helpers
{
    public static class RoutingHelpers
    {
        public static string RemoveController(this string fullControllerClassName) => fullControllerClassName.Replace(
            "Controller",
            string.Empty);
    }
}