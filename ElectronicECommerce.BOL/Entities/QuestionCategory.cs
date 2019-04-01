using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("QuestionCategory")]
    public class QuestionCategory
    {
        public int ID { get; set; }

        [StringLength(50), Column(TypeName = "varchar")]
        public string Name { get; set; }

        public virtual ICollection<QuestionAnswer> QuestionsAnswers { get; set; }
    }
}