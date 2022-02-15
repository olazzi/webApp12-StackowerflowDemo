using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webApp12.Models;

namespace webApp12.Controllers
{
    public class QuestionsController : Controller
    {
        
        private webappEntities2 db1 =new webappEntities2();

        // GET: Questions
        QuestionAnswer qa1 = new QuestionAnswer();
        public ActionResult Index()
        {

            
            qa1.questionsList = db1.Questions.ToList();
            return View(qa1);

            //List<Question> questionList = db1.Questions.ToList();
            //List<Answer> answers = db1.Answers.ToList();
            //var multipletable = from que in questionList                               
            //                    select new QuestionAnswer { questions2 = que };


            //return View(multipletable);

            //return View(db.Questions.ToList());
        }
        QuestionAnswer qa2 = new QuestionAnswer();
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string searchString)
        {
            List<Question> questionList = db1.Questions.ToList();
            
            var questions = from Question que in questionList
      
                                select new QuestionAnswer { questions2 = que };
            qa2.questionsList = db1.Questions.Where(a => a.Question1.Contains(searchString));

            if (!String.IsNullOrEmpty(searchString))
            {
                questions = questions.Where(s => s.questions2.Question1.Contains(searchString));
            }

            return View(qa2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        //public ActionResult Details()
        //{
        //    List<Question> questionList = db1.Questions.ToList();
        //    List<Answer> answers = db1.Answers.ToList();
        //    var multipletable = from que in questionList
        //                        join ans1 in answers on que.Id equals ans1.QuestionID
        //                        select new QuestionAnswer { answers2 = ans1, questions2 = que };
        //    return View(multipletable);
        //}

        public ActionResult Details(int? id)
        {
            Question question = db1.Questions.Find(id);

            List<Question> questionList = db1.Questions.ToList();
            List<Answer> answers = db1.Answers.ToList();
            var multipletable = from Question que in questionList where que.Id == id
                                from Answer ans1 in answers 
                                 where ans1.QuestionID == id
                                select new QuestionAnswer { answers2 = ans1};
            return View(multipletable);

        }
      

      





        // GET: Questions/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question1,Id")] Question question)
        {
            if (ModelState.IsValid)
            {
                db1.Questions.Add(question);
                db1.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
       
        // GET: Questions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db1.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Question1,Id")] Question question)
        {
            if (ModelState.IsValid)
            {
                db1.Entry(question).State = EntityState.Modified;
                db1.SaveChanges();
                TempData["SuccessMessage"] = "New Record Editted Succesfully";
                return RedirectToAction("Index");
            }
            return View(question);
        }
        QuestionAnswer qa = new QuestionAnswer();
        // GET: Questions/Delete/5
        public ActionResult Delete(int? id)
        {
            Question question = db1.Questions.Find(id);
            qa.answersList = db1.Answers.Where(a => a.QuestionID == id).ToList();
            return View(qa);

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(QuestionAnswer model, int? id)
        {
            webappEntities2 db1 = new webappEntities2();
            
            QuestionAnswer question1 = new QuestionAnswer();
            question1.questions2 = db1.Questions.Find(id);

            Answer answer = new Answer();
            Question question = new Question();
            //answer.Answer_id= 7;
            
            string answers1 = model.answers2.Answers;
            answer.Answers = answers1;
           
            answer.QuestionID =id;
            db1.Answers.Add(answer);
            db1.SaveChanges();

            List<Answer> answers = db1.Answers.ToList();
            var query = db1.Answers.Where(a => a.QuestionID == id).ToList();
            int count = query.Count();
            ViewBag.Counts = count;
            


            qa.answersList = db1.Answers.Where(a => a.QuestionID == id).ToList();
            return View(qa);
        }

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirm(int? id)
        //{
        //    Question question = db1.Questions.Find(id);

        //    List<Question> questionList = db1.Questions.ToList();
        //    List<Answer> answers = db1.Answers.ToList();
        //    var multipletable = from Question que in questionList
        //                        where que.Id == id
        //                        from Answer ans1 in answers
        //                        where ans1.QuestionID == id
        //                        select new QuestionAnswer { answers2 = ans1 };
        //    return View(multipletable);
        //}
        // POST: Questions/Delete/5
        
        public ActionResult DeleteConfirmedx(Answer model)
        {

            webappEntities2 db2 = new webappEntities2();
        //Answer answers = db1.Answers.Find(id);
        //db1.Answers.Remove(answers);
        // db1.SaveChanges();
        //TempData["SuccessMessage"] = "New Record Deleted Succesfully";
        // return RedirectToAction("Index");
        List<Question> list = db2.Questions.ToList();
            ViewBag.Answers = new SelectList(list, "Answer_id,Answers");
            Question que = new Question();






            //que.Id = model.Id;
            //que.Question1 = model.Question1;
            //que.Id = model.Id;
            // db.Questions.Add(que);
            //db2.SaveChanges();

            //int latestId = que.Id;
            // Answer answer = new Answer();
            //answer.SiteName = model.SiteName2;  

            //db2.Answers.Add(answer);
            //db2.SaveChanges();



           // Answer answer = new Answer();
           // answer.Answers = model.Answers;
           ////answer.Answer_id = model.Answer_id;
           //answer.QuestionID=model.QuestionID;
            
           // db2.Answers.Add(answer);
           // db2.SaveChanges();

           // int latestansId = answer.QuestionID;

           // Question question = new Question();
           // question.Question1 = model.SiteName;
           // question.Id = latestansId;
           // db2.Questions.Add(question);
           // db2.SaveChanges();



            
            return View(model);
       }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db1.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
