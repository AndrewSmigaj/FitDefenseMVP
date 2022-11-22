using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistOnChangeScene : MonoBehaviour
{
    // Start is called before the first frame update

    private int oldLayer;
    private int persistLayer;
    void Awake()
    {
        oldLayer = gameObject.layer;
        persistLayer = LayerMask.NameToLayer("XR Persistent");
    }

    // Update is called once per frame
    public void OnEnable()
    {
        if (SceneLoader.Instance != null)
        {
            //get old layer

            SceneLoader.Instance.onSceneLoadBegin.AddListener(StartPersist);
            SceneLoader.Instance.onSceneLoadEnd.AddListener(EndPersist);

        }
    }


    public void OnDisable()
    {
        if (SceneLoader.Instance != null)
        {
            SceneLoader.Instance.onSceneLoadBegin.RemoveListener(StartPersist);
            SceneLoader.Instance.onSceneLoadEnd.RemoveListener(EndPersist);

        }
    }

    public void StartPersist()
    {
        SetLayer(gameObject, persistLayer);
    }

    public void EndPersist()
    {
        SetLayer(gameObject, oldLayer);
    }

    void SetLayer(GameObject obj, int layer)
    {
        obj.layer = layer;
        foreach(Transform t in obj.transform.GetComponentInChildren<Transform>())
        {
            SetLayer(t.gameObject, layer);
        }
    }


}
