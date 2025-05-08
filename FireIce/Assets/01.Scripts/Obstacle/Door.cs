using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Door : MonoBehaviour, ISwitchActive
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private GameObject doorObj;
    [SerializeField] private float time = 5;

    private Coroutine doorMoveCoroutine;
    public void Active()
    {
        if(doorMoveCoroutine != null)
            StopCoroutine(doorMoveCoroutine);

        doorMoveCoroutine = StartCoroutine(DoorActive_Cor(targetPos.position));
        Debug.Log("Open_Door");
    }

    public void Deactive()
    {
        if (doorMoveCoroutine != null)
            StopCoroutine(doorMoveCoroutine);

        doorMoveCoroutine = StartCoroutine(DoorActive_Cor(transform.position));
        Debug.Log("Close_Door");
    }

    private IEnumerator DoorActive_Cor(Vector2 pos)
    {
        float time = 0;
        
        while(time < this.time)
        {
            doorObj.transform.position = Vector2.Lerp(doorObj.transform.position, pos, time / this.time);
            time += Time.deltaTime;
            yield return null;
        }
    }

}
