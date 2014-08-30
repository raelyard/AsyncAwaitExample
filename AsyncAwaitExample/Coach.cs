using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    public class Coach
    {
        private readonly Parent[] _rootNotificationParents;

        public Coach(params Parent[] rootNotificationParents)
        {
            _rootNotificationParents = rootNotificationParents;
        }

        public async Task CancelPractice()
        {
            Console.WriteLine("Starting to Call parents");
            var parentAwaitables = _rootNotificationParents.Select(parent => parent.Notify()).ToArray();
            Console.WriteLine("finished outgoing calls, waiting for calls back");
            await Task.WhenAll(parentAwaitables);
            Console.WriteLine("Done notifying parents");
        }
    }
}
