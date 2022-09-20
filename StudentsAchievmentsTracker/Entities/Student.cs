using Volo.Abp.Domain.Entities;
namespace StudentsAchievmentsTracker.Entities
{
    public class Student : BasicAggregateRoot<int>
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public ICollection<Achievment> Achievments { get; set; }
    }
}
