using System;
using System.Threading.Tasks;

namespace AsyncAwaitExample
{
    public class Parent
    {
        private readonly string _name;

        public Parent(string name)
        {
            _name = name;
        }

        public async virtual Task Notify()
        {
            Console.WriteLine("notifying parent {0}", _name);
            await Task.Delay(1000);
            Console.WriteLine("done with notification, calling back notifier");
        }
    }
}
