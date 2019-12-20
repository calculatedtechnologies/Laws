using System;

namespace CalculatedTechnologiesLibrary.Laws
{
    //Create an EventArgs class to share data.
    class EventArgsExample : EventArgs
    {
        public string Name { get; set; }

        public EventArgsExample(string name)//constructor
        {
            Name = name;
        }
    }

    //Identify class that will publish/raise event
    class PublisherExample
    {
        //Create an EventHander that uses EventArgs
        public event EventHandler<EventArgsExample> OnEventRaised = delegate { };

        //Create a method matching the EventArgs parameters to raise the Event
        public void RaiseEvent(string name)
        {
            OnEventRaised(this, new EventArgsExample(name));
        }
    }

    //Identify class that will subscribe to publisher

    class SubscriberExample
    {
        //Create a method matching the EventHandler signature
        public void EventExampleListener(object source, EventArgsExample args)
        {
            //Do something with the EventArgs data inside the subscription method 
            Console.WriteLine($"Hello {args.Name}");

            //Invoke an event in the subscriber if applicable
            //OnEventRaised?.Invoke();
        }
    }

    class Application
    {
        public void Main()
        {
            //Create an instance of the publisher class
            PublisherExample publisherExample = new PublisherExample();

            //Create an instance of the subscriber class
            SubscriberExample subscriberExample = new SubscriberExample();
            
            //Subscribe to publisher
            publisherExample.OnEventRaised += subscriberExample.EventExampleListener;
        }
    }
}
