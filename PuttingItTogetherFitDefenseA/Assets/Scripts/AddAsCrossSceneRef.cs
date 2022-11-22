using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAsCrossSceneRef : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        CrossSceneRefs.XrRigPers = this.gameObject;
    }


}
