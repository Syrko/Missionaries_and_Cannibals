using System;

namespace HillClimbing_Agent
{
	class Program
	{
		static void Main(string[] args)
		{
			// For the heuristic function I loosen the problem by disregarding
			// the "!cannibals > missionaries" rule and assuming the boat can return on its own
			//
			// Heuristic Function:
			// h(n) = (#MissionariesLeft + #CannibalsLeft) / BoatCapacity
			// which equals the optimal number of trips left to right needed to solve the relaxed problem

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

				currentState = frontier.RemoveStateWithLowestHeuristcValue();

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
				foreach (State expandingState in currentState.expandState(closedSet))
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
