﻿using Hangfire.Console;
using Hangfire.Server;

namespace etl_labs.API;

public static class Util
{
    public static string CronExpression(string horario, string day, string mes = "*", string diaSemana = "*") => $"0 {horario} {day} {mes} {diaSemana}";

    public static void Console(string message, PerformContext? context) => context.WriteLine(message);
}
