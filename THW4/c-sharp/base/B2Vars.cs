// string name;
// name = "Tom";

// string name = "Tom";

// const string NAME = "Tom";

// Console.WriteLine(0b11);        // 3
// Console.WriteLine(0x0A);    // 10
// Console.WriteLine('\x78');    // x ASCII
// Console.WriteLine('\u0420');    // Р Unicode

// bool isDead = false; // System.Boolean
// byte bit2 = 102; // 0..255 1b System.Byte
// sbyte bit1 = -101; // -128..127 1b System.SByte
// short n2 = 102; // -32768..32767 2b System.Int16
// ushort n2 = 102; // 0..65535 2b System.UInt16
// int a = 10; // -2147483648..2147483647 4b System.Int32
// uint a = 10U; // 0..4294967295 4b System.UInt32
// long a = -10L; // –9 223 372 036 854 775 808 .. 9 223 372 036 854 775 807 8b System.Int64
// ulong a = 10UL; //  0 .. 18 446 744 073 709 551 615 8b System.UInt64
// float a = 3.14F;
// float b = 30.6f; // -3.4*10^38 .. 3.4*10^38 4b System.Single
// double d = 1.2; //  ±5.0*10^-324 .. ±1.7*10^308 8b System.Double
// decimal c = 1005.8M;
// decimal d = 334.8m; // ±1.0*10^-28 .. ±7.9228*10^28 16b .28chars System.Decimal
// char a = 'A'; // Unicode 2b System.Char
// string hello = "Hello"; // Unicode System.String
// object a = 22;
// object a = null; // any 8b x64
// var c = 20; // auto type, not null

// int x = 10;
// int z = x / 3; // 3
// double y = x / 3.0; // 3.3333333
// double y = x / 3; // 3
// double z = x % 4.0; //результат равен 2

// ushort a = 4;
// byte b = (byte)a;
// auto
// byte -> short -> int -> long -> decimal
// int -> double
// short -> float -> double
// char -> int

// try
// {
// int a = 33;
// int b = 600;
// byte c = checked((byte)(a + b));
// Console.WriteLine(c);
// }
// catch (OverflowException ex)
// {
// Console.WriteLine(ex.Message);
// }

// int[] nums = new int[4];
// int[] nums2 = new int[4] { 1, 2, 3, 5 };
// int[] nums3 = new int[] { 1, 2, 3, 5 };
// int[] nums4 = new[] { 1, 2, 3, 5 };
// int[] nums5 = { 1, 2, 3, 5 };
// Console.WriteLine(nums.Length); // 4
// Console.WriteLine(nums2[^1]); // 5 nums2.Length - 1

// int[,] numbers = { { 0, 1, 2 }, { 3, 4, 5 } };
// numbers.GetUpperBound(0) + 1; // 2 rows
// numbers.GetUpperBound(1) + 1; // 3 columns
// numbers.Length // 6
// foreach => 0..5

// int[][] nums = new int[3][];
// nums[0] = new int[2] { 1, 2 };          // выделяем память для первого подмассива
// nums[1] = new int[3] { 1, 2, 3 };       // выделяем память для второго подмассива
// nums[2] = new int[5] { 1, 2, 3, 4, 5 };

// int[][] numbers = {
//     new int[] { 1, 2 },
//     new int[] { 1, 2, 3 },
//     new int[] { 1, 2, 3, 4, 5 }
// };

/*
DayTime dayTime = DayTime.Morning;
if (dayTime == DayTime.Morning)
    Console.WriteLine("Доброе утро");

(int) DayTime.Night // 3

// enum DayTime : byte
enum DayTime 
{
    Some1, // 0
    Morning = 3,
    Afternoon, // 4!?
    Evening = Morning, // 3
    Night = 3, // ok
    Some2 = 7
}
*/