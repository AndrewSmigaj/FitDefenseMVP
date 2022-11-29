using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransistionTriggering : MonoBehaviour
{

    public SceneUtils.SceneId nextScene = SceneUtils.SceneId.Lobby;
    public bool alreadyLoading = false;

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
        if(other.tag == "Pen" && !alreadyLoading)
        {
            alreadyLoading = true;
            SceneLoader.Instance.ChangeScene(SceneUtils.scenes[(int)nextScene]);

        }
    }
}
