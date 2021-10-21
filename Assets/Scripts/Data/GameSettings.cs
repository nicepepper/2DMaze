using System;
using UnityEngine;

namespace Data 
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "2DMaze/GameSettings")]
    public class GameSettings : ScriptableObject 
    {

        [Header("Tiles")]
        [SerializeField] private int _mazeWidth = 10;
        [SerializeField] private int _mazeHeight = 10;

        public int TileWidth => _mazeWidth;
        public int MazeHeight => _mazeHeight;

        public static GameSettings Current;
    }
}