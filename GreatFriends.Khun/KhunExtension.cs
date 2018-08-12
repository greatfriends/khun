using System;

namespace GreatFriends.Khun
{
  public static class KhunExtension
  {

    private const string Khun = "คุณ";
    private static string[] prefixes = new string[] {
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


    public static string AsKhun(this string name)
    {
      string khunToPrepend = Khun;
      string firstName;

      if (name == null) return string.Empty;

      name = name.Trim();

      if (name.Length == 0) return string.Empty;

      string[] parts = name.Split(new char[] { ' ' },
        StringSplitOptions.RemoveEmptyEntries);

      if (parts[0] == Khun)
      {
        parts[0] = string.Empty;
        firstName = parts.Length > 1 ? parts[1] : null;
      }
      else
      {
        if (parts[0].StartsWith(Khun))
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
