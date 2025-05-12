using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour, IObstacleActive
{
    [field: SerializeField] public bool IsActive { get; set; } = false; // 텔레포트 오브젝트의 작동 여부

    [Tooltip("텔레포트할 상대")]
    public Teleporter teleporter;

    [Tooltip("텔레포트 대기 시간")]
    public float cooldown = 0.5f;
    private bool canTeleport = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 텔레포트 작동 여부
        if (IsActive == false || teleporter.IsActive == false)
            return;

        // 텔레포트 대기 시간 여부
        if (canTeleport == false || teleporter.canTeleport == false)
            return;

        // 플레이어 확인
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine(TeleportActvie(collision.transform)); // 텔레포트 처리 코루틴 실행
    }

    private IEnumerator TeleportActvie(Transform player)
    {
        // 무한 루프 방지를 위해 양쪽 텔레포터 비활성화
        canTeleport = false;
        teleporter.canTeleport = false;

        // 플레이어 위치를 목적지 위치로 순간 이동
        player.position = teleporter.transform.position;

        // 지정한 쿨다운 시간만큼 대기
        yield return new WaitForSeconds(cooldown);

        // 다시 사용 가능으로 전환
        canTeleport = true;
        teleporter.canTeleport = true;
    }
}
