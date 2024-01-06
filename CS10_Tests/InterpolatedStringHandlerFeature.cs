using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS10_Tests
{
    internal class InterpolatedStringHandlerFeature
    {
        public void ExecuteMe2()
        {
            int number = 5742;
            string example5 = $"Le nombre {number} est affiché avec {{number}}.";
            Console.WriteLine(example5);

        }
        public void ExecuteMe()
        {
            //var logger = new Logger() { EnabledLevel = LogLevel.Warning };
            //var time = DateTime.Now;

            //logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
            //logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
            //logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");

            //string example1 = $"'{1,6}'";
            //Console.WriteLine(example1);
            //string example2 = $"'{1,-6}'";
            //Console.WriteLine(example2);
            //string example3 = $"'{1234567,6}'";
            //Console.WriteLine(example3);

            //string example4 = $"{45235.776522:0.000}";
            //Console.WriteLine(example4);
            int number = 5742;
            string example5 = $"Le nombre {number} est affiché avec {{number}}.";
            Console.WriteLine(example5);

            //int limit = 7;
            //string exemple6 = $"La limite est: {(limit > 5 ? "haute" : "basse")}";

            //string exemple7 = @"C:\MyFolder\InnerFolder\File.txt";

            //string innerFolderName = "TheInnerFolder";
            //string exemple8 = $@"C:\MyFolder\{innerFolderName}\File.txt";
            //string exemple9 = @$"C:\MyFolder\{innerFolderName}\File.txt";

            //return;



            var point1 = new ThreeDimensionPoint(4, 7, 9);
            var point2 = new TwoDimensionPoint(4, 7);

            //Console.WriteLine($"{nameof(point1)}: {point1}");
            //Console.WriteLine($"{nameof(point2)}: {point2}");

            //ShowPoint($"{nameof(point1)}: {point1}");
            //ShowPoint($"{nameof(point2)}: {point2}");

            //ShowPoint("(", ")", $"{nameof(point1)}: {point1}");
            //ShowPoint("(", ")", $"{nameof(point2)}: {point2}");

            //PointStringFormatter pointFormatter = $"{nameof(point1)}: {point1} / {nameof(point2)}: {point2}";
            //Console.WriteLine(pointFormatter);
        }


        public void ShowPoint(PointStringFormatter point)
        {
            Console.WriteLine(point.GetFormattedText());
        }

        public void ShowPoint(string formattingPrefix, string formattingSuffix, 
            [InterpolatedStringHandlerArgument("formattingPrefix", "formattingSuffix")] PointStringFormatterV2 point)
        {
            Console.WriteLine(point.GetFormattedText());
        }

    }

    [InterpolatedStringHandler]
    public ref struct PointStringFormatter
    {
        StringBuilder builder;

        public PointStringFormatter(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
            //Console.WriteLine(GetHashCode());
        }

        public void AppendLiteral(string s)
        {
            //Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

            builder.Append(s);
            //Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
                where T: class 
            {
            string pointAsString = t switch
            {
                ThreeDimensionPoint threeDimensionPoint => $"{threeDimensionPoint.X}; {threeDimensionPoint.Y}; {threeDimensionPoint.Z}",
                TwoDimensionPoint twoDimensionPoint => $"{twoDimensionPoint.X}; {twoDimensionPoint.Y}",
                null => "null",
                string formattedString => formattedString,
                _ => throw new InvalidOperationException($"{nameof(T)} is unknown")
            };


            //if (t is null)
            //    AppendLiteral("null");
            //if (t is ThreeDimensionPoint threeDimensionPoint)
            //    AppendLiteral($"{threeDimensionPoint.X}; {threeDimensionPoint.Y}; {threeDimensionPoint.Z}");
            //else if (t is TwoDimensionPoint twoDimensionPoint)
            //    AppendLiteral($"{twoDimensionPoint.X}; {twoDimensionPoint.Y}");
            //else if (t is string)
            //    AppendLiteral(t as string);
            //else
            //    throw new InvalidOperationException($"{nameof(T)} is unknown");


            AppendLiteral(pointAsString);
        }

        public override string ToString()
        {
            return this.GetFormattedText();
        }

        internal string GetFormattedText() => builder.ToString();

    }



    [InterpolatedStringHandler]
    public class PointStringFormatterV2
    {
        private StringBuilder builder;
        private string formattingPrefix;
        private string formattingSuffix;

        public PointStringFormatterV2(int literalLength, int formattedCount, string formattingPrefix, string formattingSuffix)
        {
            builder = new StringBuilder(literalLength);
            this.formattingPrefix = formattingPrefix;
            this.formattingSuffix = formattingSuffix;
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
        }

        public void AppendLiteral(string s)
        {
            builder.Append(s);
        }

        public void AppendFormatted<T>(T t)
        {
            string pointAsString = t switch
            {
                ThreeDimensionPoint threeDimensionPoint => $"{threeDimensionPoint.X}; {threeDimensionPoint.Y}; {threeDimensionPoint.Z}",
                TwoDimensionPoint twoDimensionPoint => $"{twoDimensionPoint.X}; {twoDimensionPoint.Y}",
                null => "null",
                string formattedString => formattedString,
                _ => throw new InvalidOperationException($"{nameof(T)} is unknown")
            };

            AppendLiteral(this.formattingPrefix);
            AppendLiteral(pointAsString);
            AppendLiteral(this.formattingSuffix);
        }

        internal string GetFormattedText() => builder.ToString();
    }






    public class TwoDimensionPoint
    {
        public TwoDimensionPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return $"{X}; {Y}";
        }
    }

    public class ThreeDimensionPoint
    {
        public ThreeDimensionPoint(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }


        public override string ToString()
        {
            return $"{X}; {Y}; {Z}";
        }
    }





    [InterpolatedStringHandler]
    public class LogInterpolatedStringHandler
    //public ref struct LogInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder;

        public LogInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
            Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
            Console.WriteLine(GetHashCode());
        }

        public void AppendLiteral(string s)
        {
            Console.WriteLine($"\tAppendLiteral called: {{{s}}}");

            builder.Append(s);
            Console.WriteLine($"\tAppended the literal string");
        }

        public void AppendFormatted<T>(T t)
        {
            Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");

            builder.Append(t?.ToString());
            Console.WriteLine($"\tAppended the formatted object");
        }

        internal string GetFormattedText() => builder.ToString();
    }



    //[InterpolatedStringHandler]
    //public ref struct LogInterpolatedStringHandlerV2
    //{
    //    // Storage for the built-up string
    //    StringBuilder builder;
    //    private readonly bool enabled;

    //    public LogInterpolatedStringHandlerV2(int literalLength, int formattedCount, Logger logger, LogLevel logLevel)
    //    {
    //        enabled = logger.EnabledLevel >= logLevel;
    //        builder = new StringBuilder(literalLength);
    //        Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
    //    }

    //    public void AppendLiteral(string s)
    //    {
    //        Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
    //        if (!enabled) return;

    //        builder.Append(s);
    //        Console.WriteLine($"\tAppended the literal string");
    //    }
   

    //    public void AppendFormatted<T>(T t)
    //    {
    //        Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
    //        if (!enabled) return;

    //        builder.Append(t?.ToString());
    //        Console.WriteLine($"\tAppended the formatted object");
    //    }

    //    internal string GetFormattedText() => builder.ToString();
    //}


    public enum LogLevel
    {
        Off,
        Critical,
        Error,
        Warning,
        Information,
        Trace
    }

    public class Logger
    {
        public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

        public void LogMessage(LogLevel level, string msg)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(msg);
        }

        public void LogMessage(LogLevel level, LogInterpolatedStringHandler builder)
        {
            if (EnabledLevel < level) return;
            Console.WriteLine(builder.GetFormattedText());
        }

        //public void LogMessage(LogLevel level, [InterpolatedStringHandlerArgument("", "level")] LogInterpolatedStringHandlerV2 builder)
        //{
        //    if (EnabledLevel < level) return;
        //    Console.WriteLine(builder.GetFormattedText());
        //}
    }
}
