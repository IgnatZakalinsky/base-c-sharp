// namespace Classes;
namespace Classes
{
    public class B5Classes
    {

        Person tom = new Person();  // создание объекта класса Person

        // определение класса Person
        public class Person
        {
            public const string type = "Person";
            public readonly int id; // const/init
            public string name { get; set; /*init; // for auto-const after constructor*/} = "Undefined";
            public int age
            {
                get { return age; } // without => set-only
                private set { age = value; } // without => read-only
            }
            public string Name => name; // read-only
            public string Name2
            {
                get => name;
                set => name = value;
            }

            static class Operations // no constructor
            {
                public static int Add(int x, int y) => x + y;
                public static int Subtract(int x, int y) => x - y;
                public static int Multiply(int x, int y) => x * y;
            }

            static Person()
            {
                // no callable! init static props and/or do samething 1 time in first call Person // () or .static-prop
            }
            public void Print()
            {
                Console.WriteLine($"Имя: {name}  Возраст: {age}");
            }
            public Person() : this("") { }
            // {
            //     name = "";
            // }
            public Person(string n)
            {
                name = n;
                age = 1;
            }
            public void Deconstruct(out string personName, out int personAge)
            {
                personName = name;
                personAge = age;
            }
        }

        // readonly struct Pers // all props must be readonly
        struct Pers
        {
            public string name;
            public int age
            {
                get { return age; }
                set { age = value; }
            }

            public void Print()
            {
                Console.WriteLine($"Имя: {name}  Возраст: {age}");
            }
        }

        static void notInt(int x){}
        static void notString(string y){}







        public void test()
        {
            tom.name = "Tom";
            Console.WriteLine(Person.type);

            Person tom2 = new Person { name = "Tom" };
            Person tom3 = new() { name = "Tom" };

            (string name, int age) = tom;
            // (_, int age) = tom;

            Pers tom4 = new Pers { name = "Tom", age = 22 };
            Pers bob = tom4 with { name = "Bob" }; // just struct

            int? x = null;
            string? y = null;
            notInt((int)x); // (x!) not worked with structs
            notString(y!);
            Nullable<int> xNullable = null;
            if (xNullable.HasValue && xNullable.Value == xNullable) xNullable = 1; 
            if (x is null) x = 2; 
            if (x is not null) x = 3; 

        }
    }
}