using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace AsyncAwaitExample
{
    [TestFixture]
    public class WhenCoachCancelsPractice
    {
        private Coach _coach;
        private Parent _parent0;
        private Parent _parent1;
        private Parent _parent2;

        private async Task ArrangeAct()
        {
            _parent0 = MockRepository.GeneratePartialMock<Parent>("parent0");
            _parent1 = MockRepository.GeneratePartialMock<Parent>("parent1");
            _parent2 = MockRepository.GeneratePartialMock<Parent>("parent2");

            _coach = new Coach(_parent0, _parent1, _parent2);
            await _coach.CancelPractice();
            Console.WriteLine("Coach has finished");
        }

        [Test]
        public async Task ShouldCallParent0()
        {
            await ArrangeAct();
            AssertParentNotified(_parent0);
        }

        [Test]
        public async Task ShouldCallParent1()
        {
            await ArrangeAct();
            AssertParentNotified(_parent1);
        }

        [Test]
        public async Task ShouldCallParent2()
        {
            await ArrangeAct();
            AssertParentNotified(_parent2);
        }

        private void AssertParentNotified(Parent parent)
        {
            parent.AssertWasCalled(theParent => theParent.Notify());
        }
    }
}
