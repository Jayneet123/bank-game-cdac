using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Transform data type stores another object 
    public Transform player;
    // Vector3 stores 3 variables(floats) at once 
    public Vector3 offset;
    void Update()
    {
        // small t transform gives the data of the given player
        transform.position = player.position + offset;

    }
}
