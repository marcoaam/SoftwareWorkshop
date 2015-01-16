using System;
using System.Collections.Generic;

namespace ProductionCode.Day3
{
    public class GolfCourse
    {
        private int _numberOfGroups;
        private List<GroupOfPlayers> _groupOfPlayers; 
        private readonly Dictionary<int, List<int>> _possibleJoinCombinations;
        private readonly Dictionary<int, List<int>> _possibleSplittingCombinations;

        public int NumberOfGroups { get { return _groupOfPlayers.Count; } }
        public List<GroupOfPlayers> GroupsOfPlayers { get { return _groupOfPlayers; } }

        public GolfCourse()
        {
            _possibleJoinCombinations = CreatePossibleJoinCombinations();
            _possibleSplittingCombinations = CreatePossibleSplittingCombinations();
            _groupOfPlayers = new List<GroupOfPlayers>();
        }

        public void Organise(List<GroupOfPlayers> groupOfPlayers)
        {
            var amountOfGroupsToProcess = groupOfPlayers.Count;

            for (var i = 0; i < amountOfGroupsToProcess; i++)
            {
                var nextIndex = i + 1;
                var currentGroupOfPlayers = groupOfPlayers[i];

                if (currentGroupOfPlayers.NumberOfPLayers > 4)
                {
                    RegisterGroupsOfPlayers(GetGroupSplitingRules(currentGroupOfPlayers));
                    continue;
                }

                if ((nextIndex < amountOfGroupsToProcess) && IsPossibleToJoinWithNextGroup(groupOfPlayers, i))
                {
                    var groupNumberOfPlayersJoined = new List<int> { JoinNumberOfPlayers(groupOfPlayers, i) } ;
                    RegisterGroupsOfPlayers(groupNumberOfPlayersJoined);
                    i++;
                    continue;
                }

                var group = new List<int> { currentGroupOfPlayers.NumberOfPLayers };
                RegisterGroupsOfPlayers(group);
            }
        }

        private List<int> GetGroupSplitingRules(GroupOfPlayers groupOfPlayers)
        {
            return _possibleSplittingCombinations[groupOfPlayers.NumberOfPLayers];
        }

        private int JoinNumberOfPlayers(List<GroupOfPlayers> groupOfPlayers, int i)
        {
            var nextIndex = i + 1;
            return groupOfPlayers[i].NumberOfPLayers + groupOfPlayers[nextIndex].NumberOfPLayers;
        }

        private bool IsPossibleToJoinWithNextGroup(List<GroupOfPlayers> groupOfPlayers, int i)
        {
            var nextIndex = i + 1;
            return _possibleJoinCombinations[groupOfPlayers[i].NumberOfPLayers].Contains(groupOfPlayers[nextIndex].NumberOfPLayers);
        }

        private void RegisterGroupsOfPlayers(IEnumerable<int> groupSizes)
        {
            foreach (var groupSize in groupSizes)
            {
                _groupOfPlayers.Add(new GroupOfPlayers(groupSize));                
            }
        }

        private Dictionary<int, List<int>> CreatePossibleJoinCombinations()
        {
            var possibleJoinCombinations = new Dictionary<int, List<int>>();
            possibleJoinCombinations.Add(1, new List<int> { 1, 2, 3 });
            possibleJoinCombinations.Add(2, new List<int> { 2, 1 });
            possibleJoinCombinations.Add(3, new List<int> { 1 });
            possibleJoinCombinations.Add(4, new List<int>());
            return possibleJoinCombinations;
        }

        private Dictionary<int, List<int>> CreatePossibleSplittingCombinations()
        {
            var possibleSplittingCombinations = new Dictionary<int, List<int>>();
            possibleSplittingCombinations.Add(5, new List<int> { 4, 1 });
            possibleSplittingCombinations.Add(6, new List<int> { 4, 2 });
            return possibleSplittingCombinations;
        }
    }
}