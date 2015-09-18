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

        static Vector3 from8To61 = new Vector3(-3.3F, 1.2F, 24.7F);
        static Vector3 from8To62 = new Vector3(-6.5F, 1.2F, 27.5F);
        static Vector3 from8To64 = new Vector3(-9.2F, 1.2F, 23.6F);
		static Vector3 from8To65 = new Vector3(-13.5F, 1.2F, 24.9F);		
		static Vector3 from8To71 = new Vector3 (-17.0F, 9.5F, 11.2F);
		static Vector3 from8To72 = new Vector3 (-21.1F, 9.5F, 13.7F);
		static Vector3 from8To11 = new Vector3 (-10.2F, 9.5F, 8.7F);
		static Vector3 from8To12 = new Vector3 (-13.3F, 9.5F, 0.3F);
		static Vector3 from8To21 = new Vector3 (-12.5F, 9.5F, 15.4F);
		static Vector3 from8To22 = new Vector3 (-24.9F, 14.5F, 21.4F);
		static Vector3 from8To23 = new Vector3 (-28.3F, 14.5F, 15.7F);
		static Vector3 from8To24 = new Vector3 (-33.6F, 14.5F, 18.5F);
		static Vector3 from8To25 = new Vector3 (-35.8F, 14.5F, 12.6F);
		static Vector3 from8To31 = new Vector3 (-47.4F, 14.5F, 22.9F);
		static Vector3 from8To32 = new Vector3 (-55.5F, 14.5F, 20.5F);
		static Vector3 from8To51 = new Vector3 (-53.0F, 14.5F, 26.1F);
		static Vector3 from8To41 = new Vector3 (-4.4F, 14.5F, 33.7F);
		static Vector3 from8To42 = new Vector3 (-29.5F, 14.5F, 39.0F);
		static Vector3 from8To43 = new Vector3 (-42.0F, 14.5F, 39.9F);
		static Vector3 from8To44 = new Vector3 (-69.1F, 14.5F, 40.9F);
		static Vector3 from8To45 = new Vector3 (-77.5F, 14.5F, 40.6F);
		static Vector3 from8To46 = new Vector3 (-81.3F, 14.5F, 33.2F);

		
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


		static Vector3[] block6 = new Vector3[] { from8To61, from8To62, from8To64, from8To65 };

		static Vector3[] block7 = new Vector3[] { from8To61, from8To62, from8To71, from8To72 };
		static Vector3[] block1 = new Vector3[] { from8To61, from8To62, from8To71, from8To11, from8To12 };
		static Vector3[] block2 = new Vector3[] { from8To61, from8To62,  from8To21, from8To22, from8To23, from8To24, from8To25 };
		static Vector3[] block3 = new Vector3[] { from8To61, from8To62, from8To21, from8To22, from8To23, from8To24, from8To31, from8To32 };
		static Vector3[] block5 = new Vector3[] { from8To61, from8To62, from8To21, from8To22, from8To23, from8To31, from8To51 };
		static Vector3[] block4 = new Vector3[] { from8To61, from8To62, from8To41, from8To42, from8To43, from8To44, from8To45, from8To46 };
		
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

