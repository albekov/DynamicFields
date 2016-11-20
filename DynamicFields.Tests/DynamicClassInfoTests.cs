using System;
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

        [Theory]
        [InlineData(typeof(DynamicTestClass), true)]
        [InlineData(typeof(NotDynamicTestClass), false)]
        public void IsDynamicClassTest(Type type, bool isDynamic)
        {
            Assert.Equal(DynamicClassInfo.IsDynamicClass(type), isDynamic);
        }

        [Fact]
        public void GetInfoFromDynamicClassTest()
        {
            var type = typeof(DynamicTestClass);
            var info = type.GetDynamicClassInfo();
            Assert.Equal(type, info.Type);
        }

        [Fact]
        public void GetInfoFromNotDynamicClassTest()
        {
            var type = typeof(NotDynamicTestClass);
            Assert.Throws<InvalidOperationException>(() => type.GetDynamicClassInfo());
        }

        [Fact]
        public void DynamicPropertiesTest()
        {
            var type = typeof(DynamicTestClass);
            var fieldInfos = type.GetDynamicFields();
            Assert.Equal(fieldInfos.Count, 5);
        }

        class NotDynamicTestClass { }

        [DynamicClass]
        class DynamicTestClass
        {
            public int Prop1 { get; set; }
            public int? Prop2 { get; set; }
            public string Prop3 { get; set; }
            public DateTime Prop4 { get; set; }
            public DateTime? Prop5 { get; set; }
        }
    }
}