using System.Collections.Generic;

namespace DFS_Agent
{
	class Frontier
	{
		private Stack<State> FrontierStack = new Stack<State>();

		public void Add(State stateToAdd)
		{
			FrontierStack.Push(stateToAdd);
		}

		public State Remove()
		{
			return FrontierStack.Pop();
		}

		public bool isEmpty()
		{
			if (FrontierStack.Count > 0)
				return false;
			else
				return true;
		}

		public string printFrontier()
		{
			string returnValue = "<";
			foreach(State state in FrontierStack)
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
