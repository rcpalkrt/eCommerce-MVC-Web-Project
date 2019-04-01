using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicECommerce.BOL.Entities
{
    [Table("QuestionAnswer")]
    public class QuestionAnswer
    {
        public int ID { get; set; }

        [Column(TypeName = "text")]
        public string Question { get; set; }

        [Column(TypeName = "text")]
        public string Answer { get; set; }

        public int QuestionCategoryID { get; set; }
        public virtual QuestionCategory QuestionCategory { get; set; }
    }
}
