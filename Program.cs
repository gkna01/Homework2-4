using System;
class Investor
{
    static int FindMaxCustomers(int[] population, int K)
    {
        int N = population.Length;

        int[] prefixSum = new int[N];
        prefixSum[0] = population[0];

        for (int i = 1; i < N; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + population[i];
        }

        int maxCustomers = 0;

        for (int i = 0; i < N; i++)
        {
            int start = Math.Max(0, i - K);
            int end = Math.Min(N - 1, i + K);


            int sum = prefixSum[end] - (start > 0 ? prefixSum[start - 1] : 0);
            maxCustomers = Math.Max(maxCustomers, sum);
        }

        return maxCustomers;
    }

    static void Main()
    {
        Console.Write("N : ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("K : ");
        int K = int.Parse(Console.ReadLine());

        int[] population = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter the population of street segment " + (i + 1) + ": ");
            population[i] = int.Parse(Console.ReadLine());
        }

        int maxCustomers = FindMaxCustomers(population, K);
        Console.WriteLine("Maximum number of customers: " + maxCustomers);
    }
}