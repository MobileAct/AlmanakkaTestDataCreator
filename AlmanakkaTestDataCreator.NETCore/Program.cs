using System;
using System.Linq;
using System.Collections.Generic;
using AlmanakkaTestDataCreator.NETStandard;
using Utf8Json;
using System.IO;

namespace AlmanakkaTestDataCreator.NETCore
{
    public class Program
    {
        private const string outPutDirectory = "docs";
        private const string rootDirectorySymbolFileName = "README.md";

        public static void Main(string[] args)
        {
            Console.WriteLine("Start CreatingTestData");

            var creator = new CalendarDataCreator();

            FileInfo symbolFile = findSolutionFile(rootDirectorySymbolFileName);
            string outPutDirectoryPath = Path.Combine(symbolFile.DirectoryName, outPutDirectory);
            if (Directory.Exists(outPutDirectoryPath))
            {
                Directory.Delete(outPutDirectoryPath, true);
            }
            DirectoryInfo workerDirectory = Directory.CreateDirectory(outPutDirectoryPath);

            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Sunday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Monday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Tuesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Wednesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Thursday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Saturday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Sunday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Monday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Tuesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Wednesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Thursday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 1, 31), DayOfWeek.Saturday, false, workerDirectory);

            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Sunday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Monday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Tuesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Wednesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Thursday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Saturday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Sunday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Monday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Tuesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Wednesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Thursday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 2, 1), DayOfWeek.Saturday, false, workerDirectory);

            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Sunday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Monday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Tuesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Wednesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Thursday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Saturday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Sunday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Monday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Tuesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Wednesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Thursday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2018, 12, 31), DayOfWeek.Saturday, false, workerDirectory);

            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Sunday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Monday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Tuesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Wednesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Thursday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Saturday, true, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Sunday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Monday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Tuesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Wednesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Thursday, false, workerDirectory);
            writeJson(creator, (2018, 1, 1), (2019, 12, 31), DayOfWeek.Saturday, false, workerDirectory);

            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Sunday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Monday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Tuesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Wednesday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Thursday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Saturday, true, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Sunday, false, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Monday, false, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Tuesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Wednesday, false, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Thursday, false, workerDirectory);
            writeJson(creator, (2018, 1, 15), (2018, 2, 15), DayOfWeek.Saturday, false, workerDirectory);

            Console.WriteLine("End CreatingTestData");
        }

        private static FileInfo findSolutionFile(string fileName)
        {
            var directory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);

            while (true)
            {
                FileInfo file = directory.GetFiles(fileName).FirstOrDefault(x => x.Name == fileName);
                if (file != null)
                {
                    return file;
                }

                directory = directory.Parent;
            }
        }

        private static void writeJson(
            CalendarDataCreator creator,
            (int year, int month, int day) startDate,
            (int year, int month, int day) endDate,
            DayOfWeek dayOfWeekOrderStart,
            bool isContainDaysOfDifferentMonth,
            DirectoryInfo workerDirectory
        )
        {
            List<Month> months = creator.Create(
                new DateTime(startDate.year, startDate.month, startDate.day),
                new DateTime(endDate.year, endDate.month, endDate.day),
                dayOfWeekOrderStart,
                isContainDaysOfDifferentMonth
            );

            byte[] json = JsonSerializer.Serialize(months);
            string jsonText = JsonSerializer.PrettyPrint(json);
            string fileName = $"{startDate.year}-{startDate.month}-{startDate.day}_{endDate.year}-{endDate.month}-{endDate.day}" +
                $"_{dayOfWeekOrderStart}_{isContainDaysOfDifferentMonth}.json";

            File.WriteAllText(Path.Combine(workerDirectory.FullName, fileName), jsonText);
        }
    }
}
