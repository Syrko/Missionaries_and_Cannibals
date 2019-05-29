using System.Collections.Generic;

namespace DFS_Agent
{
	class ClosedSet
	{
		List<State> closedSetList = new List<State>();

		public bool contains(State stateToCheck)
		{
			bool returnFlag = false;
			foreach(State state in closedSetList)
			{
				if (state.equals(stateToCheck))
				{
					returnFlag = true;
					break;
				}
			}
			return returnFlag;
		}

		public int contains_get_id(State stateToCheck)
		{
			foreach (State state in closedSetList)
			{
				if (state.equals(stateToCheck))
				{
					return state.getID();
				}
			}
			return -1;
			
		}

		public bool isEmpty()
		{
			if (closedSetList.Count > 0)
				return false;
			else
				return true;
		}

		public void add(State stateToAdd)
		{
			closedSetList.Add(stateToAdd);
		}

		public string printClosedSet()
		{
			string returnValue = "{";
			foreach (State state in closedSetList)
			{
				returnValue += state.getID().ToString() + ", ";
			}
			returnValue = returnValue.TrimEnd();
			returnValue = returnValue.TrimEnd(',');
			returnValue += "}";
			return returnValue;
		}
	}
}
