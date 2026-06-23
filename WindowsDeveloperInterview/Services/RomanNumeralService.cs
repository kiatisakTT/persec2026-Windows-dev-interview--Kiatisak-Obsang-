using System;
using System.Collections.Generic;
using System.Text;
using WindowsDeveloperInterview.Interfaces;

namespace WindowsDeveloperInterview.Services;

public class RomanNumeralService : IRomanNumeralService
{
    private readonly int[] _values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
    private readonly string[] _symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

    private readonly Dictionary<char, int> _romanMap = new()
    {
        { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 }
    };
    //ข้อ 4
    public string ToRoman(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number), "เลขโรมันรองรับจำนวนเต็มบวกเท่านั้น");

        var sb = new StringBuilder();
        for (int i = 0; i < _values.Length; i++)
        {
            while (number >= _values[i])
            {
                number -= _values[i];
                sb.Append(_symbols[i]);
            }
        }
        return sb.ToString();
    }

    public int ToInt(string roman)
    {
        if (string.IsNullOrEmpty(roman)) return 0;

        int total = 0;
        for (int i = 0; i < roman.Length; i++)
        {
            if (!_romanMap.TryGetValue(roman[i], out int currentVal))
                throw new ArgumentException($"พบตัวอักษรโรมันที่ไม่ถูกต้อง: {roman[i]}");

            if (i + 1 < roman.Length && _romanMap.TryGetValue(roman[i + 1], out int nextVal) && nextVal > currentVal)
                total -= currentVal;
            else
                total += currentVal;
        }
        return total;
    }
}