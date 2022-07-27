using GraduationTracker.Model;

namespace GraduationTracker
{
	public class Diploma : BaseEntity
	{
		public int Credits { get; set; }
		public int[] Requirements { get; set; }
	}
}
