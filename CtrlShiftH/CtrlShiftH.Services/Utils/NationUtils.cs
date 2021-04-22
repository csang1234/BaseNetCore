using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace CtrlShiftH.Services.Utils
{
    public static class NationUtils
    {
        public static string GetNationName(this string code)
        {
            var embeded = Properties.EmbededResources.nations;
            var ros = new ReadOnlySpan<byte>(embeded);
            var nations = JsonSerializer.Deserialize<List<Nation>>(ros);
            return nations.Where(_ => _.countryCode == code).Select(_ => _.name).FirstOrDefault();
        }

        public static string GetNationCountryCode(this string name)
        {
            name = name.Trim();
            var embeded = Properties.EmbededResources.nations;
            var ros = new ReadOnlySpan<byte>(embeded);
            var nations = JsonSerializer.Deserialize<List<Nation>>(ros);
            return nations.Where(_ => _.name.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(_ => _.countryCode).FirstOrDefault();
        }
    }
}
