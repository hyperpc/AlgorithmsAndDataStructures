using System;

namespace ch01_DataType
{
    public class DataType
    {
        public static void Test()
        {
            IntegerTest();
            FloatTest();
            DoubleTest();
            DecimalTest();
            CharTest();

            BoolTest();

            StringTest();
        }

        #region 1.1 Numeric
        /// <summary>
        /// byte, sbyte
        /// short, ushort
        /// int, uint
        /// long, ulong
        /// </summary>
        private static void IntegerTest()
        {
            Console.WriteLine($"Range of sbyte: {sbyte.MinValue} to {sbyte.MaxValue}");
            Console.WriteLine($"Range of byte: {byte.MinValue} to {byte.MaxValue}");

            Console.WriteLine($"Range of short: {short.MinValue} to {short.MaxValue}");
            Console.WriteLine($"Range of ushort: {ushort.MinValue} to {ushort.MaxValue}");

            Console.WriteLine($"Range of int: {int.MinValue} to {int.MaxValue}");
            Console.WriteLine($"Range of uint: {uint.MinValue} to {uint.MaxValue}");

            Console.WriteLine($"Range of long: {long.MinValue} to {long.MaxValue}");
            Console.WriteLine($"Range of ulong: {ulong.MinValue} to {ulong.MaxValue}");
        }

        /// <summary>
        /// float
        /// 3.141592653589793238462643383279f
        /// </summary>
        private static void FloatTest()
        {
            Console.WriteLine($"float.Epsilon: {float.Epsilon}");
            Console.WriteLine($"float.MinValue: {float.MinValue}");
            Console.WriteLine($"float.MaxValue: {float.MaxValue}");
            Console.WriteLine($"float.NaN: {float.NaN}");
            Console.WriteLine($"float.NegativeInfinity: {float.NegativeInfinity}");
            Console.WriteLine($"float.PositiveInfinity: {float.PositiveInfinity}");

            Console.WriteLine($"3.141592653589793238462643383279f: {3.141592653589793238462643383279f}");
        }

        /// <summary>
        /// double
        /// 3.141592653589793238462643383279
        /// </summary>
        private static void DoubleTest()
        {
            Console.WriteLine($"double.Epsilon: {double.Epsilon}");
            Console.WriteLine($"double.MinValue: {double.MinValue}");
            Console.WriteLine($"double.MaxValue: {double.MaxValue}");
            Console.WriteLine($"double.NaN: {double.NaN}");
            Console.WriteLine($"double.NegativeInfinity: {double.NegativeInfinity}");
            Console.WriteLine($"double.PositiveInfinity: {double.PositiveInfinity}");

            Console.WriteLine($"3.141592653589793238462643383279: {3.141592653589793238462643383279}");
        }

        /// <summary>
        /// decimal
        /// 3.141592653589793238462643383279m
        /// </summary>
        private static void DecimalTest()
        {
            Console.WriteLine($"decimal.MinusOne: {decimal.MinusOne}");
            Console.WriteLine($"decimal.Zero: {decimal.Zero}");
            Console.WriteLine($"decimal.One: {decimal.One}");
            Console.WriteLine($"decimal.MinValue: {decimal.MinValue}");
            Console.WriteLine($"decimal.MaxValue: {decimal.MaxValue}");

            Console.WriteLine($"3.141592653589793238462643383279m: {3.141592653589793238462643383279m}");
        }

        /// <summary>
        /// char
        /// </summary>
        private static void CharTest()
        {
            Console.WriteLine($"Range of char: {char.MinValue} to {char.MaxValue}");
        }
        #endregion

        #region 1.2 Boolean
        /// <summary>
        /// bool
        /// </summary>
        private static void BoolTest()
        {
            Console.WriteLine($"truth:{true}; truthStr: {bool.TrueString}");
            Console.WriteLine($"falth:{false}; falthStr: {bool.FalseString}");

            bool a = true;
            bool b = false;
            bool c = a;
            Console.WriteLine($"a: {a}, b: {b}, c: {c}");
            Console.WriteLine($"a AND b: {a && b}");
            Console.WriteLine($"a OR b: {a || b}");
            Console.WriteLine($"NOT a: {!a}");
            Console.WriteLine($"NOT b: {!b}");
            Console.WriteLine($"a XOR b: {a ^ b}");
            Console.WriteLine($"(c OR b) AND a: {(c || b) && a}");
        }
        #endregion

        #region 1.3 String
        private static void StringTest()
        {
            string first = "First String";
            Console.WriteLine($"First: {first}");

            string second = "Second String";
            Console.WriteLine($"Second: {second}");

            string red = "Red String";
            Console.WriteLine($"Red: {red}");

            string blue = "Blue String";
            Console.WriteLine($"Blue: {blue}");

            string purple = red + blue;
            Console.WriteLine($"Concatenation: {purple}");

            purple= "Purple String";
            Console.WriteLine($"Whoops! Mutation: {purple}");
        }
        #endregion
    }
}
