using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{

    public float timer;

    public int newtarget;

    public float speed;

    public NavMeshAgent nav;

    public Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
        nav = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      if(timer >= newtarget)  {
        newTarget();
        timer = 0;
      }
    }
    void newTarget()
    {
        float myY = gameObject.transform.position.y;
        float myZ = gameObject.transform.position.z;

        float yPos = myY + Random.Range(myY - 100,myY + 100);
        float zPos = myZ + Random.Range(myZ - 100,myZ + 100);

        Target = new Vector3(gameObject.transform.position.x,yPos,zPos);

        nav.SetDestination(Target);

    }
}
