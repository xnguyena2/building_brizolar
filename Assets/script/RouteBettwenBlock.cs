//------------------------------------------------------------------------------
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace AssemblyCSharp
{
	public class RouteBettwenBlock
	{

		static Vector3 startPoint = new Vector3(-9.897F, 1.0F, 24.54F);

		static Vector3 to81 = new Vector3(-5.71F, 1.0F, 20.99F);

		static Vector3 to61 = new Vector3(-7.1F, 1.0F, 30.04F);
		static Vector3 to62 = new Vector3(-22.02F, 1.0F, 36.61F);
		static Vector3 to63 = new Vector3(-25.22F, 1.0F, 29.46F);		

		static Vector3 to71 = new Vector3 (-14.71F, 1.0F, 14.11F);
		static Vector3 to72 = new Vector3 (-21.1F, 1.0F, 13.7F);

		static Vector3 to11 = new Vector3 (-18.85F, 1.0F, 5.97F);
		static Vector3 to12 = new Vector3 (-19.99F, 1.0F, 0.63F);

		static Vector3 to21 = new Vector3 (-13.88F, 1.0F, 16.53F);
		static Vector3 to22 = new Vector3 (-23.99F, 1.0F, 20.92F);
		static Vector3 to23 = new Vector3 (-43.83F, 1.0F, 17F);
		static Vector3 to24 = new Vector3 (-42.85F, 1.0F, 10.96F);
		
		static Vector3 to30 = new Vector3 (-41.28F, 1.0F, 15.71F);
		static Vector3 to31 = new Vector3 (-63.35F, 1.0F, 26.32F);
		static Vector3 to32 = new Vector3 (-65.79F, 1.0F, 20.08F);

		static Vector3 to41 = new Vector3 (-4.4F, 1.0F, 33.7F);
		static Vector3 to42 = new Vector3 (-29.5F, 1.0F, 39.0F);
		static Vector3 to43 = new Vector3 (-42.0F, 1.0F, 39.9F);
		static Vector3 to44 = new Vector3 (-69.1F, 1.0F, 40.9F);
		static Vector3 to45 = new Vector3 (-83.64F, 1.0F, 41.1F);
		static Vector3 to46 = new Vector3 (-86.81F, 1.0F, 32.7F);

		static Vector3 to55 = new Vector3 (-57.25F, 1.0F, 40.53F);
		static Vector3 to56 = new Vector3 (-60.24F, 1.0F, 31.36F);

		
		static Vector3 pos1 = new Vector3 (312.1F, 68.6F, 266.0F);
		static Vector3 lookat1 = new Vector3 (266.7F, -26.4F, 187.2F);
		static Vector3 pos2 = new Vector3 (325.0F, 79.5F, 259.3F);
		static Vector3 lookat2 = new Vector3 (281.8F, 0.0F, 192.1F);
		static Vector3 pos4 = new Vector3 (291.1F, 79.0F, 266.2F);
		static Vector3 lookat4 = new Vector3 (271.2F, 9.1F, 207.7F);
		static Vector3 pos3 = new Vector3 (322.6F, 69.4F, 264.4F);
		static Vector3 lookat3 = new Vector3 (276.2F, -10.3F, 193.5F);
		static Vector3 pos5 = new Vector3 (316.0F, 80.2F, 257.3F);
		static Vector3 lookat5 = new Vector3 (274.6F, -12.5F, 194.7F);
		static Vector3 pos6 = new Vector3 (293.0F, 79.6F, 258.9F);
		static Vector3 lookat6 = new Vector3 (268.0F, -3.7F, 197.9F);
		static Vector3 pos7 = new Vector3 (304.1F, 78.1F, 256.3F);
		static Vector3 lookat7 = new Vector3 (268.5F, -12.9F, 192.0F);


		static Vector3[] block6 = new Vector3[] { startPoint, to61, to62, to63 };
		static Vector3[] block8 = new Vector3[] { startPoint, to81 };
		static Vector3[] block7 = new Vector3[] { startPoint, to71, to72 };
		static Vector3[] block1 = new Vector3[] { startPoint, to11, to12 };
		static Vector3[] block2 = new Vector3[] { startPoint, to21, to22, to30, to24 };
		static Vector3[] block3 = new Vector3[] { startPoint, to21, to22, to23, to31, to32 };
		static Vector3[] block5 = new Vector3[] { startPoint, to41, to42, to43, to55, to56 };
		static Vector3[] block4 = new Vector3[] { startPoint, to41, to42, to43, to44, to45, to46 };
		
		public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();
		public Dictionary<string,Vector3> PositnCamera = new Dictionary<string, Vector3> ();
		public Dictionary<string,Vector3> LookatCamera = new Dictionary<string, Vector3> ();

		public RouteBettwenBlock ()
		{
			dictionary.Add("office1",block1);
			dictionary.Add("office2",block2);
			dictionary.Add("office3",block3);
			dictionary.Add("office4",block4);
			dictionary.Add("office5",block5);
			dictionary.Add("office6",block6);
			dictionary.Add("office7",block7);
			dictionary.Add("office8",block8);

			
			PositnCamera.Add("office1",pos1);
			PositnCamera.Add("office2",pos2);
			PositnCamera.Add("office3",pos3);
			PositnCamera.Add("office4",pos4);
			PositnCamera.Add("office5",pos5);
			PositnCamera.Add("office6",pos6);
			PositnCamera.Add("office7",pos7);
			PositnCamera.Add("office8",pos6);
			
			LookatCamera.Add("office1",lookat1);
			LookatCamera.Add("office2",lookat2);
			LookatCamera.Add("office3",lookat3);
			LookatCamera.Add("office4",lookat4);
			LookatCamera.Add("office5",lookat5);
			LookatCamera.Add("office6",lookat6);
			LookatCamera.Add("office7",lookat7);
			LookatCamera.Add("office8",lookat7);
		}
	}
}

