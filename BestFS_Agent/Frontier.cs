using System.Collections.Generic;
using System;

namespace BestFS_Agent
{
	class Frontier
	{
		private SortedList<double, State> FrontierList = new SortedList<double, State>(new DuplicateKeyComparer<double>());

		public void Add(State stateToAdd)
		{
			FrontierList.Add(stateToAdd.getHeuristicValue(), stateToAdd);
		}

		public State Remove()
		{
			State temp = FrontierList.Values[0];
			FrontierList.RemoveAt(0);
			return temp;
		}

		public bool isEmpty()
		{
			if (FrontierList.Count > 0)
				return false;
			else
				return true;
		}

		public string printFrontier()
		{
			string returnValue = "<";
			foreach(KeyValuePair<double,State> state in FrontierList)
			{
				returnValue += state.Value.getID().ToString() + "(" + state.Value.getHeuristicValue() + ")" + ", ";
			}
			returnValue = returnValue.TrimEnd();
			returnValue = returnValue.TrimEnd(',');
			returnValue += ">";
			return returnValue;
		}
	}


	/// <summary>
	/// Comparer for comparing two keys, handling equality as beeing greater
	/// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
	/// Code from https://stackoverflow.com/a/21886340
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
	{
		#region IComparer<TKey> Members

		public int Compare(TKey x, TKey y)
		{
			int result = x.CompareTo(y);

			if (result == 0)
				return 1;   // Handle equality as beeing greater
			else
				return result;
		}

		#endregion
	}
}
