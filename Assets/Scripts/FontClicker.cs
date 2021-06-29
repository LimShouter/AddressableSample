using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FontClicker : MonoBehaviour
{
        [SerializeField] private List<TextMeshProUGUI> text;
        [SerializeField] private Button next;
        [SerializeField] private Button previous;
        [SerializeField] private Button back;
        private List<TMP_FontAsset> _fonts = new List<TMP_FontAsset>();
        private int _counter = 0;
        private void Awake()
        {
                Addressables.LoadAssetsAsync<TMP_FontAsset>("font", (item) => {_fonts.Add(item); });
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
                _counter ++ ;
                if (_counter > _fonts.Count-1)
                {
                        _counter = 0;
                }
                SetCurrentFont(_fonts[_counter]);
        }

        private void Previous()
        {
                _counter -- ;
                if (_counter < 0)
                {
                        _counter = _fonts.Count-1;
                }
                SetCurrentFont(_fonts[_counter]);
        }

        private void SetCurrentFont(TMP_FontAsset fontAsset)
        {
                foreach (var item in text)
                {
                        item.font = fontAsset;
                }
        }
        
}