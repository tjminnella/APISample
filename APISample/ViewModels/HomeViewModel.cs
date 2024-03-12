using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APISample.Models;

namespace APISample.ViewModels
{
    public class HomeViewModel
    {
        public User user { get; set; }
    }
}
