using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonFollow : MonoBehaviour
{
    // To be reviewed 
    public Transform player;
    public Canvas back;
    public Vector3 offset;
    void Update()
    {
        back.GetComponent<RectTransform>().anchoredPosition3D = offset + player.position;
        // back.transform.z = player.position.z + offset.z;

    }
}
