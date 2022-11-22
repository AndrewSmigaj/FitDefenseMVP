using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CrossSceneRefs
{
    // Start is called before the first frame update
    private static GameObject xrRigPers;

    public static GameObject XrRigPers { get => xrRigPers; set => xrRigPers = value; }
}
