// <copyright file="Record.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ReadLogFile
{
  using System;

  /// <summary>
  /// Запись из файла(ошибка).
  /// </summary>
  public class Record
  {
    /// <summary>
    /// Gets or sets DateTime Время возникновения ошибки.
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Gets or sets NumberThread Номер потока.
    /// </summary>
    public int NumberThread { get; set; }

    /// <summary>
    /// Gets or sets LoggerName Название функции где произошла ошибка с указанием номера строки.
    /// </summary>
    public string LoggerName { get; set; }

    /// <summary>
    /// Gets or sets Message Сообщение ошибки.
    /// </summary>
    public string Message { get; set; }
  }
}
