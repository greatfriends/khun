using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreatFriends.Khun;
using Xunit;

namespace GreatFriends.KhunFacts {
  public class KhunExtensionFacts {

    [Fact]
    public void EmptyString() {
      Assert.Equal("", "".AsKhun());
    }

    [Fact]
    public void Null() {
      Assert.Equal("", ((string)null).AsKhun());
    }

    [Fact]
    public void JustName() {
      Assert.Equal("คุณชื่อ นามสกุล", "ชื่อ นามสกุล".AsKhun());
    }

    [Fact]
    public void AlreadyHasKhun() {
      Assert.Equal("คุณชื่อ นามสกุล", "คุณชื่อ นามสกุล".AsKhun());
    }

    [Fact]
    public void TrimName() {
      Assert.Equal("คุณชื่อ นามสกุล", " คุณชื่อ นามสกุล ".AsKhun());
    }

    [Fact]
    public void JustOneSpaceBetweenName() {
      Assert.Equal("คุณชื่อ กลาง นามสกุล", "  คุณชื่อ  กลาง   นามสกุล ".AsKhun());
    }

    [Fact]
    public void RemoveCommonPrefixNames() {
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
    public void RemoveCommonPrefixNamesWithSpaces() {
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

    [Fact(Skip = "Wait someone to grap and resolve it")]
    public void Kunakorn() {
      Assert.Equal("คุณคุณากร นามสกุล", "คุณากร นามสกุล".AsKhun());
      Assert.Equal("คุณคุณากร นามสกุล", "นายคุณากร นามสกุล".AsKhun());
      Assert.Equal("คุณคุณากร นามสกุล", "คุณคุณากร นามสกุล".AsKhun());
    }

    [Fact]
    public void NotAppendKhunForForeignName() {
      Assert.Equal("Donald Trump", "Donald Trump".AsKhun());
      Assert.NotEqual("คุณDonald Trump", "Donald Trump".AsKhun());

      Assert.Equal("Trump", "Trump".AsKhun());
      Assert.NotEqual("คุณTrump", "Trump".AsKhun());
    }
  }
}
