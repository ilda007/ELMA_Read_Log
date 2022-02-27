// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReadLogFile
{
  using System.Threading.Tasks;

  internal class Program
  {
    public static async Task Main(string[] args)
    {
      var logs = new Records();
      await logs.CreateRecords("sc-log-20220105.txt");
    }
  }
}
