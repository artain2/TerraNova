using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPreset : MonoBehaviour
{
    [SerializeField] SpriteRenderer _ren;
    [SerializeField] Tile _tilePrefab;

    private Dictionary<Vector2Int, Tile> _tileInstances = new Dictionary<Vector2Int, Tile>();

    public BuildingPreset SetImage(Sprite sprt)
    {
        _ren.sprite = sprt;
        return this;
    }

    public BuildingPreset SetSize(Vector2Int size, float tileSize)
    {
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                var inst = Instantiate(_tilePrefab);
                inst.transform.SetParent(transform);
                inst.transform.localPosition = new Vector3(x*tileSize, y*tileSize);
                var coordinate = new Vector2Int(x, y);
                _tileInstances.Add(coordinate, inst);
            }
        }
        return this;
    }

    public BuildingPreset SetColorsMap(Dictionary<Vector2Int, Color> colorMap)
    {
        foreach (var colorItem in colorMap)
        {
            _tileInstances[colorItem.Key].SetColor(colorItem.Value);
        }

        return this;
    }
}
