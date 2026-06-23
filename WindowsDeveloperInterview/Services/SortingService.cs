using System;
using System.Linq;
using System.Text.RegularExpressions;
using WindowsDeveloperInterview.Interfaces;

namespace WindowsDeveloperInterview.Services;

public class SortingService : ISortingService
{
    
    private static readonly Regex AlphaNumRegex = new(@"^([A-Za-z]+)(\d+)(.*)$", RegexOptions.Compiled);
     //ข้อ 2
    public string[] SortAlphanumeric(string[] items)
    {
        if (items == null || items.Length == 0) return Array.Empty<string>();

        return items.Select(item =>
        {
            var match = AlphaNumRegex.Match(item);
            return new
            {
                Original = item,
                Prefix = match.Success ? match.Groups[1].Value : item,
                Number = match.Success ? int.Parse(match.Groups[2].Value) : 0,
                Suffix = match.Success ? match.Groups[3].Value : ""
            };
        })
        .OrderBy(x => x.Prefix)
        .ThenBy(x => x.Number)
        .ThenBy(x => x.Suffix)
        .Select(x => x.Original)
        .ToArray();
    }
    //ข้อ 5
    public int SortDigitsDescending(int number)
    {
        if (number < 0) throw new ArgumentException("โจทย์กำหนดให้รับค่าเฉพาะ Positive Int เท่านั้น");

        char[] digits = number.ToString().ToCharArray();
        Array.Sort(digits);
        Array.Reverse(digits);
        return int.Parse(new string(digits));
    }
}
