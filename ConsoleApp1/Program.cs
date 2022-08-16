using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int T = int.Parse(Console.ReadLine());
			int[] a = new int[T];
			int[] b = new int[T];
			StringBuilder addNum = new StringBuilder();
			for(int i =0;i<T;i++)
			{
				string[] s = Console.ReadLine().Split();
				a[i] = int.Parse(s[0]);
				b[i] = int.Parse(s[1]);
				addNum.Append(a[i]+b[i]+"\n");
			}
			Console.WriteLine(addNum.ToString());
		}
	}
}