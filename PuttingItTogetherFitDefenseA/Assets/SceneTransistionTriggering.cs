using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransistionTriggering : MonoBehaviour
{

    public SceneUtils.SceneId nextScene = SceneUtils.SceneId.Lobby;
    public bool alreadyLoading = false;
    public string triggerTag = "";
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
        Debug.Log(other.tag);
        if(other.tag == triggerTag && !alreadyLoading)
        {
            alreadyLoading = true;

            //temporary hack
            if(triggerTag == "Headset")
            {
                GameObject.FindGameObjectWithTag("XRRig").transform.localScale = Vector3.one * 3;
            }
            SceneLoader.Instance.ChangeScene(SceneUtils.scenes[(int)nextScene]);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        alreadyLoading = false;
    }
}
