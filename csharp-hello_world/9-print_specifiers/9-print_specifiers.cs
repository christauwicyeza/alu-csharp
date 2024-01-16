﻿using System;
class Program
{
	static void Main(string[] args)
	{
		double percent = .7553;
		double currency = 98765.4321;
		Console.WriteLine($"Percent: {(percent * 100):N2}%");
        Console.WriteLine($"Currency: {string.Format("{0:C2}", currency)}");
    }
}