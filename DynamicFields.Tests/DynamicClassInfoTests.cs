using DynamicFields.Data.Services.Fields;
using Xunit;

namespace DynamicFields.Tests
{
    public class DynamicClassInfoTests
    {
        [Fact]
        public void DynamicClassInfoTest()
        {
            Assert.Equal(new DynamicClassInfo(GetType()).Type, GetType());
        }

        [Fact]
        public void IsDynamicClassTest()
        {
            Assert.False(DynamicClassInfo.IsDynamicClass(typeof(NotDynamicTestClass)));
            Assert.True(DynamicClassInfo.IsDynamicClass(typeof(DynamicTestClass)));
        }

        class NotDynamicTestClass { }
        [DynamicClass]
        class DynamicTestClass { }
    }
}