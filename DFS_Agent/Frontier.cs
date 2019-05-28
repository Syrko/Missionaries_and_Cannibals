using System.Collections.Generic;

namespace DFS_Agent
{
	class Frontier
	{
		private Stack<State> FrontierQueue = new Stack<State>();

		public void Add(State stateToAdd)
		{
			FrontierQueue.Push(stateToAdd);
		}

		public State Remove()
		{
			return FrontierQueue.Pop();
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
