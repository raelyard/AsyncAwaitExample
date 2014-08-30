using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;

namespace AsyncAwaitExample
{
    [TestFixture]
    public class WhenCoachCancelsPractice
    {
        private Coach _coach;
        private Parent _parent0;
        private Parent _parent1;
        private Parent _parent2;

        [SetUp]
        public void Setup()
        {
            _parent0 = new Parent("parent0");
            _parent1 = new Parent("parent1");
            _parent2 = new Parent("parent2");

            _coach = new Coach(_parent0, _parent1, _parent2);
        }

        private async Task ExecuteCancelPractice()
        {
            await _coach.CancelPractice();
            Console.WriteLine("Coach has finished");
        }

        [Test]
        public void ShouldNotCallParent0WithoutCancellation()
        {
            AssertParentNotNotified(_parent0);
        }

        [Test]
        public void ShouldNotCallParent1WithoutCancellation()
        {
            AssertParentNotNotified(_parent1);
        }

        [Test]
        public void ShouldNotCallParent2WithoutCancellation()
        {
            AssertParentNotNotified(_parent2);
        }

        [Test]
        public async Task ShouldCallParent0()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_parent0);
        }

        [Test]
        public async Task ShouldCallParent1()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_parent1);
        }

        [Test]
        public async Task ShouldCallParent2()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_parent2);
        }

        private void AssertParentNotNotified(Parent parent)
        {
            parent.Notified.ShouldBeFalse();
        }

        private void AssertParentNotified(Parent parent)
        {
            parent.Notified.ShouldBeTrue();
        }
    }
}
