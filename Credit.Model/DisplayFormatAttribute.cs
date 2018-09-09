using System;

namespace Credit.Model
{
    internal class DisplayFormatAttribute : Attribute
    {
        public string DataFormatString { get; set; }
    }
}