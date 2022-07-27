using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using GraduationTracker.DataAccess;
using GraduationTracker.Services;

namespace GraduationTracker.Tests.Unit
{
	[TestClass]
	public class GraduationTrackerTests
	{
		private readonly Mock<IRequirementsRepository> requirementsRepository;
		Diploma diploma = new Diploma
		{
			Id = 1,
			Credits = 4,
			Requirements = new int[] { 100, 102, 103, 104 }
		};
		public GraduationTrackerTests()
		{
			requirementsRepository = new Mock<IRequirementsRepository>(MockBehavior.Strict);

			requirementsRepository.Setup(x => x.GetByID(diploma.Requirements[0]))
				.Returns(new Requirement { Id = 100, Name = "Math", MinimumMark = 50, Courses = new int[] { 1 }, Credits = 1 });

			requirementsRepository.Setup(x => x.GetByID(diploma.Requirements[1]))
				.Returns(new Requirement { Id = 102, Name = "Science", MinimumMark = 50, Courses = new int[] { 2 }, Credits = 1 });

			requirementsRepository.Setup(x => x.GetByID(diploma.Requirements[2]))
				.Returns(new Requirement { Id = 103, Name = "Literature", MinimumMark = 50, Courses = new int[] { 3 }, Credits = 1 });

			requirementsRepository.Setup(x => x.GetByID(diploma.Requirements[3]))
				.Returns(new Requirement { Id = 104, Name = "Literature", MinimumMark = 50, Courses = new int[] { 4 }, Credits = 1 });

		}

		[TestMethod]
		public void Test_IsStanding_Must_Return_True()
		{
			// Arrange
			var average = STANDING.Average;
			var SumaCumLaude = STANDING.SumaCumLaude;
			var magnaCumLaude = STANDING.MagnaCumLaude;

			// Act
			var tracker = new GraduationTracker(requirementsRepository.Object);

			// Assert

			Assert.IsTrue(tracker.IsStanding(average));
			Assert.IsTrue(tracker.IsStanding(SumaCumLaude));
			Assert.IsTrue(tracker.IsStanding(magnaCumLaude));
		}

		[TestMethod]
		public void Test_IsStanding_Must_Return_False()
		{
			// Arrange
			var none = STANDING.None;

			// Act
			var tracker = new GraduationTracker(requirementsRepository.Object);

			// Assert

			Assert.IsFalse(tracker.IsStanding(none));
		}

		[TestMethod]

		public void Test_FindMarks_Success()
		{
			// Arrange

			var student = new Student
			{
				Id = 1,
				Courses = new Course[]
				{
					new Course{Id = 1, Name = "Math", Mark=95 },
					new Course{Id = 2, Name = "Science", Mark=195 },
					new Course{Id = 3, Name = "Literature", Mark=295 },
					new Course{Id = 4, Name = "Physichal Education", Mark=395 }
				}
			};


			var tracker = new GraduationTracker(requirementsRepository.Object);


			// Act
			var result = tracker.FindMarks(diploma, student).ToArray();

			// Assert
			Assert.AreEqual(student.Courses[0].Mark, result[0]);
			Assert.AreEqual(student.Courses[1].Mark, result[1]);
			Assert.AreEqual(student.Courses[2].Mark, result[2]);
			Assert.AreEqual(student.Courses[3].Mark, result[3]);
		}

		[TestMethod]
		public void TestCalculateAverage_Success()
		{
			// Arrange
			var marks = new List<int>() { 100, 200, 300, 400 };

			var tracker = new GraduationTracker(requirementsRepository.Object);

			// Act
			var result = tracker.CalculateAverage(marks, 4);

			// Assert
			Assert.AreEqual(result, 250);
		}

		[TestMethod]
		public void TestCalculateCredit_Success()
		{
			// Arrange

			var marks = new List<int>() { 95, 95, 95, 95 };
			var tracker = new GraduationTracker(requirementsRepository.Object);

			// Act
			var result = tracker.CalculateCredit(marks, diploma);

			// Assert
			Assert.AreEqual(result, 4);

		}
	}
}
