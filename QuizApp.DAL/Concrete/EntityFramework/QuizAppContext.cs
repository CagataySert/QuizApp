using QuizzApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.DAL.Concrete.EntityFramework
{
    public class QuizAppContext: DbContext
    {
        public QuizAppContext():base("name=QuizAppConnectionString")
        {
            Database.SetInitializer<QuizAppContext>(new QuizAppInitializer<QuizAppContext>());            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        private class QuizAppInitializer<T> : DropCreateDatabaseIfModelChanges<QuizAppContext>
        {
            protected override void Seed(QuizAppContext context)
            {
                List<Answer> answers = new List<Answer>();
                answers.Add(new Answer() { Id = 1, Name = "Deenem Cevap 1", QuestionId = 1 });
                answers.Add(new Answer() { Id = 2, Name = "Deneme Cevap 2", QuestionId = 1 });
                answers.Add(new Answer() { Id = 3, Name = "Deneme Cevap 3", QuestionId = 1 });
                answers.Add(new Answer() { Id = 4, Name = "Deneme Cevap 4", QuestionId = 1 });
                answers.Add(new Answer() { Id = 5, Name = "Deneme Cevap 5", QuestionId = 2 });            
                answers.Add(new Answer() { Id = 6, Name = "Deneme Cevap 6", QuestionId = 2 });
                answers.Add(new Answer() { Id = 7, Name = "Deneme Cevap 7", QuestionId = 2 });
                answers.Add(new Answer() { Id = 8, Name = "Deneme Cevap 8", QuestionId = 2 });
                answers.Add(new Answer() { Id = 9, Name = "Deneme Cevap 9", QuestionId = 3 });
                answers.Add(new Answer() { Id = 10, Name = "Deneme Cevap 10", QuestionId = 3 });
                answers.Add(new Answer() { Id = 11, Name = "Deneme Cevap 11", QuestionId = 3 });
                answers.Add(new Answer() { Id = 12, Name = "Deneme Cevap 11", QuestionId = 3 });

                foreach (Answer answer in answers)
                {
                    context.Answers.Add(answer);
                }

                List<Question> questions = new List<Question>();
                questions.Add(new Question() { Id = 1, Name = "Deneme Soru 1", CategoryId = 1 });
                questions.Add(new Question() { Id = 2, Name = "Deneme Soru 2", CategoryId = 2 });
                questions.Add(new Question() { Id = 3, Name = "Deneme Soru 3", CategoryId = 2 });

                foreach (Question question in questions)
                {
                    context.Questions.Add(question);
                }

                List<Category> categories = new List<Category>();
                categories.Add((new Category() { Id = 1, Name = "Kategori 1", Level = "Hard" }));
                categories.Add((new Category() { Id = 2, Name = "Kategori 2", Level = "Medium" }));

                foreach (Category category in categories)
                {
                    context.Categories.Add(category);
                }

                context.SaveChanges();
                base.Seed(context);
            }
        }
    }
}
