using UnityEngine;

public interface IObstacleActive // ��ֹ� Ȱ��ȭ
{
    public bool IsActive { get; set; }

    public void IsActiveTrue();

    public void IsActiveFalse();

}
