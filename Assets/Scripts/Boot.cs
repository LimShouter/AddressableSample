using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boot : MonoBehaviour
{
    [SerializeField] private Button loadFontClickerButton;
    [SerializeField] private Button loadSpriteClickerButton;

    private void Awake()
    {
        loadFontClickerButton.onClick.AddListener(LoadFontClicker);
        loadSpriteClickerButton.onClick.AddListener(LoadSpriteClicker);
    }

    private void LoadFontClicker()
    {
        Addressables.LoadSceneAsync("FontClicker");
    }

    private void LoadSpriteClicker()
    {
        Addressables.LoadSceneAsync("SpriteClicker");
    }

    private void OnDestroy()
    {
        loadFontClickerButton.onClick.RemoveListener(LoadFontClicker);
        loadSpriteClickerButton.onClick.RemoveListener(LoadSpriteClicker);
    }
}
