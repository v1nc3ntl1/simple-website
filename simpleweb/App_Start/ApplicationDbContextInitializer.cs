using simpleweb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace simpleweb.App_Start
{
    public class ApplicationDbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var subjects = new List<string>();
            var random = new Random();

            for (var counter = 0; counter < 10; counter++) {
                subjects.Add("Subject " + random.Next(1, 999999).ToString());
            }

            List<Person> persons = new List<Person>();

            for (var counter = 0; counter < 10; counter++)
            {
                persons.Add(new Person() { Name = $"Person {random.Next(1, 1000) }" });
            }

            foreach (var person in persons)
            {
                person.ExamScores = new List<Score>();
                foreach (var subject in subjects)
                {
                    person.ExamScores.Add(new Score()
                    {
                        ScoreId = random.Next(1, 9999999),
                        Subject = subject,
                        ExamScore = random.Next(1, 100)
                    });
                }
                context.People.Add(person);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }
}