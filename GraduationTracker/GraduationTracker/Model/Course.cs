using GraduationTracker.Model;

namespace GraduationTracker
{
	public class Course : BaseEntity
	{
		public string Name { get; set; }
		public int Mark { get; set; }
		public int Credits { get; }
	}
}
