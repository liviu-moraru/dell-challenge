using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.

            //The next statement creates an object of type B, derived from base class A
            // The derived class constructor is called after a call to the base class constructor, so the first output on the screen will be A.A().
            // After that the constructor of class B is called. The first statement in the constructor is a call to the static method Console.WriteLine. So the next output will be B.B()
            // The next statement in the B's constructor is Age = 0 and so the set implementation of the public property Age will be called.
            // The property is declared in the base class, but the getter and setter are public, so the B class has access to both getter and setter.
            // In the setter, the field _age is set to value 0. The _age field represents the state of the B object, because the derived class inherits all the fields of the base class.
            // The B class has not direct access to the field, because the field is declared private in the base class. It can modify its state only using the property Age
            // The last statement in the setter is a call to Console.WriteLine("A .Age");

            // So the output will be:
            // A.A()
            // B.B()
            // A .Age
            // The state of the object created: _age = 0


            // As an observation. The statement Age = 0 is useless, because the state of the created object _age is already 0 ( all the fields of the new created object are initialized with a default value ( 0 for ints)

            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
