// <copyright file="Records.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReadLogFile
{
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.IO;
  using System.Linq;
  using System.Threading.Tasks;

  /// <summary>
  /// Класс для формирования логов.
  /// </summary>
  public class Records
  {
    /// <summary>
    /// Gets Поток для чтения файла.
    /// </summary>
    public StreamReader StreamReader { get; private set; }

    /// <summary>
    /// Gets Массив ошибок.
    /// </summary>
    public List<Record> LogsList { get; private set; }

    /// <summary>
    /// Конструктор класса Records, формирующий коллекцию ошибок.
    /// </summary>
    /// <param name="path">Путь к файлу с ошибками.</param>
    /// <returns>Task.</returns>
    public async Task CreateRecords(string path)
    {
      this.LogsList = new List<Record>();
      string line, dateTimeString;
      this.StreamReader = new StreamReader(path);
      bool parsingDate;

      while ((line = await this.StreamReader.ReadLineAsync()) != null)
      {
        try
        {
          var stringDataArray = line.Split(" ");
          dateTimeString = stringDataArray[0] + " " + stringDataArray[1];
          parsingDate = DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd H:mm:ss,fff", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime);

          if (parsingDate)
          {
            var message = stringDataArray.Skip(4).ToString();
            this.LogsList.Add(new Record()
            {
              DateTime = dateTime,
              NumberThread = Convert.ToInt32(stringDataArray[2].Substring(1, stringDataArray[2].Length - 2)),
              LoggerName = stringDataArray[3],
              Message = message,
            });
            Console.WriteLine(line);
          }
        }
        catch (Exception)
        {
          continue;
        }
      }
    }
  }
}
