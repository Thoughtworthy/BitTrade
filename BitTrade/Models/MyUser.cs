using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace TradePlatform.Models
{
    public class MyUser
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }
        public List<string> Names { get; set; }

    }
}