using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojePrzepisy.Database.Entities
{
    public class PreparationStep
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public int StepNumber { get; set; }
        [MaxLength(350)]
        public string Text { get; set; }

        //Jeden krok do wielu przepisów
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public virtual Recepie Recepie { get; set; }
    }
}
