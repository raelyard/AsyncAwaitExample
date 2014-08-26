using System.Security.Principal;
using NUnit.Framework;
using Rhino.Mocks;

namespace AsyncAwaitExample
{
    [TestFixture]
    public class WhenCoachCancelsPractice
    {
        private IParent _parent0;
        private IParent _parent1;
        private IParent _parent2;

        [TestFixtureSetUp]
        public void Setup()
        {
            _parent0 = MockRepository.GenerateStub<IParent>();
            _parent1 = MockRepository.GenerateStub<IParent>();
            _parent2 = MockRepository.GenerateStub<IParent>();

            _parent0.Notify();
            _parent1.Notify();
            _parent2.Notify();
        }

        [Test]
        public void ShouldCallParent0()
        {
            AssertParentNotified(_parent0);
        }

        [Test]
        public void ShouldCallParent1()
        {
            AssertParentNotified(_parent1);
        }

        [Test]
        public void ShouldCallParent2()
        {
            AssertParentNotified(_parent2);
        }

        private void AssertParentNotified(IParent parent)
        {
            parent.AssertWasCalled(theParent => theParent.Notify());
        }
    }

    public interface IParent
    {
        void Notify();
    }
}
