using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Операции в рантайме
/// </summary>
static class PascalRuntime
{
    public static void Error(in string message)
    {
        throw new Exception($"Обнаружена ошибка: {message}\n");
    }
}

