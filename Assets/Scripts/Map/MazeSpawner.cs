using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class MazeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private GameObject _segmentPrefab;
        [SerializeField] private GameObject _finishPrefab;

        private void Awake()
        {
            MazeGenerator generator = new MazeGenerator();
            MazeGeneratorCell[,] maze = generator.GenerateMaze();
            
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Cell c = Instantiate(_cellPrefab, new Vector3(x * 10, 0, y * 10), Quaternion.identity).GetComponent<Cell>();
                    
                    if ((x < maze.GetLength(0) - 1) && (y < maze.GetLength(1) - 1) )
                    {
                        Instantiate(_segmentPrefab, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
                    }
                    
                    c.WallLeft.SetActive(maze[x, y].WallLeft);
                    c.WallBottom.SetActive(maze[x, y].WallBottom);
                }
            }

            MazeGeneratorCell finishCell = generator.GetLastCellMaze(maze);
            Instantiate(_finishPrefab, new Vector3(finishCell.X * 10, 0, finishCell.Y * 10), Quaternion.identity);

            _cellPrefab.SetActive(false);
            _segmentPrefab.SetActive(false);
            _finishPrefab.SetActive(false);
        }
    }
}

