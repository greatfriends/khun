using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatFriends.Khun;
using Xunit;
using Xunit2.Should;

namespace GreatFriends.KhunFacts
{
  public class KhunExtensionFacts
  {

    [Fact]
    public void EmptyString()
    {
      "".AsKhun().ShouldBeEqual(""); 
    }

    [Fact]
    public void Null()
    {
      ((string)null).AsKhun().ShouldBeEqual("");
    }

    [Fact]
    public void JustName()
    { 
      "ชื่อ นามสกุล".AsKhun().ShouldBeEqual("คุณชื่อ นามสกุล");
    }

    [Fact]
    public void AlreadyHasKhun()
    { 
      "คุณชื่อ นามสกุล".AsKhun().ShouldBeEqual("คุณชื่อ นามสกุล");
    }

    [Fact]
    public void TrimName()
    {
      " คุณชื่อ นามสกุล".AsKhun().ShouldBeEqual("คุณชื่อ นามสกุล"); 
    }

    [Fact]
    public void JustOneSpaceBetweenName()
    { 
      "  คุณชื่อ  กลาง   นามสกุล ".AsKhun().ShouldBeEqual("คุณชื่อ กลาง นามสกุล");
    }

    [Fact]
    public void RemoveCommonPrefixNames()
    {
      Assert.Equal("คุณชื่อ นามสกุล", "นายชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "นางสาวชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "นางชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "เด็กชายชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "เด็กหญิงชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "อาจารย์ชื่อ นามสกุล".AsKhun());

      Assert.Equal("คุณชื่อ นามสกุล", "น.ส.ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "ด.ช.ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "ด.ญ.ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "อ.ชื่อ นามสกุล".AsKhun());
    }

    [Fact]
    public void RemoveCommonPrefixNamesWithSpaces()
    {
      Assert.Equal("คุณชื่อ นามสกุล", "นาย ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "นางสาว ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "นาง ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "เด็กชาย ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "เด็กหญิง ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "อาจารย์ ชื่อ นามสกุล".AsKhun());

      Assert.Equal("คุณชื่อ นามสกุล", "น.ส. ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "ด.ช. ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "ด.ญ. ชื่อ นามสกุล".AsKhun());
      Assert.Equal("คุณชื่อ นามสกุล", "อ. ชื่อ นามสกุล".AsKhun());
    }
     
    [Fact]
    public void Kunakorn()
    {
      Assert.Equal("คุณคุณากร นามสกุล", "คุณากร นามสกุล".AsKhun());
      Assert.Equal("คุณคุณากร นามสกุล", "นายคุณากร นามสกุล".AsKhun());
      Assert.Equal("คุณคุณากร นามสกุล", "คุณคุณากร นามสกุล".AsKhun());
    }

    [Fact]
    public void NotAppendKhunForForeignName()
    {
      Assert.Equal("Donald Trump", "Donald Trump".AsKhun());
      Assert.NotEqual("คุณDonald Trump", "Donald Trump".AsKhun());

      Assert.Equal("Trump", "Trump".AsKhun());
      Assert.NotEqual("คุณTrump", "Trump".AsKhun());
    }

    [Fact]
    public void KhunWithSpace_ShouldBeTruncated()
    {
      Assert.Equal("คุณชื่อ นามสกุล", "คุณ ชื่อ นามสกุล".AsKhun());
      Assert.NotEqual("คุณ ชื่อ นามสกุล", "คุณ ชื่อ นามสกุล".AsKhun());
    }
  }
}
