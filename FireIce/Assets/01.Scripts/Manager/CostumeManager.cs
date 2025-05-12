using UnityEngine;
using UnityEngine.UI;
using TMPro; // Ãß°¡!

public class CostumeManager : MonoBehaviour
{
    public Button fireChangeButton;
    public Button iceChangeButton;
    public TMP_Text fireChangeText; // ¡ç Text ¡æ TMP_Text
    public TMP_Text iceChangeText;

    private int selectedPlayerIndex = -1;
    private bool isChanging = false;

    public void OnChangeButtonClicked(int playerIndex)
    {
        if (selectedPlayerIndex == playerIndex && isChanging)
        {
            Debug.Log($"Player {playerIndex} ÄÚ½ºÆ¬ ÀúÀåµÊ!");

            selectedPlayerIndex = -1;
            isChanging = false;

            SetButtonText(fireChangeText, "Change");
            SetButtonText(iceChangeText, "Change");
        }
        else
        {
            selectedPlayerIndex = playerIndex;
            isChanging = true;

            if (playerIndex == 0)
            {
                SetButtonText(fireChangeText, "Save");
                SetButtonText(iceChangeText, "Change");
            }
            else
            {
                SetButtonText(iceChangeText, "Save");
                SetButtonText(fireChangeText, "Change");
            }

            Debug.Log($"Player {playerIndex} ¼±ÅÃµÊ (Change ¸ðµå)");
        }
    }

    private void SetButtonText(TMP_Text textComponent, string value)
    {
        textComponent.text = value;
    }

    public bool IsChanging() => isChanging;
    public int GetSelectedPlayerIndex() => selectedPlayerIndex;
}
