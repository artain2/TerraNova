using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingProcessMaster : MonoBehaviour
{
    [Header("Inject")]
    [SerializeField] UIController _uiController;
    [SerializeField] ObstackleController _obstackles;
    [SerializeField] BuildingsInfoController _buildingInfos;
    [SerializeField] BuildingPresetController _buildingPresetController;
    [SerializeField] BuildingsFabric _buildingFabric;
    [SerializeField] TileController _tileController;
    [Header("Own")]
    [SerializeField] BuildingsWindow _buildingWindowPrefab;

    private BuildingsWindow _buildingWindowInstance;

    public void Init()
    {
        _uiController.UI._commandButtons._buildButton.onClick.AddListener(AtButtonBuildClick);
        _uiController.UI._buildingAcceptPanel._okButton.onClick.AddListener(AtAcceptButtonClick);
        _uiController.UI._buildingAcceptPanel._noButton.onClick.AddListener(AtDenieButtonClick);
        _buildingPresetController.OnObstackleStatusChange += AtObstackleStatusChange;
    }

    private void AtObstackleStatusChange(bool isClear)
    {
        _uiController.UI._buildingAcceptPanel._okButton.interactable = isClear;
    }

    private void AtButtonBuildClick()
    {
        _uiController.UI._commandButtons._buildButton.interactable = false;
        _buildingWindowInstance = _uiController.CreateWindow(_buildingWindowPrefab);
        _buildingWindowInstance.OnBuildingSelected += AtBuildingSelected;
        _buildingWindowInstance.OnCloseClick += CloseWindow;
        _buildingWindowInstance.AddBuildings(_buildingInfos.Configs);
    }

    private void AtBuildingSelected(BuildingConfig buildingConfig)
    {
        _buildingPresetController.StartBuildings(buildingConfig);
        var startCoordinate = _tileController.CoordinateByPosition(Camera.main.transform.position);
        _buildingPresetController.MoveInstanceToCoordinate(startCoordinate);
        SetUIBuildState(true);

        _buildingWindowInstance.gameObject.SetActive(false);
    }

    private void CloseWindow()
    {
        _uiController.UI._commandButtons._buildButton.interactable = true;
        _buildingWindowInstance.Close();
    }

    private void AtAcceptButtonClick()
    {
        BuildingConfig config = _buildingPresetController.CurrentConfig;
        Vector2Int coord = _buildingPresetController.CurrentCoordinate;

        _buildingFabric.CreateBuilding(config, coord);
        _obstackles.Registrate(coord, config._size, config.id);
        CloseWindow();
        SetUIBuildState(false);
        _buildingPresetController.StopBuilding();
    }

    private void AtDenieButtonClick()
    {
        SetUIBuildState(false);
        _buildingPresetController.StopBuilding();
        _buildingWindowInstance.gameObject.SetActive(true);
    }

    private void SetUIBuildState(bool buildState)
    {
        _uiController.UI._commandButtons.gameObject.SetActive(!buildState);
        _uiController.UI._buildingAcceptPanel.gameObject.SetActive(buildState);
    }
}
