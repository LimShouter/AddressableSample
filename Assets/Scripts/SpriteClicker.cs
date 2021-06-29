using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class SpriteClicker : MonoBehaviour
{
    [SerializeField] private List<Image> images;
    [SerializeField] private Button next;
    [SerializeField] private Button previous;
    [SerializeField] private Button back;
    
    private List<Sprite> _sprites = new List<Sprite>();
    private int _counter = 0;

    private void Awake()
    {
        
        Addressables.LoadAssetsAsync<Sprite>("sprite",item=>{ _sprites.Add(item);});
        next.onClick.AddListener(Next);
        previous.onClick.AddListener(Previous);
        back.onClick.AddListener(Back);
    }
    private void Back()
    {
        Addressables.LoadSceneAsync("Boot");
    }
    
    private void Next()
    {
        _counter++;
        if (_counter > _sprites.Count-1)
        {
            _counter = 0;
        }
        SetCurrentFont(_sprites[_counter]);
    }

    private void Previous()
    {
        _counter--;
        if (_counter < 0 )
        {
            _counter = _sprites.Count-1;
        }
        SetCurrentFont(_sprites[_counter]);
    }

    private void SetCurrentFont(Sprite sprite)
    {
        foreach (var item in images)
        {
            item.sprite = sprite;
        }
    }
}