using GraduationTracker.Model;

namespace GraduationTracker
{
	public class Student : BaseEntity
	{
		public Course[] Courses { get; set; }
		public STANDING Standing { get; set; } = STANDING.None;
	}
}
