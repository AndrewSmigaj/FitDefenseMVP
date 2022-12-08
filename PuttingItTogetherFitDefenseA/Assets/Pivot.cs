using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    public Transform railSystemPivot;
    public Transform HUDPivot;
    public GameObject dialogue;
    public MissileSpawning missilesSpawning = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator PivotDirection()
    {

        dialogue.SetActive(true);

        missilesSpawning.isLaunchingMissiles = false;
        //dialogue trigger

        yield return new WaitForSeconds(3);

        missilesSpawning.isLaunchingMissiles = true;
        dialogue.SetActive(false);

        railSystemPivot.transform.Rotate(new Vector3(0, 180, 0));
        HUDPivot.transform.Rotate(new Vector3(0, 180, 0));
        //missilesSpawning.isLaunchingMissiles = true;
    }
}
