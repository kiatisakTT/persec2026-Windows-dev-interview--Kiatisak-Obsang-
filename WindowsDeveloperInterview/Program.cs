using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WindowsDeveloperInterview.Interfaces;
using WindowsDeveloperInterview.Services;

namespace WindowsDeveloperInterview;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;


        var serviceProvider = new ServiceCollection()
            .AddSingleton<IBracketService, BracketService>()
            .AddSingleton<ISortingService, SortingService>()
            .AddSingleton<IAutocompleteService, AutocompleteService>()
            .AddSingleton<IRomanNumeralService, RomanNumeralService>()
            .AddSingleton<ITribonacciService, TribonacciService>()
            .BuildServiceProvider();

        var bracket = serviceProvider.GetRequiredService<IBracketService>();
        var sorter = serviceProvider.GetRequiredService<ISortingService>();
        var autocomplete = serviceProvider.GetRequiredService<IAutocompleteService>();
        var roman = serviceProvider.GetRequiredService<IRomanNumeralService>();
        var tribonacci = serviceProvider.GetRequiredService<ITribonacciService>();

        // ทดสอบข้อ 1
        Console.WriteLine($"ข้อ1 Balanced Brackets]: {bracket.IsBalanced("([()])")}");

        // ทดสอบข้อ 2
        string[] q2Input = { "TH19", "SG20", "TH2" };
        Console.WriteLine($"ข้อ2 Alphanumeric Sort: [{string.Join(", ", sorter.SortAlphanumeric(q2Input))}]");

        // ทดสอบข้อ 3
        string[] q3Input = { "Mother", "Think", "Worthy", "Apple", "Android" };
        Console.WriteLine($"ข้อ3 Autocomplete (th): [{string.Join(", ", autocomplete.Search("th", q3Input, 3))}]");

        // ทดสอบข้อ 4
        Console.WriteLine($"ข้อ4 Int To Roman : {roman.ToRoman(1989)}");
        Console.WriteLine($"ข้อ4 Roman To Int : {roman.ToInt("MCMLXXXIX")}");

        // ทดสอบข้อ 5
        Console.WriteLine($"ข้อ5 Sort Digits Descending : {sorter.SortDigitsDescending(3008)}");

        // ทดสอบข้อ 6
        int[] q6Result = tribonacci.GetSequence(new int[] { 1, 3, 5 }, 5);
        Console.WriteLine($"ข้อ6 Tribonacci: [{string.Join(", ", q6Result)}]");

        Console.WriteLine("=======================================================");
        Console.WriteLine("Run เสร็จสมบูรณ์ กด Enter เพื่อปิด...");
        Console.ReadLine();
    }
}
