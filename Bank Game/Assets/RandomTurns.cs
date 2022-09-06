using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTurns : MonoBehaviour
{
    float smooth = 10.0f;
    public Transform player;
    
    private void Start(){
        StartCoroutine(StartNow());
    }
    private IEnumerator StartNow(){
        yield return new WaitForSeconds(2f);
        StartCoroutine(UpdateAlways());
    }
    private IEnumerator UpdateAlways()
    {
        float tiltAroundY = Random.Range(0,180);
        Quaternion target = Quaternion.Euler(0,tiltAroundY,0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
        yield return new WaitForSeconds(1f);
        StartCoroutine(StartNow());
    }
}
