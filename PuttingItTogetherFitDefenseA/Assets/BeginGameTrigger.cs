using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGameTrigger : MonoBehaviour
{
    public Canvas canvas = null;

    public GameScript script = null;

    public bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Start button triggered");

        canvas.enabled = false;

        if (!isRunning)
        {
            isRunning = true;
            StartCoroutine(script.RunGameScript());
        }
    }
}
