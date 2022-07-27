using GraduationTracker.Model;

namespace GraduationTracker
{
	public class Requirement : BaseEntity
	{
		public string Name { get; set; }
		public int MinimumMark { get; set; }
		public int Credits { get; set; }
		public int[] Courses { get; set; }
	}
}
