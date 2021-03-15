﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class Book: IComparable<Book>
    {
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }


        public Book(string title,int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);

        }

        public int CompareTo(Book other)
        {
            if (Year!=other.Year)
            {
                return Year - other.Year;
            }
            return Title.CompareTo(other.Title);
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
