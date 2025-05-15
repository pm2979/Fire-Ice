using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour 
{
    [SerializeField] private GameObject volumePanel;
    [SerializeField] private Button volumeButton;
    [SerializeField] private Button backgroundBlockButton;

    private bool inVisible = false;

    private void Start()
    {
        volumePanel.SetActive(false);
        volumeButton.onClick.AddListener(ToggleVolumePanel);
        backgroundBlockButton.onClick.AddListener(ClosePanel);
    }

    private void ToggleVolumePanel()
    {
        inVisible = !inVisible;
        volumePanel.SetActive(inVisible);
    }

    private void ClosePanel()
    {
        inVisible = false;
        volumePanel.SetActive(false);
    }
}
