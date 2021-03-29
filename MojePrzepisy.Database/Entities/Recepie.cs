using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace MojePrzepisy.Database.Entities
{
    public class Recepie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(400)]
        public string Description { get; set; }
        [MaxLength(350)]
        public string ImageUrl { get; set; }
        [MaxLength(20)]
        public int PreparationTime { get; set; }
        [MaxLength(20)]
        public int CookingTime { get; set; }
        [MaxLength(20)]
        public int People { get; set; }
        [MaxLength(50)]
        public string Difficulty { get; set; }
        [MaxLength(50)]
        public string Category { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [NotMapped]
        public virtual List<Ingredient> Ingredientses { get; set; }
        [NotMapped]
        public virtual List<PreparationStep> PreparationStepses { get; set; }

        //Wiele przepisow do jednego usera 
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // one Recipe
        // to many Ingredients
        //public ICollection<Ingredients> Ingredients { get; set; }
        // one Recipe
        // to many PreparationStep
        // public ICollection<PreparationSteps> PreparationSteps { get; set; }
    }
}
