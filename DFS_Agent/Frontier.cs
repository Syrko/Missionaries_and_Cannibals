using System;
using System.Collections.Generic;
using System.Text;

namespace DFS_Agent
{
	class Frontier
	{
		private Queue<State> FrontierQueue = new Queue<State>();

		public void Add(State stateToAdd)
		{
			FrontierQueue.Enqueue(stateToAdd);
		}

		public State Remove()
		{
			return FrontierQueue.Dequeue();
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
