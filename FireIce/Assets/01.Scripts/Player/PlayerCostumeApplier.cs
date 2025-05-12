using UnityEngine;

public class PlayerCostumeApplier : MonoBehaviour
{
    public SpriteRenderer costumeLayer; // 몸 위에 붙는 레이어
    public bool isFirePlayer;

    void Start()
    {
        string costumeId = isFirePlayer
            ? CostumeData.fireCostumeId
            : CostumeData.iceCostumeId;

        Debug.Log($"[{gameObject.name}] 코스튬 ID: {costumeId}");

        if (costumeId != "Nothing")
        {
            Sprite costumeSprite = Resources.Load<Sprite>($"Costumes/{costumeId}");
            if (costumeSprite != null)
            {
                costumeLayer.sprite = costumeSprite;
            }
        }
        else
        {
            costumeLayer.enabled = false;
        }
    }
}
