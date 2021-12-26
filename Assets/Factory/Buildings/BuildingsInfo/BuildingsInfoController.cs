using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsInfoController : MonoBehaviour
{
    [SerializeField] BuildingConfig[] configs;

    public BuildingConfig[] Configs => configs;
}
