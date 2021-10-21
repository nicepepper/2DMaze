using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Map
{
    public class MazeGeneratorCell
    {
        public int X;
        public int Y;
        public int DistanceFromStart;

        public bool WallLeft = true;
        public bool WallBottom = true;
        public bool IsVisited = false;
    }
    
    public class MazeGenerator
    {
        public int Width = 20;
        public int Height = 20;

        public MazeGeneratorCell[,] GenerateMaze()
        {
            MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Height];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    maze[x, y] = new MazeGeneratorCell { X = x, Y = y };
                }
            }
            
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                maze[x, Height - 1].WallLeft = false;
            }

            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[Width - 1, y].WallBottom = false;
            }
            
            RemoveWallsWithBacktracking(maze);
            
            return maze;
        }

        public void RemoveWallsWithBacktracking(MazeGeneratorCell[,] maze)
        {
            MazeGeneratorCell current = maze[0, 0];
            current.IsVisited = true;
            current.DistanceFromStart = 0;
            
            Stack<MazeGeneratorCell> pathStack = new Stack<MazeGeneratorCell>();

            do
            {
                List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

                int x = current.X;
                int y = current.Y;

                if (x > 0 && !maze[x - 1, y].IsVisited) unvisitedNeighbours.Add(maze[x - 1, y]);
                if (y > 0 && !maze[x, y - 1].IsVisited) unvisitedNeighbours.Add(maze[x, y - 1]);
                if (x < Width - 2 && !maze[x + 1, y].IsVisited) unvisitedNeighbours.Add(maze[x + 1, y]);
                if (y < Height - 2 && !maze[x, y + 1].IsVisited) unvisitedNeighbours.Add(maze[x, y + 1]);

                if (unvisitedNeighbours.Count > 0)
                {
                    MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                    RemoveWall(current, chosen);

                    chosen.IsVisited = true;
                    pathStack.Push(chosen);
                    chosen.DistanceFromStart = current.DistanceFromStart + 1;
                    current = chosen;
                }
                else
                {
                    current = pathStack.Pop();
                }
            } while (pathStack.Count > 0);
        }
        
        private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
        {
            if (a.X == b.X)
            {
                if (a.Y > b.Y)
                {
                    a.WallBottom = false;
                }
                else
                {
                    b.WallBottom = false;
                }
            }
            else
            {
                if (a.X > b.X)
                {
                    a.WallLeft = false;
                }
                else
                {
                    b.WallLeft = false;
                }
            }
        }

        public MazeGeneratorCell GetLastCellMaze(MazeGeneratorCell[,] maze)
        {
            MazeGeneratorCell furthest = maze[0, 0];

            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x,y].DistanceFromStart > furthest.DistanceFromStart)
                    {
                        furthest = maze[x, y];
                    }
                }
            }

            return furthest;
        }
    }
}
