using System.Collections.Generic;

namespace GraduationTracker.Services
{
	public interface IGraduationTracker
	{
		public int CalculateCredit(IEnumerable<int> marks, Diploma diploma);

		public int CalculateAverage(IEnumerable<int> marks, int studentCoursesLength);

		public IEnumerable<int> FindMarks(Diploma diploma, Student student);

		public STANDING DefineStanding(int average);

		public bool IsStanding(STANDING standing);

	}
}
