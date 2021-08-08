using InsuranceClaimsApp.ContextData;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace InsuranceClaimsApp.Tests.Helpers
{
    public static class DatabaseHelper
    {
        public static void AddInMemoryDbData(InterviewContext dbContext)
        {
            if (dbContext.Users.Count() == 0)
            {
                var users = new List<User>()
                {
                    new User("gemmela", "gemmela", "Archie", true),
                    new User("bestg", "bestg", "Georgie", false),
                };
                dbContext.AddRange(users);
            }
            if (dbContext.LossTypes.Count() == 0)
            {

                var lossTypes = new List<LossType>()
                {
                    new LossType("A", "description A"),
                    new LossType("B", "description B"),
                };

                dbContext.AddRange(lossTypes);
            }

            dbContext.SaveChanges();
        }

        public static InterviewContext GetInterviewContext()
        {
            var options = new DbContextOptionsBuilder<InterviewContext>()
                .UseInMemoryDatabase("InMemoryDb")
                .Options;
            var databaseContext = new InterviewContext(options);

            databaseContext.Database.EnsureCreated();

            AddInMemoryDbData(databaseContext);

            return databaseContext;
        }
    }
}
