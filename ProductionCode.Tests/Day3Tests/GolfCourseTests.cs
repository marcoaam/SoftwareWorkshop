using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProductionCode.Day3;

namespace ProductionCode.Tests.Day3Tests
{
    [TestFixture]
    public class GolfCourseTests
    {
        [TestCase(new[] { 2, 2, 2 }, 2)]
        [TestCase(new[] { 2, 1, 2, 2 }, 2)]
        [TestCase(new[] { 1, 1, 2, 2 }, 2)]
        [TestCase(new[] { 3, 1 }, 1)]
        [TestCase(new[] { 4, 3, 1, 2, 2, 3, 1, 2 }, 5)]
        public void ShouldOrganiseConsecutiveGroupsofPeopleCloserToGroupsOf4(int[] groupNumbers, int expectedAmountOfGroups)
        {
            var golfCourse = new GolfCourse();
            var groups = CreateGroups(groupNumbers);

            golfCourse.Organise(groups);

            Assert.That(golfCourse.NumberOfGroups, Is.EqualTo(expectedAmountOfGroups));
        }

        [TestCase(new[] { 5, 4, 3 }, 4)]
        [TestCase(new[] { 6, 5, 3 }, 5)]
        public void ShouldSplitGroupsofPlayersGreaterThan4(int[] groupNumbers, int expectedAmountOfGroups)
        {
            var golfCourse = new GolfCourse();
            var groups = CreateGroups(groupNumbers);

            golfCourse.Organise(groups);

            Assert.That(golfCourse.NumberOfGroups, Is.EqualTo(expectedAmountOfGroups));
        }

        [TestCase(new[] { 5, 4, 3 }, new[] { 4, 1, 4, 3 })]
        [TestCase(new[] { 6, 4, 3 }, new[] { 4, 2, 4, 3 })]
        public void ChecksThatGroupsHaveBeenSplittedCorrectly(int[] groupNumbers, int[] expectedNumberOfPlayersInGroups)
        {
            var golfCourse = new GolfCourse();
            var groups = CreateGroups(groupNumbers);

            golfCourse.Organise(groups);

            for (int i = 0; i < expectedNumberOfPlayersInGroups.Length; i++)
            {
                Assert.That(golfCourse.GroupsOfPlayers[i].NumberOfPLayers, Is.EqualTo(expectedNumberOfPlayersInGroups[i]));
            }
           
        }

        private static List<GroupOfPlayers> CreateGroups(IEnumerable<int> groupsSizes)
        {
            var groupOfPlayersList = groupsSizes.Select(groupSize => new GroupOfPlayers(groupSize)).ToList();
            return groupOfPlayersList;
        }
    }
}
