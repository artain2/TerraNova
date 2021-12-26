using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsFabric : MonoBehaviour
{
    [Header("Inject")]
    [SerializeField] TileController _tileController;
    [Header("Own")]
    [SerializeField] Building _buildingPrefab;
    [SerializeField] Transform _root;

    public void CreateBuilding(BuildingConfig config, Vector2Int coordinate)
    {
        var inst = Instantiate(_buildingPrefab, _root);
        var pos = _tileController.PositionByCoordinate(coordinate);
        inst.transform.position = pos;
        inst.SetValues(config, coordinate);
    }
}
