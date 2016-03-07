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

		static Vector3 from8To61 = new Vector3(-3.05F, 1.0F, 25.43F);
		static Vector3 from8To62 = new Vector3(-22.55F, 1.0F, 35.42F);
		static Vector3 from8To64 = new Vector3(-6.32F, 1.0F, 27.43F);
		static Vector3 from8To65 = new Vector3(-25.22F, 1.0F, 29.46F);		
		static Vector3 from8To71 = new Vector3 (-17.0F, 1.0F, 11.2F);
		static Vector3 from8To72 = new Vector3 (-21.1F, 1.0F, 13.7F);
		static Vector3 from8To12 = new Vector3 (-19.99F, 1.0F, 0.63F);
		static Vector3 from8To21 = new Vector3 (-12.5F, 1.0F, 15.4F);
		static Vector3 from8To22 = new Vector3 (-24.9F, 1.0F, 21.4F);
		static Vector3 from8To23 = new Vector3 (-28.3F, 1.0F, 15.7F);
		static Vector3 from8To24 = new Vector3 (-38.95F, 1.0F, 20.73F);
		static Vector3 from8To25 = new Vector3 (-42.85F, 1.0F, 10.96F);
		static Vector3 from8To31 = new Vector3 (-47.4F, 1.0F, 22.9F);
		static Vector3 from8To32 = new Vector3 (-53.29F, 1.0F, 21.7F);
		static Vector3 from8To33 = new Vector3 (-62.9F, 1.0F, 26.02F);
		static Vector3 from8To34 = new Vector3 (-65.79F, 1.0F, 20.08F);
		static Vector3 from8To41 = new Vector3 (-4.4F, 1.0F, 33.7F);
		static Vector3 from8To42 = new Vector3 (-29.5F, 1.0F, 39.0F);
		static Vector3 from8To43 = new Vector3 (-42.0F, 1.0F, 39.9F);
		static Vector3 from8To44 = new Vector3 (-69.1F, 1.0F, 40.9F);
		static Vector3 from8To45 = new Vector3 (-83.64F, 1.0F, 41.1F);
		static Vector3 from8To46 = new Vector3 (-86.81F, 1.0F, 32.7F);
		static Vector3 from8To55 = new Vector3 (-57.25F, 1.0F, 40.53F);
		static Vector3 from8To56 = new Vector3 (-60.24F, 1.0F, 31.36F);

		
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


		static Vector3[] block6 = new Vector3[] { from8To61, from8To62, from8To65 };

		static Vector3[] block7 = new Vector3[] { from8To61, from8To64, from8To71, from8To72 };
		static Vector3[] block1 = new Vector3[] { from8To61, from8To64, from8To12 };
		static Vector3[] block2 = new Vector3[] { from8To61, from8To64, from8To21, from8To22, from8To23, from8To24, from8To25 };
		static Vector3[] block3 = new Vector3[] { from8To61, from8To64, from8To21, from8To22, from8To23, from8To24, from8To31, from8To32, from8To33, from8To34 };
		static Vector3[] block5 = new Vector3[] { from8To61, from8To64, from8To41, from8To42, from8To43, from8To55, from8To56 };
		static Vector3[] block4 = new Vector3[] { from8To61, from8To64, from8To41, from8To42, from8To43, from8To44, from8To45, from8To46 };
		
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


			
			PositnCamera.Add("office1",pos1);
			PositnCamera.Add("office2",pos2);
			PositnCamera.Add("office3",pos3);
			PositnCamera.Add("office4",pos4);
			PositnCamera.Add("office5",pos5);
			PositnCamera.Add("office6",pos6);
			PositnCamera.Add("office7",pos7);
			
			LookatCamera.Add("office1",lookat1);
			LookatCamera.Add("office2",lookat2);
			LookatCamera.Add("office3",lookat3);
			LookatCamera.Add("office4",lookat4);
			LookatCamera.Add("office5",lookat5);
			LookatCamera.Add("office6",lookat6);
			LookatCamera.Add("office7",lookat7);
		}
	}
}

