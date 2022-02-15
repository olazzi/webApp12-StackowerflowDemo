using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Collections;


namespace webApp12.Models
{
    public class QuestionAnswer
    {
    
    public HashSet<Answer> answerList22 { get; } = new HashSet<Answer>();
      
      
        public Question questions2 { get; set; }       
        public Answer answers2 { get; set; }

        public IEnumerable<Answer> answersList { get; set;}
        public IEnumerable<Question> questionsList { get; set; }
    }
}