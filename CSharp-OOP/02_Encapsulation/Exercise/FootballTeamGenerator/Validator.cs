﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string str, string exceptionMesage)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(exceptionMesage);
            }
        }

        public static void ThrowIfNumberIsNotInRange(int number, int min, int max, string exceptionMessage)
        {

            if (number < min || number > max)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }
    }
}
