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

    public List<Transform> side2Targets = new List<Transform>();

    public GameObject dialogue = null;
    public TMPro.TextMeshProUGUI dialogueTextbox = null;
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
        dialogueTextbox.text = "Hello and  welcome to your station! Since this is your first day let's review a few things from the manual.";
        yield return new WaitForSeconds(5);





        dialogueTextbox.text = "It looks like the enemy is targetting so I guess we will throw you right in.  If you don't recall basic training for now just hit them!";

        audioModule.StartMusic();
        audioModule.StartSamples();

        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(0, side1Targets[3]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(1, side1Targets[2]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(2, side1Targets[1]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(3, side1Targets[0]);





        yield return new WaitForSeconds(3);


        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = true;

        yield return new WaitForSeconds(3);

        dialogue.SetActive(false);

        yield return new WaitForSeconds(10);

        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = false;

        yield return new WaitForSeconds(3);

        dialogueTextbox.text = "They are retargeting.  Ready to mix things up?";

        dialogue.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(0, side1Targets[0]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(1, side1Targets[1]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(2, side1Targets[2]);
        yield return new WaitForSeconds(0.5f);
        spawning.GetComponent<MissileSpawning>().SetTarget(3, side1Targets[3]);
        yield return new WaitForSeconds(3f);

        dialogue.SetActive(false);


        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = true;



        yield return new WaitForSeconds(5);

        dialogue.SetActive(false);



        yield return new WaitForSeconds(12);

        //spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = false;

        audioModule.StopSamples();
        //superbomb


        dialogueTextbox.text = "Our munitions factory constructed a new superbomb!  Punch out to the left and right at the same time to activate (placeholder).  A wave is coming so use it wisely!";

        

        dialogue.SetActive(true);


        yield return new WaitForSeconds(5);

        dialogue.SetActive(false);


        //spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = ;

        yield return StartCoroutine(WaveForSuperbomb());


        yield return new WaitForSeconds(2);

        audioModule.StartSamples();

        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = true;


        yield return new WaitForSeconds(5);

        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = false;

        yield return new WaitForSeconds(1);

        dialogueTextbox.text = "They are changing targets again.  They are shooting past you at the residential area!!";

        dialogue.SetActive(true);

        yield return new WaitForSeconds(1);

        spawning.GetComponent<MissileSpawning>().SetTarget(0, side2Targets[0]);

        spawning.GetComponent<MissileSpawning>().SetTarget(1, side2Targets[2]);

        spawning.GetComponent<MissileSpawning>().SetTarget(2, side2Targets[4]);

        spawning.GetComponent<MissileSpawning>().SetTarget(3, side2Targets[6]);

        //target residential
        spawning.GetComponent<MissileSpawning>().isLaunchingMissiles = true;


        //random targeting
        yield return new WaitForSeconds(5);

        dialogue.SetActive(false);



        yield return new WaitForSeconds(8);

        dialogueTextbox.text = "Looks like they are moving around behind us!  When you see the 'behind you' alert turn around to face the other way.";

        dialogue.SetActive(true);

        yield return new WaitForSeconds(4);

        StartCoroutine(pivotSystem.PivotDirection());

        for (int i = 0; i < 10; i++)
        {
            spawning.GetComponent<MissileSpawning>().SetTarget(Random.Range(0, 3), side2Targets[Random.Range(0, 7)]);

            yield return new WaitForSeconds(2);

        }

        //here is where we can set up rail targets for now

    }




    IEnumerator WaveForSuperbomb()
    {
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.3f);

            spawning.GetComponent<MissileSpawning>().LaunchMissile(0);
            spawning.GetComponent<MissileSpawning>().LaunchMissile(1);
            spawning.GetComponent<MissileSpawning>().LaunchMissile(2);
            spawning.GetComponent<MissileSpawning>().LaunchMissile(3);


        }
    }

}
