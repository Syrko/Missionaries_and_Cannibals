using System;
using System.Collections.Generic;
using System.Text;

namespace DFS_Agent
{
	class RiverBank
	{
		private int cannibals;
		private int missionaries;

		public RiverBank(int cannibals, int missionaries)
		{
			this.cannibals = cannibals;
			this.missionaries = missionaries;
		}

		public bool isValidBank()
		{
			return (cannibals <= missionaries || missionaries == 0) && (cannibals >= 0) && (missionaries >= 0);
		}

		public bool equals(RiverBank otherRiverBank)
		{
			return (this.getCannibals() == otherRiverBank.getCannibals()) && (this.getMissionaries() == otherRiverBank.getMissionaries());
		}

		public int getCannibals() { return cannibals; }
		public int getMissionaries() { return missionaries; }
	}
}
