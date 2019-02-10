using NUnit.Framework;

namespace NullObject.Exercise
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Test()
        {
            var log = new NullLog();
            var account = new Account(log);
            account.SomeOperation();
        }

        [Test]
        public void SingleCallTest()
        {
            var a = new Account(new NullLog());
            a.SomeOperation();
        }

        [Test]
        public void ManyCallsTest()
        {
            var a = new Account(new NullLog());
            for (int i = 0; i < 100; ++i)
                a.SomeOperation();
        }
    }
}
