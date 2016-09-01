using System;
using System.Collections.Generic;

namespace Mobishop.Infrastructure.Repositories.Neemu.Showcase.Response.Search
{
    public class Lvalore
    {
        public int id { get; set; }
        public string nome { get; set; }
        public object freq { get; set; }
        public List<object> filhos { get; set; }
        public bool selected { get; set; }
        public string linkRemoveFilter { get; set; }
        public bool hasProducts { get; set; }
        public bool hasChildSelected { get; set; }
        public bool hasChildren { get; set; }
        public string linkApplyFilter { get; set; }
        public string link { get; set; }
        public string val { get; set; }
        public string qtde { get; set; }
        public bool? hasBg { get; set; }
        public string hexadecimalColor { get; set; }
    }
}

