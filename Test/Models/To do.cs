using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class To_do
    {
        public int To_doID { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
    }
}