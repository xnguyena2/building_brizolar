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
	public class Point7_1
	{
		public static Vector3 f1 = new Vector3 (5.62F, 1.0F, 18.8F);
		public static Vector3 f2 = new Vector3 (-5.96F, 1.0F, 18.8F);
		public static Vector3 f3 = new Vector3 (-20.34F, 1.0F, -4.87F);
		public static Vector3 f4 = new Vector3 (20.91F, 1.0F, -3.05F);
		
		static Vector3 o1 = new Vector3 (5.62F, 1.0F, 10.85F);
		static Vector3 o2 = new Vector3 (-5.96F, 1.0F, 10.18F);
		static Vector3 o3 = new Vector3 (-8.66F, 1.0F, -4.87F);
		static Vector3 o4 = new Vector3 (12.88F, 1.0F, -3.05F);
		
		static Vector3[] office1 = new Vector3[] { f1, o1 };
		static Vector3[] office2 = new Vector3[] { f2, o2 };
		static Vector3[] office3 = new Vector3[] { f3, o3 };		
		static Vector3[] office4 = new Vector3[] { f4, o4 };


		static Vector3 pos1 = new Vector3 (290.1F, 29.6F, 238.6F);
		static Vector3 lookat1 = new Vector3 (289.9F, -1.1F, 191.0F);
		static Vector3 pos2 = new Vector3 (275.2F, 27.7F, 247.4F);
		static Vector3 lookat2 = new Vector3 (291.3F, 2.5F, 190.1F);
		static Vector3 pos3 = new Vector3 (248.7F, 22.3F, 208.4F);
		static Vector3 lookat3 = new Vector3 (292.6F, -4.1F, 186.0F);
		static Vector3 pos4 = new Vector3 (336.1F, 22.3F, 231.3F);
		static Vector3 lookat4 = new Vector3 (291.7F, -5.9F, 187.2F);

		
		static Vector3[] thangmay1 = new Vector3[] { f1 };
		static Vector3[] thangmay2 = new Vector3[] { f2 };
		static Vector3[] thangmay3 = new Vector3[] { f3 };
		static Vector3[] thangmay4 = new Vector3[] { f4 };

		
		public Dictionary<string, Vector3[]> dictionary = new Dictionary<string, Vector3[]>();
		public Dictionary<string,Vector3> PositnCamera = new Dictionary<string, Vector3> ();
		public Dictionary<string,Vector3> LookatCamera = new Dictionary<string, Vector3> ();

		public Point7_1 ()
		{
			
			PositnCamera.Add("office1",pos1);
			PositnCamera.Add("office2",pos2);
			PositnCamera.Add("office3",pos3);
			PositnCamera.Add("office4",pos4);
			
			LookatCamera.Add("office1",lookat1);
			LookatCamera.Add("office2",lookat2);
			LookatCamera.Add("office3",lookat3);
			LookatCamera.Add("office4",lookat4);

			
			dictionary.Add("office1",office1);
			dictionary.Add("office2",office2);
			dictionary.Add("office3",office3);
			dictionary.Add("office4",office4);

			dictionary.Add("thangmay1", thangmay1);
			dictionary.Add("thangmay2", thangmay2);
			dictionary.Add("thangmay3", thangmay3);
			dictionary.Add("thangmay4", thangmay4);
		}
	}
}

