using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SnapScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public List<RectTransform> snapTargets; // 버튼들 (각 맵)
    public float snapSpeed = 10f;

    private bool isDragging = false;
    private int nearestIndex;

    void Update()
    {
        if (!isDragging)
        {
            SnapToNearest();
        }

        HighlightSelected();
    }

    void SnapToNearest()
    {   //MaxValue를 해야하는 이유는 저게 float에서 제일 큰 수인데 딱 처음 들어갔을 때도 저게 적용이 되어야하니 처음부터 함수가 성립할 수 있도록 거리를 잡아주는 것.
        float closestDistance = float.MaxValue;
        int closestIndex = 0;

        //모든 버튼들과 Viewport의 X좌표 차이를 비교
        for (int i = 0; i < snapTargets.Count; i++)
        {
            float distance = Mathf.Abs(scrollRect.viewport.position.x - snapTargets[i].position.x);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        nearestIndex = closestIndex;
        //Viewport 중심에서 선택된 버튼이 얼마나 오른쪽/왼쪽으로 벗어났는지 계산
        //차이만큼 content를 반대로 이동 (world 기준)
        float offset = snapTargets[nearestIndex].position.x - scrollRect.viewport.position.x;
        Vector2 targetPosition = contentPanel.anchoredPosition - new Vector2(offset, 0f);
        //현재 위치에서 목표 위치까지 부드럽게 이동
        contentPanel.anchoredPosition = Vector2.Lerp(contentPanel.anchoredPosition, targetPosition, Time.deltaTime * snapSpeed);
    }
    void HighlightSelected()
    {   
        for (int i = 0; i < snapTargets.Count; i++)
        {
            //각 버튼이 현재 선택된 버튼인지 확인
            bool isSelected = (i == nearestIndex);
            //선택된 버튼은 1.5배 확대, 나머지는 원래 크기(1.0)
            Vector3 targetScale = isSelected ? Vector3.one * 1.5f : Vector3.one;
            //현재 크기에서 목표 크기로 천천히 변화시킴
            snapTargets[i].localScale = Vector3.Lerp(snapTargets[i].localScale, targetScale, Time.deltaTime * 10f);
        }
    }

    public void OnBeginDrag()
    {
        isDragging = true;
    }

    public void OnEndDrag()
    {
        isDragging = false;
    }
}
