﻿using System;

namespace GreatFriends.Khun {
  public static class KhunExtension {

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


    public static string AsKhun(this string name) {

      if (name == null) return string.Empty;

      name = name.Trim();

      if (name.Length == 0) return string.Empty;

      string[] parts = name.Split(new char[] { ' ' },
        StringSplitOptions.RemoveEmptyEntries);

      if (parts[0].StartsWith("คุณ")) {
        return string.Join(" ", parts);
      }

      for (int i = 0; i < prefixes.Length; i++) {
        if (parts[0].StartsWith(prefixes[i])) {
          int len = prefixes[i].Length;
          parts[0] = parts[0].Substring(len, parts[0].Length - len);
          break;
        }
      }

      return "คุณ" + string.Join(" ", parts).TrimStart();
    }
  }

}
