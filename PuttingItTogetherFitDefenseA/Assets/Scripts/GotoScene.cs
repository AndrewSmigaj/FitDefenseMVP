using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GotoScene : MonoBehaviour
{

    public SceneUtils.SceneId nextScene = SceneUtils.SceneId.Lobby;


    public void LoadSceneWithSceneLoader(SelectEnterEventArgs args)
    {
        Debug.Log("Entering scene gotoer");
        SceneLoader.Instance.ChangeScene(SceneUtils.scenes[(int)nextScene]);
    }
}
