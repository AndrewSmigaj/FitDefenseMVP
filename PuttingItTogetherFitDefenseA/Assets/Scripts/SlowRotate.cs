using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotate : MonoBehaviour
{
    public float speed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 angles = transform.localEulerAngles;
        angles.y += speed * Time.deltaTime;
        transform.eulerAngles = angles;
    }
}
