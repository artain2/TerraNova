using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] float _tileSize = 1f;

    public float TileSize => _tileSize;

    public Vector3 PositionByCoordinate(Vector2Int coordinate)
    {
        return new Vector3(coordinate.x, coordinate.y, 0);
    }

    public Vector2Int CoordinateByPosition(Vector3 position)
    { 
        return new Vector2Int(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y));
    }

    public List<Vector2Int> GetCoordinatesGroup(Vector2Int anchor, Vector2Int size)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                result.Add(anchor + new Vector2Int(x, y));
            }
        }

        return result;
    }

}
