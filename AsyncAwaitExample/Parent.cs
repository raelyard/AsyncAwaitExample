using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    public class Parent
    {
        private readonly string _name;
        private readonly Parent[] _otherParentsForNotification;

        public bool Notified { get; set; }

        public Parent(string name, params Parent[] otherParentsForNotification)
        {
            _name = name;
            _otherParentsForNotification = otherParentsForNotification;
        }

        public async virtual Task Notify()
        {
            Console.WriteLine("{0} receiving notification", _name);
            Notified = true;
            // the phone conversation will take a finite time, so modeling that with a delay:
            await Task.Delay(1000);
            await NotifyOtherParents();
            Console.WriteLine("{0} done with notification, calling back notifier", _name);
        }

        private async Task NotifyOtherParents()
        {
            Console.WriteLine("{0} Starting to Call other parents", _name);
            var parentAwaitables = _otherParentsForNotification.Select(parent => parent.Notify()).ToArray();
            Console.WriteLine("{0} finished outgoing calls, waiting for calls back", _name);
            await Task.WhenAll(parentAwaitables);
            Console.WriteLine("{0} Done notifying parents", _name);
        }
    }
}
