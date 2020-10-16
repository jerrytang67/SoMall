using System;
using Shouldly;
using TT.Extensions;
using Volo.Abp.Guids;
using Xunit;

namespace TT.SoMall.Samples
{
    public class ShortGuidTests : SoMallApplicationTestBase
    {
        private readonly IGuidGenerator _guidGenerator;


        public ShortGuidTests()
        {
            _guidGenerator = GetRequiredService<IGuidGenerator>();
        }

        [Fact]
        public void GuidShortedTest()
        {
            //act s
            var guid = _guidGenerator.Create();
            var @short = guid.ToShortString();
            @short.FromShortString().ShouldBe(guid);

            var guid2 = new Guid("59c34426-fdb2-3c88-87ff-39f5067be555");
            var short2 = guid2.ToShortString();
            short2.ShouldBe("JkTDWbL9iDyH_zn1BnvlVQ");
            short2.FromShortString().ShouldBe(guid2);
        }
    }
}