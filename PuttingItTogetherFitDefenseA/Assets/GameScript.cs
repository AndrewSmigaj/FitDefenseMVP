using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    public GameObject spawning = null;
    public Pivot pivotSystem = null;
    public AudioProcessing audioModule = null;


    //side one
    public List<Transform> side1Targets = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunGameScript());
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public IEnumerator RunGameScript()
    {


        //set targets  
        spawning.GetComponent<MissileSpawning>().SetTarget(0, side1Targets[0]);
        spawning.GetComponent<MissileSpawning>().SetTarget(1, side1Targets[1]);
        spawning.GetComponent<MissileSpawning>().SetTarget(2, side1Targets[2]);
        spawning.GetComponent<MissileSpawning>().SetTarget(3, side1Targets[3]);

        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = true;

        yield return new WaitForSeconds(3);
        audioModule.StartMusic();
        audioModule.StartSamples();

        yield return new WaitForSeconds(15);

        StartCoroutine(pivotSystem.PivotDirection());


        //here is where we can set up rail targets for now






    }




}
