﻿using System;

namespace AuthorProblem
{
    [Author("Krisko")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
