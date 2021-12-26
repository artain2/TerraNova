using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] SpriteRenderer _ren;
    [SerializeField] float _alpha = .6f;

    public void SetColor(Color col)
    {
        col.a = _alpha;
        _ren.color = col;
    }
}
