using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float speed = 0.5f;
    public IEnumerator MoveAI(Transform nextPosition)
    {
        while (Vector3.Distance(nextPosition.position, transform.position) > 0.001f)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, step);
            yield return null;
        }

        transform.position = nextPosition.position;
        transform.rotation = nextPosition.rotation;

    }
}

