using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] SpriteRenderer _mainRen;

    public BuildingConfig Config { get; private set; }
    public Vector2Int Coordinate { get; private set; }

    public Building SetValues(BuildingConfig config, Vector2Int coord)
    {
        SetConfig(config);
        SetCoordinate(coord);
        SetMainSprite(config._buildingImage);
        return this;
    }

    public Building SetConfig(BuildingConfig config)
    {
        Config = config;
        return this;
    }

    public Building SetCoordinate(Vector2Int coord)
    {
        Coordinate = coord;
        return this;
    }

    public Building SetMainSprite(Sprite sprt)
    {
        _mainRen.sprite = sprt;
        return this;
    }

}
