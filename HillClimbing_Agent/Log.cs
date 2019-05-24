﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HillClimbing_Agent
{
	class Log
	{
		const string FILE_NAME = "log.txt";
		
		public Log()
		{
			File.Create(FILE_NAME).Close();
		}

		public void Write(string data)
		{
			using(StreamWriter streamWriter = File.AppendText(FILE_NAME))
			{
				streamWriter.Write(data);
			}
		}

		public void WriteLine(string data)
		{
			using (StreamWriter streamWriter = File.AppendText(FILE_NAME))
			{
				streamWriter.WriteLine(data);
			}
		}
	}
}