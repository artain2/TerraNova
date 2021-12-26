using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingPresetController : MonoBehaviour
{
    public event Action<bool> OnObstackleStatusChange;

    [Header("Inject")]
    [SerializeField] TileController _tileController;
    [SerializeField] ObstackleController _obstackeController;
    [Header("Own")]
    [SerializeField] BuildingPreset _presetPrefab;
    [SerializeField] Color _goodTileColor;
    [SerializeField] Color _badTileColor;

    private BuildingPreset _presetInstance;
    private bool _processActive = false;
    public Vector2Int CurrentCoordinate { get; private set; }
    public BuildingConfig CurrentConfig { get; private set; }
    public bool NoOverlapingNow { get; private set; }


    public void StartBuildings(BuildingConfig config)
    {
        CurrentConfig = config;
        _presetInstance = Instantiate(_presetPrefab);
        _presetInstance.SetImage(config._buildingImage).SetSize(config._size, 1f);
        _processActive = true;


    }

    public void StopBuilding()
    {
        _processActive = false;
        Destroy(_presetInstance.gameObject);
        CurrentConfig = null;
    }

    public void MoveInstanceToCoordinate(Vector2Int coordinate)
    {
        _presetInstance.transform.position = _tileController.PositionByCoordinate(coordinate);
        CurrentCoordinate = coordinate;
        UpdateObstaclesStatus();
    }

    private void Update()
    {
        if (!_processActive)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var thisFrameCoord = _tileController.CoordinateByPosition(wp);
            if (thisFrameCoord != CurrentCoordinate)
            {
                MoveInstanceToCoordinate(thisFrameCoord);
            }
        }
    }


    private void UpdateObstaclesStatus()
    {
        Dictionary<Vector2Int, Color> colorMap = new Dictionary<Vector2Int, Color>();
        var size = CurrentConfig._size;
        NoOverlapingNow = true;
        for (int x = 0; x < size.x; x++)
        {
            for (int y = 0; y < size.y; y++)
            {
                Vector2Int local = new Vector2Int(x, y);
                Vector2Int global = local + CurrentCoordinate;
                bool busy = _obstackeController.CheckBusy(global);
                Color col = busy ? _badTileColor : _goodTileColor;
                if (busy)
                {
                    NoOverlapingNow = false;
                }
                colorMap.Add(local, col);
            }
        }
        OnObstackleStatusChange?.Invoke(NoOverlapingNow);
        _presetInstance.SetColorsMap(colorMap);
    }
}
