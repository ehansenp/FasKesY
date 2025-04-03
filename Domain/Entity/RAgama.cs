using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class RAgama
    {
        [Key]
        public int Kode {get;set;}
        public required string Uraian {get;set;} = "";
        public int Deleted {get;set;} = 0;
    }
}