//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class Point5_2
	{
		static Vector3 start = new Vector3 (-0.4f, 1.5f, -0.1f);
		public static Vector3 evalator = new Vector3 (-0.1f, 1.5f, -2.99f);
		
		static Vector3 o1 = new Vector3 (25.8F, 3.8F, 16.3F);
		static Vector3 o2 = new Vector3 (9.0F, 3.8F, 10.4F);
		static Vector3 o3 = new Vector3 (16.7F, 3.8F, -7.1F);
		static Vector3 o4 = new Vector3 (33.5F, 3.8F, -0.6F);
		static Vector3 o5 = new Vector3 (-17.3F, 3.8F, 6.6F);
		static Vector3 o6 = new Vector3 (-34.1F, 3.8F, 0.7F);
		static Vector3 o7 = new Vector3 (-26.5F, 3.8F, -16.8F);
		static Vector3 o8 = new Vector3 (-9.7F, 3.8F, -10.3F);

		
		static Vector3 f1 = new Vector3 (25.8F, 3.8F, 8.27F);
		static Vector3 f2 = new Vector3 (16.7F, 3.8F, 10.4F);
		static Vector3 f3 = new Vector3 (16.7F, 3.8F, -0.1F);
		static Vector3 f4 = new Vector3 (26.32F, 3.8F, -0.1F);
		static Vector3 f5 = new Vector3 (-17.3F, 3.8F, -0.1F);
		static Vector3 f6 = new Vector3 (-26.71F, 3.8F, -0.1F);
		static Vector3 f7 = new Vector3 (-26.5F, 3.8F, -8.9F);
		static Vector3 f8 = new Vector3 (-17.3F, 3.8F, -10.3F);
		
		
		static Vector3[] office1 = new Vector3[] { evalator, start, f3, f1, o1 };
		static Vector3[] office2 = new Vector3[] { evalator, start, f3, f2, o2 };
		static Vector3[] office3 = new Vector3[] { evalator, start, f3, o3 };
		
		static Vector3[] office4 = new Vector3[] { evalator, start, f3, f4, o4 };
		
		static Vector3[] office5 = new Vector3[] { evalator, start, f5, o5 };
		static Vector3[] office6 = new Vector3[] { evalator, start, f5, f6, o6 };
		
		static Vector3[] office7 = new Vector3[] { evalator, start, f5, f7, o7 };
		static Vector3[] office8 = new Vector3[] { evalator, start, f5, f8, o8 };

		
		static Vector3 pos1 = new Vector3 (276.0F, 66.6F, 247.1F);
		static Vector3 lookat1 = new Vector3 (285.4F, 22.0F, 197.3F);
		static Vector3 pos2 = new Vector3 (284.2F, 74.7F, 256.3F);
		static Vector3 lookat2 = new Vector3 (286.4F, 19.8F, 196.1F);
		static Vector3 pos3 = new Vector3 (319.3F, 81.3F, 250.2F);
		static Vector3 lookat3 = new Vector3 (302.4F, 8.0F, 191.4F);
		static Vector3 pos4 = new Vector3 (323.6F, 59.7F, 260.3F);
		static Vector3 lookat4 = new Vector3 (301.0F, 4.4F, 192.5F);
		static Vector3 pos5 = new Vector3 (256.4F, 79.3F, 227.5F);
		static Vector3 lookat5 = new Vector3 (278.9F, 13.2F, 190.1F);
		static Vector3 pos6 = new Vector3 (266.1F, 89.4F, 229.2F);
		static Vector3 lookat6 = new Vector3 (275.4F, 8.0F, 189.3F);
		static Vector3 pos7 = new Vector3 (262.0F, 70.6F, 228.5F);
		static Vector3 lookat7 = new Vector3 (279.2F, 9.7F, 186.0F);
		static Vector3 pos8 = new Vector3 (261.6F, 76.2F, 222.3F);
		static Vector3 lookat8 = new Vector3 (277.5F, 13.4F, 186.7F);

		
		public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();
		public Dictionary<string,Vector3> PositnCamera = new Dictionary<string, Vector3> ();
		public Dictionary<string,Vector3> LookatCamera = new Dictionary<string, Vector3> ();

		public Point5_2 ()
		{
			
			LookatCamera.Add("office1",lookat1);
			LookatCamera.Add("office2",lookat2);
			LookatCamera.Add("office3",lookat3);
			LookatCamera.Add("office4",lookat4);
			LookatCamera.Add("office5",lookat5);
			LookatCamera.Add("office6",lookat6);
			LookatCamera.Add("office7",lookat7);
			LookatCamera.Add("office8",lookat8);

			PositnCamera.Add("office1",pos1);
			PositnCamera.Add("office2",pos2);
			PositnCamera.Add("office3",pos3);
			PositnCamera.Add("office4",pos4);
			PositnCamera.Add("office5",pos5);
			PositnCamera.Add("office6",pos6);
			PositnCamera.Add("office7",pos7);
			PositnCamera.Add("office8",pos8);
			

			dictionary.Add("office1",office1);
			dictionary.Add("office2",office2);
			dictionary.Add("office3",office3);
			dictionary.Add("office4",office4);
			dictionary.Add("office5",office5);
			dictionary.Add("office6",office6);
			dictionary.Add("office7",office7);
			dictionary.Add("office8",office8);
		}
	}
}

