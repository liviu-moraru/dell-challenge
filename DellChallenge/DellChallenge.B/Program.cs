using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            // This is a bad constructed hierarchy. In short, the current hierarchy violates the "Interface Segregation Principle" of a clean design
            // A clear sign that it is in fact a bad design is that the implementer of the classes must construct many methods with empty implementation or to throw exceptions, methods not relevant for a specific class 
            // I propose the following hierarchy
            
            var human = new Human();
            var fish = new Fish();
            var bird = new Bird();
            human.GetSpecies();
            fish.GetSpecies();
            bird.GetSpecies();
            Console.ReadKey();

        }
    }


    public interface IEater
    {
        void Eat();
    }

    public interface IDrinker
    {
        void Drink();
    }

    public interface IFlyer
    {
        void Fly();
    }

    public interface ISwimmer
    {
        void Swim();
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
        void Fly();
        void Swim();
    }

    public class Species
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public class Human : Species, IDrinker, IEater
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I'm human");
        }
    }

    public class Bird : Species, IDrinker, IEater, IFlyer
    {
        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I'm a bird");
        }
    }

    public class Fish : Species, IDrinker, IEater, ISwimmer
    {
        public void Swim()
        {
            throw new NotImplementedException();
        }

        public void Drink()
        {
            throw new NotImplementedException();
        }

        public void Eat()
        {
            throw new NotImplementedException();
        }


        public override void GetSpecies()
        {
            Console.WriteLine($"I'm a fish");
        }

    }

    //    public class Species
    //    {
    //        public virtual void GetSpecies()
    //        {
    //            Console.WriteLine($"Echo who am I?");
    //        }
    //    }
    //
    //    public class Human : ISpecies
    //    {
    //        public void Drink()
    //        {
    //            throw new NotImplementedException();
    //        }
    //
    //        public void Eat()
    //        {
    //            throw new NotImplementedException();
    //        }
    //
    //        public void Fly()
    //        {
    //            throw new NotImplementedException();
    //        }
    //
    //        public void Swim()
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }
    //
    //    public class Bird
    //    {
    //    }
    //
    //    public class Fish
    //    {
    //    }
}

