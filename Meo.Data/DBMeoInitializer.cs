using Meo.Model;
using Meo.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Data
{
    public static class DBMeoInitializer
    {
        public static void Initialize(MeoContext context)
        {
            if (!context.Campaigns.Any())
            {
                var campaign = CampaignFactory.Create("This is a Marketing Campaign that we need to know our customer's data", DateTime.Now.AddDays(-2).Date, DateTime.Now.AddDays(15).Date, "Marketing Campaign");
                context.Campaigns.Add(campaign);
                context.SaveChanges();

                var questions = new List<Question>();
                questions.Add(QuestionFactory.Create("In which city were you born?", campaign.Id));
                questions.Add(QuestionFactory.Create("How many kids do you have?", campaign.Id));
                questions.Add(QuestionFactory.Create("What is your favorite color?", campaign.Id));
                questions.Add(QuestionFactory.Create("What's your favorite team?", campaign.Id));
                context.Questions.AddRange(questions);
                context.SaveChanges();
            }
        }
    }
}
