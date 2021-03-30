using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MojePrzepisy.Database.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public double Amount { get; set; }
        [MaxLength(100)]
        public string AmountDesc { get; set; }


        //Jeden składnik do wielu przepisów
        [ForeignKey("Recepie")]
        public int RecepieId { get; set; }
        //public virtual Recepie Recepie { get; set; }
    }
}
