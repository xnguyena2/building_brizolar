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
using System.IO;
namespace AssemblyCSharp
{
	public class writetofile
	{
		static public void write2File(string filename,string text){
			System.IO.File.WriteAllText (filename, text);
		}

		static public void append2File(string filename,string text){
			File.AppendAllText(filename, text); 
		}

		public writetofile ()
		{
		}
	}
}

