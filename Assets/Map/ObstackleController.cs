using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TerraNova.Map
{
    public class ObstackleController : MonoBehaviour
    {
        Dictionary<Vector2Int, int> _obstackes = new Dictionary<Vector2Int, int>();

        public void Registrate(Vector2Int coordinate, int id)
        {
            _obstackes.Add(coordinate, id);
        }
        public void Registrate(Vector2Int coordinate, Vector2Int size, int id)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Registrate(coordinate + new Vector2Int(x, y), id);
                }
            }
        }

        public void Unregistrate(Vector2Int coordinate)
        {
            _obstackes.Remove(coordinate);
        }

        public void Unregistrate(Vector2Int coordinate, Vector2Int size)
        {
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    Unregistrate(coordinate + new Vector2Int(x, y));
                }
            }
        }

        public bool CheckBusy(Vector2Int coordinate)
        {
            return _obstackes.ContainsKey(coordinate);
        }
    }
}