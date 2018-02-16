using NUnit.Framework;

namespace FluentSwitch.Tests
{
    [TestFixture]
    public class FluentSwitchFactoryExtensionsTests
    {
        private enum MyTestEnum
        {
            Value1,
            Value2,
            Value3
        }
        
        [Test]
        public void Returns_the_string_when_the_enum_if_found()
        {
            const MyTestEnum myEnum = MyTestEnum.Value1;

            var result = myEnum.Switch()
                .When(MyTestEnum.Value1, () => "Found")
                .When(MyTestEnum.Value2, () => "Value2")
                .When(MyTestEnum.Value3, () => "Value3")
                .Value();
            
            Assert.AreEqual("Found", result);
        }

        [Test]
        public void Returns_the_default_if_no_enum_if_found()
        {
            const MyTestEnum myEnum = MyTestEnum.Value1;

            var result = myEnum.Switch()
                .When(MyTestEnum.Value2, () => "Value2")
                .When(MyTestEnum.Value3, () => "Value3")
                .Else(() => "Not Found")
                .Value();
            
            Assert.AreEqual("Not Found", result);
        }

        [Test]
        public void Returns_default_value_if_no_enum_found()
        {
            const MyTestEnum myEnum = MyTestEnum.Value1;

            var result = myEnum.Switch()
                .When(MyTestEnum.Value2, () => "Value2")
                .When(MyTestEnum.Value3, () => "Value3")
                .Value();

            Assert.AreEqual(default(string), result);
        }

        [Test]
        public void Returns_default_value_even_when_not_declared_as_the_last_method_in_the_chain()
        {
            const MyTestEnum myEnum = MyTestEnum.Value1;

            var result = myEnum.Switch()
                .Else(() => "Not Found")
                .When(MyTestEnum.Value2, () => "Value2")
                .When(MyTestEnum.Value3, () => "Value3")
                .Value();
            
            Assert.AreEqual("Not Found", result);
        }
    }
}