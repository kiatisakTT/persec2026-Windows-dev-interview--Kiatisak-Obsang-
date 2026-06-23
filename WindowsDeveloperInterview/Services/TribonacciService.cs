using System;
using WindowsDeveloperInterview.Interfaces;

namespace WindowsDeveloperInterview.Services;

public class TribonacciService : ITribonacciService
{
    //ข้อ 6
    public int[] GetSequence(int[] signature, int n)
    {
        if (n <= 0) return Array.Empty<int>();
        var result = new int[n];
        var safeSignature = signature ?? Array.Empty<int>();

        for (int i = 0; i < n; i++)
        {
            if (i < safeSignature.Length)
            {
                result[i] = safeSignature[i];
            }
            else
            {
                int sum = 0;
                if (i - 1 >= 0) sum += result[i - 1];
                if (i - 2 >= 0) sum += result[i - 2];
                if (i - 3 >= 0) sum += result[i - 3];
                result[i] = sum;
            }
        }
        return result;
    }
}