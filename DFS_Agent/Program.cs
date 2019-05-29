using System;

namespace DFS_Agent
{
	class Program
	{
		static void Main(string[] args)
		{
			Log log = new Log();

			State InitialState = new State("initial");
			log.WriteLine("Initial State created...\n");

			State GoalState = new State("goal");
			log.WriteLine("Goal State created...\n\n");


			Frontier frontier = new Frontier();
			ClosedSet closedSet = new ClosedSet();

			State currentState = null;

			frontier.Add(InitialState);
			int step = 1;
			while (!frontier.isEmpty())
			{
				log.Write("Step " + step + ": ");
				step++;

				// Log frontier and closed set
				log.Write(frontier.printFrontier() + " | " + closedSet.printClosedSet() + " | ");

				currentState = frontier.Remove();

				// Log current state
				log.Write(currentState.getID().ToString());

				if (closedSet.contains(currentState))
				{
					// Log '-' for the children list if the closed set contains current state
					log.WriteLine(" | - ");
					continue;
				}
				else if (currentState.equals(GoalState))
				{
					log.Write(" | GOAL STATE");
					log.WriteLine("\nSolution found!");
					break;
				}
				string printChildren = " | ";
				foreach(State expandingState in currentState.expandState(closedSet))
				{
					printChildren += expandingState.getID() + ", ";
					frontier.Add(expandingState);
				}
				log.WriteLine(printChildren.TrimEnd().TrimEnd(','));
				closedSet.add(currentState);
			}

			Console.WriteLine("Program executed successfully. Check log for results...");
			Console.Read();
		}
	}
}
