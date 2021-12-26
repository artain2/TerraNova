using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BuildingsWindow : MonoBehaviour
{
    public event Action OnCloseClick;
    public event Action<BuildingConfig> OnBuildingSelected;

    [SerializeField] Button _closeButton;
    [SerializeField] BuildingWindowItem _itemPrefab;
    [SerializeField] Transform _root;


    List<BuildingWindowItem> itemInstances = new List<BuildingWindowItem>();

    private void Start()
    {
        _closeButton.onClick.AddListener(() => OnCloseClick?.Invoke());
    }

    public BuildingsWindow AddBuildings(IEnumerable<BuildingConfig> buildingConfigs)
    {
        foreach (var config in buildingConfigs)
        {
            var inst = Instantiate(_itemPrefab, _root);
            inst.SetHandle(config).SetIcon(config._buildingImage).SetName(config._buildingName);
            inst.SetClickCallback(AtItemClick);
            itemInstances.Add(inst);
        }

        return this;
    }
    public BuildingsWindow Close()
    {
        OnBuildingSelected = null;
        OnCloseClick = null;
        Destroy(gameObject);
        return this;
    }

    public void Clear()
    {
        for (int i = 0; i < itemInstances.Count; i++)
        {
            Destroy(itemInstances[i]);
        }
        itemInstances.Clear();
    }

    private void AtItemClick(BuildingWindowItem sender)
    {
        OnBuildingSelected?.Invoke(sender.ConfigHandle);
    }
}
