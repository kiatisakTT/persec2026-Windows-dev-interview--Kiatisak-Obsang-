using System;
using System.Linq;
using WindowsDeveloperInterview.Interfaces;

namespace WindowsDeveloperInterview.Services;

public class AutocompleteService : IAutocompleteService
{
    //ข้อ 3
    public string[] Search(string search, string[] items, int maxResult)
    {
        if (string.IsNullOrEmpty(search) || items == null || maxResult <= 0)
            return Array.Empty<string>();

        return items
            .Where(item => item.Contains(search, StringComparison.OrdinalIgnoreCase))
            .Select(item => new
            {
                Item = item,
                Priority = item.StartsWith(search, StringComparison.OrdinalIgnoreCase) ? 1 :
                           item.EndsWith(search, StringComparison.OrdinalIgnoreCase) ? 3 : 2
            })
            .OrderBy(x => x.Priority)
            .Select(x => x.Item)
            .Take(maxResult)
            .ToArray();
    }
}