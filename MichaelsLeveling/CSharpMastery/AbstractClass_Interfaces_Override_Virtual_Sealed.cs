﻿using System;
using System.ComponentModel;
using System.IO;


namespace CSharpMastery
{
    /* 
    
    PLEASE NOTE THAT THIS COMMENTED OUT INFORMATION IS FOR ME FOR CONTINUAL REVIEW--FOR A RESOURCE ON INTERFACES AND ABASTRACT CLASSES

    PLEASE SEE THE CODE BELOW THIS
    
    
    ----------------
    -- INTERFACES --
    ----------------

    An interface defines a type just like a class
    It's a contract with public members: properties, methods, events, indexers with a class that will provide those items
    
    Does not contain implementation details but provides declarations for what should be implemented
    
    It is an API for an object – guaranteed for the class implementing the interface to have members the interface describes, 
    providing implementation details 
    
    Can only inherit from one abstract class but can implement multiple interfaces
    
    Interface is ultimate abstraction because it contains no implementation details but tells what your software needs
    
    Cannot use access modifiers like public; members of interface have to be available so they are always public
    
    They are also implicitly virtual so you don’t have to use abstract keyword in front of the members
     
    !!! Program to an abstraction rather than a concrete type  Program to an interface rather than a concrete class !!!
    
    Great example here https://stackoverflow.com/questions/383947/what-does-it-mean-to-program-to-an-interface 

    EXAMPLE FROM STACKOVERFLOW:

     class DiningRoom {

       DiningRoom(Person[] diningPeople, IPest[] pests) { ... }   <-- NOTICE IPest

       void ServeDinner() {
         when diningPeople are eating,

           foreach pest in pests
             pest.BeAnnoying();

          // a member of pests array could be class HouseFly : IPest; or class Telemarketer : IPest
       }
     }    
    
     ANOTHER NOTE: IN SOLID Interfaces help accomplish Dependency Inversion Principle

     The two rules:

        •	High-level modules should not depend on low-level modules. Both should depend on abstractions.
        •	Abstractions should not depend on details. Details should depend on abstractions.

    **They are used in Dependency Injection (help create loosely coupled classes)
    **They are used in Composition over Inheritance

    -- Composition Implementation - using interfaces for composition in C# allows for a highly flexible design. 

    Identify behaviors that would have been in a base class.  For instance, a vehicle base class may have steering, accelerating, and a manufacturer.  
    Instead of making these abstract to be overridden, make interfaces for these items.  So… IAccelerate, ISteer, IManufacture, etc.  
    Interfaces represent the behaviors the system must have.  Interfaces allow for polymorphic behavior.
    Then have a IVehicle interface that has these behaviors interfaces.

    Interface IVehicle
    {
	    ISteering Steering { get; }
	    IAccelerate Accelerate { get; }
        IManufacture Manufacture { get; }
    }

     ***********************************************
     * 
     *  ALSO see ReflectionTestRunner as it also uses interfaces !!!!!!
     * 
     *************************************************
  
  ----------------------
  -- ABSTRACT CLASSES --
  ----------------------

  (abstract modifier indicates that the thing being modified has a missing or incomplete implementation)

  Intended to be a base class of other classes
  
  Abstract classes are very often, if not always, used to describe something abstract, something that is more of a concept than a real thing. 
  
  cannot be instantiated because they may have abstract members that have no implementation
  may be partially implemented, or not at all implemented. 
  may contain abstract methods and accessors.
  
  •	An abstract method is implicitly a virtual method.
  •	Abstract method declarations are only permitted in abstract classes.
  
  A non-abstract class derived from an abstract class must include actual implementations of all inherited abstract methods and accessors.

  Abstract classes are useful when creating components because they allow you specify a level of functionality in some methods, 
  but leave the implementation of other methods until a specific implementation of that class is needed. 

  CONS:

  -They can become rigid and make a complicated inheritance tree

  The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share. 
  For example, a class library may define an abstract class that is used as a parameter to many of its functions, 
  and require programmers using that library to provide their own implementation of the class by creating a derived class.

  ---------------------------
  Abstract Class VS Interface
  ---------------------------

  An interface is kind of like an abstract class with nothing but abstract methods.
  Abstract classes may contain implementation where interfaces only contain declarations
  
  Members on abstract classes can contain access modifiers; interfaces cannot; they are already public—no secrets in the contact everything is exposed.
  
  Interfaces act as a contract where a class is required to implement all of the methods and properties
  
  Interfaces cannot have fields, constructors, and destructors; abstract classes can have those items 

  Classes can inherit multiple interfaces.

  You can add interfaces like IComparable to your objects so if you can call List<yourObject>.Sort() which relies on IComparable
  You would provide your own implementation of IComparable, so you can use the Sort method on your list of objects.

 */

    // a contract which abstract below will have to provide this method and property
    // also provides an abstract concept that derived of abstract are some sort of creatures/living thing
    // we will go further creating dogs and cats that are ICreatures
    public interface ICreature
    {
        string Describe();
        string Name { get; set; }
    }

    public abstract class AbstractClass_Interfaces_Override_Virtual_Sealed : ICreature, INotifyPropertyChanged, IDisposable
    {
        private readonly TextReader _textReader;
        private string _name;

        public event PropertyChangedEventHandler PropertyChanged; // this satisfies the contract with INotifyPropertyChanged

        // satifies contract with ICreature
        public string Name
        {
            get { return _name; }
            set
            {
                PropertyChangedEventHandler propertyChanged = PropertyChanged;

                if (_name != value)
                {
                    _name = value; // 'this' is the derived instance (Dog or Cat) of AbstractClass_Interfaces_Override_Virtual_Sealed
                    propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        protected AbstractClass_Interfaces_Override_Virtual_Sealed(string pathToWalkingInstructions)
        {
            _textReader = pathToWalkingInstructions != null 
                ? new StreamReader(pathToWalkingInstructions) : null;
        }

        // derived will have to implement this
        // satisfies contract with ICreature
        public abstract string Describe();

        public virtual void ShowWalkingInstructions()
        {
            if (_textReader != null)
            {
                Console.WriteLine(_textReader.ReadToEnd());
            }
            else
            {
                Console.WriteLine("Not Available");
            }
        }

        // this satisfies contract with IDisposable
        public void Dispose()
        {
            // This is public function for users to release the
            // resources. We then call protected Dispose for actual freeing of the resources
            Dispose(true);

            // tell GC to not call Finalize/Destructor
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                _textReader?.Dispose(); // using null propagation...
            }

            // Release unmanaged resources here in any case as they will not be 
            // released by GC
        }

        // Destructor/Finalize 
        ~AbstractClass_Interfaces_Override_Virtual_Sealed()
        {
            //  Garbage collector calls the the Finalize when object become inaccessible. 

            // the managed resources are released when GC runs

            // calling dispose false to release unmanaged resources
            Dispose(false);

            // http://www.c-sharpcorner.com/UploadFile/nityaprakash/back-to-basics-dispose-vs-finalize/ 
        }
    }

    public class Dog : AbstractClass_Interfaces_Override_Virtual_Sealed
    {
        public Dog(string pathToWalkingInstructions = null) 
            : base(pathToWalkingInstructions) { }

        // sealed method cannot be overridden in derived class.
        public sealed override string Describe()
        {
            return "I'm a dog!";
        }
    }

    public class BigDog : Dog
    {

        // CAN'T DO THIS BECAUSE OF SEALED method
        
        //public override string Describe()
        //{
        //    return null;
        //}
    }

    //
    //  !!! CAN'T DO THIS BECAUSE Cat is SEALED !!!
    //
    //public class LargeCat : Cat { }

    // sealed class cannot be a base class of another derived class
    public sealed class Cat : AbstractClass_Interfaces_Override_Virtual_Sealed
    {
        public Cat(string pathToWalkingInstructions = null) 
            : base(pathToWalkingInstructions) { }
        public override string Describe()
        {
            return "I'm a cat!";
        }
    }

}