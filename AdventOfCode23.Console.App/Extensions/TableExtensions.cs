namespace AdventOfCode23.Console.App.Helpers
{
    using Spectre.Console;

    public static class TableExtensions
    {
        public static void InsertDay(this Table table, int dayNumber, string solution)
        {
            var dayText = new Text($"{dayNumber}");
            var bodyText = new Text(solution, new Style(Color.Blue, Color.Black));
            table.AddRow(dayText, bodyText);
        }
    }
}
