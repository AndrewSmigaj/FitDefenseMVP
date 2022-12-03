using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenBehavior : MonoBehaviour
{

    public Light light = null;
    public Material onMaterial = null;
    public Material offMaterial = null;
    public MeshRenderer hologramMesh = null;


    // Start is called before the first frame update
    void Start()
    {
        //SetSirenState(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SirenDelayThenFire(bool on)
    {
        yield return new WaitForSeconds(2);
        if (on)
        {
            light.color = Color.red;
            List<Material> holoMats = new List<Material>();
            holoMats.Add(onMaterial);
            hologramMesh.materials = holoMats.ToArray();
        }
        else
        {
            light.color = Color.blue;
            List<Material> holoMats = new List<Material>();
            holoMats.Add(offMaterial);
            hologramMesh.materials = holoMats.ToArray();
        }
    }
    public void SetSirenState(bool on)
    {
        StartCoroutine(SirenDelayThenFire(on));
    }
}
