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
        private Parent _level1Parent0;
        private Parent _level1Parent1;
        private Parent _level1Parent2;
        private Parent _level2Parent0;
        private Parent _level2Parent1;
        private Parent _level2Parent2;

        [SetUp]
        public void Setup()
        {
            _level1Parent0 = new Parent("parent0");
            _level1Parent1 = new Parent("parent1");
            _level1Parent2 = new Parent("parent2");
            _level2Parent0 = new Parent("parent3");
            _level2Parent1 = new Parent("parent4");
            _level2Parent2 = new Parent("parent5");

            _coach = new Coach(_level1Parent0, _level1Parent1, _level1Parent2, _level2Parent0, _level2Parent1, _level2Parent2);
        }

        private async Task ExecuteCancelPractice()
        {
            await _coach.CancelPractice();
            Console.WriteLine("Coach has finished");
        }

        [Test]
        public void ShouldNotCallLevel1Parent0WithoutCancellation()
        {
            AssertParentNotNotified(_level1Parent0);
        }

        [Test]
        public void ShouldNotCallLevel1Parent1WithoutCancellation()
        {
            AssertParentNotNotified(_level1Parent1);
        }

        [Test]
        public void ShouldNotCallLevel1Parent2WithoutCancellation()
        {
            AssertParentNotNotified(_level1Parent2);
        }

        [Test]
        public void ShouldNotCallLevel2Parent0WithoutCancellation()
        {
            AssertParentNotNotified(_level2Parent0);
        }

        [Test]
        public void ShouldNotCallLevel2Parent1WithoutCancellation()
        {
            AssertParentNotNotified(_level2Parent1);
        }

        [Test]
        public void ShouldNotCallLevel2Parent2WithoutCancellation()
        {
            AssertParentNotNotified(_level2Parent2);
        }

        [Test]
        public async Task ShouldCallLevel1Parent0()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level1Parent0);
        }

        [Test]
        public async Task ShouldCallLevel1Parent1()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level1Parent1);
        }

        [Test]
        public async Task ShouldCallLevel1Parent2()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level1Parent2);
        }

        [Test]
        public async Task ShouldCallLevel2Parent0()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level2Parent0);
        }

        [Test]
        public async Task ShouldCallLevel2Parent1()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level2Parent1);
        }

        [Test]
        public async Task ShouldCallLevel2Parent2()
        {
            await ExecuteCancelPractice();
            AssertParentNotified(_level2Parent2);
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
