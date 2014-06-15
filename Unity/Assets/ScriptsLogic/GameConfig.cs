using  AssemblyCSharp.ScriptsLogic.Enums;
using System;

namespace AssemblyCSharp.ScriptsLogic
{
		public static class GameConfig
		{
			static GameConfig ()
			{
			}

			public static ScreenRatioType ScreenRatio { get { return ScreenRatioType.Ratio16x9; } }
		}
}

