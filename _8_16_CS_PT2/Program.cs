using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_16_CS_PT2_1_DFS
{
	//DFS (Depth First Search, 깊이 우선 탐색)
	class Graph
	{
		// 그래프 표현의 두가지 방법
		// 1. 2차원 배열
		// 2. 리스트
		int[,] adj = new int[6, 6]
		{
			{ 0, 1, 0, 1, 0, 0},
			{ 1, 0, 1, 1, 0, 0},
			{ 0, 1, 0, 0, 0, 0},
			{ 1, 1, 0, 0, 0, 0},
			{ 0, 0, 0, 0, 0, 1},
			{ 0, 0, 0, 0, 1, 0},
		};

		List<int>[] adj2 = new List<int>[]
		{
			new List<int>() { 1, 3 },
			new List<int>() { 0, 2, 3 },
			new List<int>() { 1 },
			new List<int>() { 0, 1 },
			new List<int>() { 5 },
			new List<int>() { 4 }
		};

		//행렬버전
		bool[] visited = new bool[6];
		
		public void DFS(int now)
		{
			Console.WriteLine(now);
			visited[now] = true;	//now 부터 방문, 재귀로 돌아오면 다음 방 체크

			for(int next = 0; next < 6;next++)
			{
				if (adj[now, next] == 0)	//연결되어 있지 않으면, 스킵
					continue;
				if (visited[next])	// 이미 방문했으면 스킵.
					continue;
				DFS(next);
			}
		}
		public void SearchAll()
		{
			visited = new bool[6];
			for (int now = 0; now<6; now++)
				if (visited[now] == false)
					DFS(now);
		}


		//리스트버전
		bool[] visited2 = new bool[6];
		public void DFS2(int now)
		{
			Console.WriteLine(now);
			visited2[now] = true;	//now 부터 방문

			foreach (int next in adj2[now])
			{
				if (visited2[next])  // 이미 방문했으면 스킵.
					continue;
				DFS2(next);
			}
		}
		public void SearchAll2()	// 연결이 끊겨있는 그래프가 있을수 있어 다시 검사.
		{
			visited2 = new bool[6];
			for (int now = 0; now<6; now++)
				if (visited2[now] == false)
					DFS2(now);
		}

	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = new Graph();

			graph.SearchAll();
			
			Console.WriteLine();
			
			graph.SearchAll2();
		}
	}
}
