using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_16_CS_PT2_2_BFS
{
	//BFS (Breadth First Search, 너비 우선 탐색) 최단거리 탐색에 사용
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
			{ 1, 1, 0, 0, 1, 0},
			{ 0, 0, 0, 1, 0, 1},
			{ 0, 0, 0, 0, 1, 0},
		};
														//		이렇게도 가능하다.
		List<int>[] adj2 = new List<int>[]				//	int[][] adj2 = new int[][]
		{												//	{
			new List<int>() { 1, 3 },					//		new int[]{ 1, 3 },
			new List<int>() { 0, 2, 3 },				//		new int[]{ 0, 2, 3 },
			new List<int>() { 1 },						//		new int[]{ 1 },
			new List<int>() { 0, 1, 4 },				//		new int[]{ 0, 1, 4 },
			new List<int>() { 3, 5 },					//		new int[]{ 3, 5 },
			new List<int>() { 4 }						//		new int[]{ 4 },
		};                                              //	};

		public void BFS(int start)
		{
			bool[] found = new bool[6];		//	찾은 방을 ture로 표시
			int[] parent = new int[6];		//	어디서부터 왔는지 추적
			int[] distance = new int[6];	//	오기까지 얼마의 거리가 걸리는지

			Queue<int> q = new Queue<int>();
			q.Enqueue(start);		// 시작방 예약
			found[start] = true;    //	시작방 체크
			parent[start] = start;	//	어디에서 왔는지 체크
			distance[start] = 0;	//	시작점에서 특정 방까지 얼마나 걸리는지 체크

			while (q.Count>0)   //	큐의 요소가 0이되면(모든 방 체크시) 종료
			{
				int now = q.Dequeue();	//	큐에있던 예약된 방 불러오기
				Console.WriteLine(now);

				for (int next = 0; next < 6; next++)
				{
					if (adj[now, next] == 0)    //	인접하지 않았으면 스킵
						continue;
					if (found[next])    //	이미 체크한 방이라면 스킵
						continue;
					q.Enqueue(next);	//	큐에 다음방 예약
					found[next] = true; //	다음방 체크
					parent[next] = now;	//	다음방을 갈수 있는 현재지점 저장
					distance[next] = distance[now]+1;	//지금방까지 걸린거리 +1 을 다음방 거리를 저장
				}
			}
		}

	}
	internal class Program
	{
		static void Main(string[] args)
		{
			Graph graph = new Graph();
			graph.BFS(0);
		}
	}
}
