using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreAppDemo.Models
{
    public enum Unit
    {
        [Display(Name ="吨")]
        Ton,
        [Display(Name ="万吨")]
        TenThousandTon
    }
}
