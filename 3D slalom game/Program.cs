using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _3D_slalom_game
{
	static class Program
	{
		public static Form1 mainForm;
	
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mainForm = new Form1();
			Application.Run(mainForm);
		}
	}
}
