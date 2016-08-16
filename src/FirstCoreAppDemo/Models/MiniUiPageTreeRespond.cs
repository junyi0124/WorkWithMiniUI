using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreAppDemo.Models
{
    public class MiniUiPageTreeRespond<T>
    {
        public int total { get; set; }
        public List<string> allIds { get; set; }
        public List<T> data { get; set; }
    }
}
