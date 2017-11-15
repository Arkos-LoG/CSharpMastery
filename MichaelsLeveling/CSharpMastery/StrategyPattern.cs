using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMastery
{
    public class NoPattern1
    {
        public void EatWithFork()
        {
            
        }

        public void EatWithSpoon()
        {
            
        }
    }

    public class NoPattern2
    {
        public enum WaysToEat
        {
            Fork,
            Spoon    
        }

        public bool Eat(WaysToEat way)
        {
            switch (way)
            {
                case WaysToEat.Fork:
                    // call EatWithFork
                case WaysToEat.Spoon:
                // call EatWithSpoon
                default:
                    return false;
            }

        }
    }

    // THE STRATEGY PATTERN

    /*
      WHEN TO USE:
        there are many ways to do something like eat
    
        Realworld: Validating a business object that has many things that it has to validated on
        call one single validate function with the different 'strategies' for validating it

        Helps implement Dependency inversion principle (DIP)

        The two rules:
•	High-level modules should not depend on low-level modules. Both should depend on abstractions.
•	Abstractions should not depend on details. Details should depend on abstractions.

   BAD:
   
        public class Notification  
{
    private Email _email;
    private SMS _sms;
    public Notification()
    {
        _email = new Email();
        _sms = new SMS();
    }

    public void Send()
    {
        _email.SendEmail();
        _sms.SendSMS();
    }
}
 
    GOOD:

        // Notification now just depends on IMessage

public class Notification  
{
    private ICollection<IMessage> _messages;

    public Notification(ICollection<IMessage> messages)
    {
        this._messages = messages;
    }
    public void Send()
    {
        foreach(var message in _messages)
        {
            message.SendMessage();
        }
    }
}


     */

    public interface IEat
    {
        void Eat();
    }

    public class EatWithFork : IEat
    {
        public void Eat()
        {
            // implement eating with fork
        }
    }

    public class EatWithSpoon : IEat
    {
        public void Eat()
        {
            // implement eating with spoon  
        }
    }

    public class UseStrategyPatternToEat
    {
        public void Eat(IEat eat)
        {
            eat.Eat();
        }
    }
}
