namespace AdventOfCode23.Console.App.Helpers
{
    using Spectre.Console;

    public static class TableExtensions
    {
        public static void InsertDay(this Table table, int dayNumber, string solution)
        {
            var dayText = new Text($"{dayNumber}", new Style(Color.Red)).Centered();
            var bodyText = new Text(solution, new Style(Color.Green)).Centered();
            table.AddRow(dayText, bodyText);
        }
    }
}
