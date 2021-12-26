using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initer : MonoBehaviour
{
    [SerializeField] UIController uiController;
    [SerializeField] BuildingProcessMaster buildProcessMaster;

    private void Start()
    {
        uiController.Init();
        buildProcessMaster.Init();
    }
}
