using System.Linq;

namespace GraduationTracker.DataAccess
{
	public class DiplomaRepository : Repository<Diploma>, IDiplomaRepository
	{
		public DiplomaRepository(): base(GetDiplomas())
		{
		}

		private static Diploma[] GetDiplomas()
		{
			return new[]
			{
				new Diploma
				{
					Id = 1,
					Credits = 4,
					Requirements = new int[]{100,102,103,104}
				}
			};
		}
	}
}
