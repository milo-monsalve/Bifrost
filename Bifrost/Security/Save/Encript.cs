﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.Security.Save
{
    public class Encript
    {
        public static string Decode(string text)
        {
            return System.Text.Encoding.Unicode.GetString(System.Convert.FromBase64String(text));
        }

        public static string Encode(string text)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(text));
        }
    }
}
