using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetcolor;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private GameObject _highlight;
    public bool Init(bool isOffset)
    {
        _spriteRenderer.color = isOffset ? _offsetcolor : _baseColor;
        return isOffset;
    }

    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
