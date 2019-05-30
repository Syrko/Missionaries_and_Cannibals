using System.Collections.Generic;

namespace BestFS_Agent
{
	class State
	{
		private static int idCount = 1;
		int id;

		private const string LEFT = "left";
		private const string RIGHT = "right";
		private const int BOAT_CAPACITY = 2;

		private RiverBank riverBankLeft;
		private RiverBank riverBankRight;

		private string boatIs;
		private double HeuristicValue;

		// Constructor for successor states
		public State(int leftCannibals, int leftMissionaries, int rightCannibals, int rightMissionaries, string boatWas)
		{
			id = idCount;
			idCount++;

			riverBankLeft = new RiverBank(leftCannibals, leftMissionaries);
			riverBankRight = new RiverBank(rightCannibals, rightMissionaries);
			if(boatWas == LEFT)
			{
				boatIs = RIGHT;
			}
			else if(boatWas == RIGHT)
			{
				boatIs = LEFT;
			}

			this.HeuristicValue = CalculateHeuristicValue();
		}

		// Constructor for Initial and Goal State
		public State(string type)
		{
			if(type == "initial")
			{
				id = idCount;
				idCount++;

				riverBankLeft = new RiverBank(3, 3);
				riverBankRight = new RiverBank(0, 0);
				boatIs = LEFT;
			}
			else if(type == "goal")
			{
				riverBankLeft = new RiverBank(0, 0);
				riverBankRight = new RiverBank(3, 3);
				boatIs = RIGHT;
			}

			this.HeuristicValue = CalculateHeuristicValue();
		}

		public bool isValidState()
		{
			return riverBankLeft.isValidBank() && riverBankRight.isValidBank();
		}

		public List<State> expandState(ClosedSet closedSet)
		{
			List<State> returnList = new List<State>();
			State tempState;

			if (boatIs == LEFT)
			{
				// First action
				tempState = new State(riverBankLeft.getCannibals() - 2, riverBankLeft.getMissionaries() - 0, riverBankRight.getCannibals() + 2, riverBankRight.getMissionaries() + 0, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Second action
				tempState = new State(riverBankLeft.getCannibals() - 0, riverBankLeft.getMissionaries() - 2, riverBankRight.getCannibals() + 0, riverBankRight.getMissionaries() + 2, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Third action
				tempState = new State(riverBankLeft.getCannibals() - 1, riverBankLeft.getMissionaries() - 1, riverBankRight.getCannibals() + 1, riverBankRight.getMissionaries() + 1, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Fourth action
				tempState = new State(riverBankLeft.getCannibals() - 1, riverBankLeft.getMissionaries() - 0, riverBankRight.getCannibals() + 1, riverBankRight.getMissionaries() + 0, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Fifth action
				tempState = new State(riverBankLeft.getCannibals() - 0, riverBankLeft.getMissionaries() - 1, riverBankRight.getCannibals() + 0, riverBankRight.getMissionaries() + 1, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
			}
			else if (boatIs == RIGHT)
			{
				// First action
				tempState = new State(riverBankLeft.getCannibals() + 2, riverBankLeft.getMissionaries() + 0, riverBankRight.getCannibals() - 2, riverBankRight.getMissionaries() - 0, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Second action
				tempState = new State(riverBankLeft.getCannibals() + 0, riverBankLeft.getMissionaries() + 2, riverBankRight.getCannibals() - 0, riverBankRight.getMissionaries() - 2, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Third action
				tempState = new State(riverBankLeft.getCannibals() + 1, riverBankLeft.getMissionaries() + 1, riverBankRight.getCannibals() - 1, riverBankRight.getMissionaries() - 1, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Fourth action
				tempState = new State(riverBankLeft.getCannibals() + 1, riverBankLeft.getMissionaries() + 0, riverBankRight.getCannibals() - 1, riverBankRight.getMissionaries() - 0, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
				// Fifth action
				tempState = new State(riverBankLeft.getCannibals() + 0, riverBankLeft.getMissionaries() + 1, riverBankRight.getCannibals() - 0, riverBankRight.getMissionaries() - 1, boatIs);
				if (tempState.isValidState())
				{
					if (closedSet.contains_get_id(tempState) != -1)
					{
						tempState.id = closedSet.contains_get_id(tempState);
						State.idCount--;
					}
					else
						returnList.Add(tempState);
				}
				else
				{
					State.idCount--;
				}
			}

			return returnList;
		}

		public bool equals(State otherState)
		{
			return this.getRiverBankLeft().equals(otherState.getRiverBankLeft()) && this.getRiverBankRight().equals(otherState.getRiverBankRight()) && this.boatIs == otherState.boatIs;
		}

		public string printState()
		{
			string returnValue = getRiverBankLeft().getMissionaries() + "x Missionaries, " + getRiverBankLeft().getCannibals() + "x Cannibals";
			if (boatIs == LEFT)
			{
				returnValue += "||[boat]>		||";
			}
			else
			{
				returnValue += "||		 <[boat]||";
			}
			returnValue += getRiverBankRight().getMissionaries() + "x Missionaries, " + getRiverBankRight().getCannibals() + "x Cannibals";

			return returnValue + " -- State ID: " + id;
		}

		private double CalculateHeuristicValue()
		{
			return (riverBankLeft.getCannibals() + riverBankLeft.getMissionaries()) / BOAT_CAPACITY;
		}

		public RiverBank getRiverBankLeft() { return riverBankLeft; }
		public RiverBank getRiverBankRight() { return riverBankRight; }
		public int getID() { return id; }
		public double getHeuristicValue() { return HeuristicValue; }
	}
}
