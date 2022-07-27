using GraduationTracker.DataAccess;
using GraduationTracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker
{
	public partial class GraduationTracker: IGraduationTracker
	{
		private IRequirementsRepository requirementsRepository;

		public GraduationTracker(IRequirementsRepository requirementsRepository)
		{
			this.requirementsRepository = requirementsRepository;
		}
		public int CalculateCredit(IEnumerable<int> marks, Diploma diploma)
		{
			var requirementsCourses = diploma.Requirements.Select(x => requirementsRepository.GetByID(x));

			return requirementsCourses.Where(c => marks.Any(k => k > c.MinimumMark)).Sum(k => k.Credits);

		}

		public int CalculateAverage(IEnumerable<int> marks, int studentCoursesLength)
		{
			return marks.Sum() / studentCoursesLength;
		}

		public IEnumerable<int> FindMarks(Diploma diploma, Student student)
		{
			var requirementsCourses = diploma.Requirements.SelectMany(x => requirementsRepository.GetByID(x).Courses);

			return student.Courses.Where(s => requirementsCourses.Contains(s.Id)).Select(k => k.Mark);
		}

		public STANDING DefineStanding(int average) => average switch
		{
			< 50 => STANDING.Remedial,
			< 80 => STANDING.Average,
			_ => STANDING.MagnaCumLaude
		};

		public bool IsStanding(STANDING standing) =>
			standing is STANDING.Average ||
			standing is STANDING.SumaCumLaude ||
			standing is STANDING.MagnaCumLaude;


	}
}
