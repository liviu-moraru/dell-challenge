using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability

            //We want to extend the functionality of the MyClass adding a new functionality
            // One solution is to use DecoratorPattern, introducing a new class MyExtendedClas. An object of the old class is wrapped inside the new class. The old functionality is implemented my the inner object.

            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {

            var myNewObject = new MyClass();
            var myExtendedObject = new MyExtendedClass();
            var num1 = myNewObject.Do(1, 3);
            var num2 = myExtendedObject.Do(1, 3);
            var num3 = myExtendedObject.DoExtended(1, 3, 5);
            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);

            //            myObject _MyNewObject = new myObject();
            //            int obj1 = _MyNewObject.Do(1, 3);
            //            int num2 = _MyNewObject.DoExtended(1, 3, 5);
            //            Console.WriteLine(obj1);
            //            Console.WriteLine(num2);
        }
    }

    public interface IDo
    {
        int Do(int a, int b);
    }

    public interface IDoExtended
    {
        int DoExtended(int a, int b, int c);
    }

    public class MyClass  : IDo // instead of MyObject
    {
        public int Do(int a, int b)
        {
            return a + b;
        }
    }

    public class MyExtendedClass : IDo, IDoExtended
    {
        private readonly MyClass _myClass;

        public MyExtendedClass()
        {
            _myClass = new MyClass();
        }

        public int Do(int a, int b)
        {
            return _myClass.Do(a, b);
        }

        public int DoExtended(int a, int b, int c)
        {
            return a + b + c;
        }
    }



//    private static void StartHere()
//        {
//            myObject _MyNewObject = new myObject();
//            int obj1 = _MyNewObject.Do(1, 3);
//            int num2 = _MyNewObject.DoExtended(1, 3, 5);
//            Console.WriteLine(obj1);
//            Console.WriteLine(num2);
//        }
//    }
//
//    class myObject
//    {
//
//        public int Do(int a, int b)
//        {
//            return a + b;
//        }
//
//        public int DoExtended(int a, int b, int c)
//        { return a + b + c;
//        }
//    }
}
