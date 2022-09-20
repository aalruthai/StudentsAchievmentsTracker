using Volo.Abp.Domain.Entities;

namespace StudentsAchievmentsTracker.Entities
{
    public class Achievment : BasicAggregateRoot<int>
    {
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
