using System.Collections.Generic;

namespace HillClimbing_Agent
{
	class Frontier
	{
		private List<State> FrontierQueue = new List<State>();

		public void Add(State stateToAdd)
		{
			FrontierQueue.Add(stateToAdd);
		}

		public State RemoveStateWithLowestHeuristcValue()
		{
			State returnState = null;
			double minHeuristicValue = 10;
			foreach(State state in FrontierQueue)
			{
				if(state.getHeuristicValue() < minHeuristicValue)
				{
					minHeuristicValue = state.getHeuristicValue();
					returnState = state;
					break;
				}
			}
			FrontierQueue.Remove(returnState);
			return returnState;
		}

		public bool isEmpty()
		{
			if (FrontierQueue.Count > 0)
				return false;
			else
				return true;
		}

		public string printFrontier()
		{
			string returnValue = "<";
			foreach(State state in FrontierQueue)
			{
				returnValue += state.getID().ToString() + ", ";
			}
			returnValue = returnValue.TrimEnd();
			returnValue = returnValue.TrimEnd(',');
			returnValue += ">";
			return returnValue;
		}
	}
}
