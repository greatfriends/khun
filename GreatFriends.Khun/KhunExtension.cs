using System;

namespace GreatFriends.Khun
{
  public static class KhunExtension
  {

    private const string KHUN = "คุณ";

    private static readonly string[] prefixes = {
        "นาย",
        "นางสาว",
        "นาง",
        "เด็กชาย",
        "เด็กหญิง",
        "อาจารย์",
        "น.ส.",
        "ด.ช.",
        "ด.ญ.",
        "อ."
      };

    private static readonly char[] vowels = {
      'ะ', 'า', 'ิ', 'ี', 'ึ', 'ื', 'ุ', 'ู',
      'ั'
    };

    private static readonly string[] FirstNameThatStartsWithKhuns =
    {
      "คุณชนะอนันต์",
      "คุณณพงศ์",
      "คุณดวง",
      "คุณนิธี",
      "คุณน้อง",
      "คุณปลื้ม",
      "คุณภัทร",
      "คุณภาพ",
      "คุณยาวุฒิ",
      "คุณวุฒิ",
      "คุณศรี",
      "คุณสมบัติ",
    };

    public static string AsKhun(this string name)
    {
      string khunToPrepend = KHUN;
      string firstName;

      if (name == null) return string.Empty;

      name = name.Trim();

      if (name.Length == 0) return string.Empty;

      string[] parts = name.Split(new char[] { ' ' },
        StringSplitOptions.RemoveEmptyEntries);

      if (parts[0] == KHUN)
      {
        parts[0] = string.Empty;
        firstName = parts.Length > 1 ? parts[1] : null;
      }
      else
      {
        if (NameStartsWithKhunButActuallyName(parts[0]))
        {
          return khunToPrepend + string.Join(" ", parts).TrimStart();
        }

        if (parts[0].StartsWith(KHUN))
        {
          return string.Join(" ", parts);
        }


        firstName = parts[0];
        for (int i = 0; i < prefixes.Length; i++)
        {
          if (parts[0].StartsWith(prefixes[i]))
          {
            int len = prefixes[i].Length;

            firstName = parts[0].Substring(len, parts[0].Length - len);

            parts[0] = firstName;
            break;
          }
        }
      }

      if (ContainsNonThaiCharacters(firstName))
      {
        khunToPrepend = string.Empty;
      }

      return khunToPrepend + string.Join(" ", parts).TrimStart();
    }

    private static bool NameStartsWithKhunButActuallyName(string text)
    {
      if (Array.IndexOf(FirstNameThatStartsWithKhuns, text) >= 0) return true;

      if (!text.StartsWith(KHUN)) return false;
      if (text.Length <= 3) return false;
      if (Array.IndexOf(vowels, text[3]) < 0) return false;

      return true;
    }

    private static bool ContainsNonThaiCharacters(string text)
    {
      foreach (var ch in text)
      {
        if (!(0x0e00 <= (uint)ch && (uint)ch <= 0x0e7f))
        {
          return true;
        }
      }
      return false;
    }
  }

}
