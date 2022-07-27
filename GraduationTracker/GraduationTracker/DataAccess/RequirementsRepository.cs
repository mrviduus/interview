namespace GraduationTracker.DataAccess
{
	public class RequirementsRepository : Repository<Requirement>, IRequirementsRepository
	{
		public RequirementsRepository() : base(GetRequirements())
		{
		}
		public static Requirement[] GetRequirements()
		{
			return new[]
			{
					new Requirement{Id = 100, Name = "Math", MinimumMark=50, Courses = new int[]{1}, Credits=1 },
					new Requirement{Id = 102, Name = "Science", MinimumMark=50, Courses = new int[]{2}, Credits=1 },
					new Requirement{Id = 103, Name = "Literature", MinimumMark=50, Courses = new int[]{3}, Credits=1},
					new Requirement{Id = 104, Name = "Physichal Education", MinimumMark=50, Courses = new int[]{4}, Credits=1 }
				};
		}
	}
}
