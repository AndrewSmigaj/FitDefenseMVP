using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEditor;

public static class SceneMenu
{
    [MenuItem("Scenes/Lobby")]
    public static void OpenLobby()
    {
        OpenScene(SceneUtils.Names.lobby);
    }

    [MenuItem("Scenes/Bunker")]
    public static void OpenMaze()
    {
        OpenScene(SceneUtils.Names.bunker);
    }

    [MenuItem("Scenes/Game")]
    public static void OpenGame()
    {
        OpenScene(SceneUtils.Names.game);
    }



    public static void OpenScene(string name)
    {


        Scene persistent = EditorSceneManager.OpenScene("Assets/Scenes/" + SceneUtils.Names.xRRigPersistentName + ".unity", OpenSceneMode.Single);

        //see what happens when we fade here



        Scene current = EditorSceneManager.OpenScene("Assets/Scenes/" + name + ".unity", OpenSceneMode.Additive);
        SceneUtils.AlignXRRig(persistent, current);
    }


}
