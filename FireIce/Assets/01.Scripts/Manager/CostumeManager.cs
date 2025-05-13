using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CostumeManager : MonoBehaviour
{
    [Header("Change Buttons")]
    public Button fireChangeButton;
    public Button iceChangeButton;
    public TMP_Text fireChangeText;
    public TMP_Text iceChangeText;

    [Header("Player Previews")]
    public Image firePreviewImage;
    public Image fireCostumeLayerImage;
    public Image icePreviewImage;
    public Image iceCostumeLayerImage;

    private int selectedPlayerIndex = -1; // 0 = Fire, 1 = Ice
    private bool isChanging = false;
    private readonly Dictionary<int, string> currentSelections = new();

    public void OnChangeButtonClicked(int playerIndex)
    {
        if (selectedPlayerIndex == playerIndex && isChanging)
        {
            if (currentSelections.TryGetValue(playerIndex, out string costumeId))
            {
                if (playerIndex == 0)
                {
                    CostumeData.fireCostumeId = costumeId;
                    PlayerPrefs.SetString("FireCostume", costumeId);
                }
                else
                {
                    CostumeData.iceCostumeId = costumeId;
                    PlayerPrefs.SetString("IceCostume", costumeId);
                }

                PlayerPrefs.Save(); // 저장됨

                Debug.Log($"[Save] Player {playerIndex} → '{costumeId}' 저장됨");
            }

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

            Debug.Log($"[Change] Player {playerIndex} 선택됨");
        }
    }
    void Start()
    {
        ApplyCostumePreview(0, CostumeData.fireCostumeId);
        ApplyCostumePreview(1, CostumeData.iceCostumeId);
    }

    private void ApplyCostumePreview(int playerIndex, string costumeId)
    {
        Sprite costumeSprite = costumeId == "Nothing"
            ? null
            : Resources.Load<Sprite>($"Costumes/{costumeId}");

        if (playerIndex == 0)
        {
            fireCostumeLayerImage.sprite = costumeSprite;
            fireCostumeLayerImage.enabled = costumeSprite != null;
        }
        else if (playerIndex == 1)
        {
            iceCostumeLayerImage.sprite = costumeSprite;
            iceCostumeLayerImage.enabled = costumeSprite != null;
        }
    }
    public void OnCostumeButtonClicked(string costumeId)
    {
        if (!isChanging)
        {
            Debug.Log(" 먼저 'Change' 버튼을 누르세요.");
            return;
        }

        currentSelections[selectedPlayerIndex] = costumeId;

        Sprite costumeSprite = costumeId == "Nothing"
            ? null
            : Resources.Load<Sprite>($"Costumes/{costumeId}");

        if (selectedPlayerIndex == 0)
        {
            fireCostumeLayerImage.sprite = costumeSprite;
            fireCostumeLayerImage.enabled = costumeSprite != null;
        }
        else if (selectedPlayerIndex == 1)
        {
            iceCostumeLayerImage.sprite = costumeSprite;
            iceCostumeLayerImage.enabled = costumeSprite != null;
        }

        Debug.Log(costumeId == "Nothing"
            ? $"Player {selectedPlayerIndex}의 코스튬이 제거되었습니다."
            : $"Player {selectedPlayerIndex}가 '{costumeId}' 코스튬을 입었습니다.");
    }

    private void SetButtonText(TMP_Text textComponent, string value)
    {
        textComponent.text = value;
    }
}
