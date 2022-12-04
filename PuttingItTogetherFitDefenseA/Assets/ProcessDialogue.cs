using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessDialogue : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject nextDialogueZone = null;
    public bool onboardingFinished = false;
    public string nextRaycastTarget = "";

    public GameObject AIDrone = null;


    void Start()
    {
        StartCoroutine(BeginOnboarding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BeginOnboarding()
    {
        while (!onboardingFinished)
        {

            //replace


            //get dialogue and next location
            DialogueData nodeData = nextDialogueZone.GetComponent<DialogueData>();




            Transform nextLocation = nodeData.AILocation;

            Debug.Log(nextLocation);


            //move 




            yield return StartCoroutine(AIDrone.GetComponent<AIMovement>().MoveAI(nextLocation));
            //raycast here


            nextRaycastTarget = nextDialogueZone.tag;

            yield return StartCoroutine(RayCastCheckForNextOnboardingFocus(nextRaycastTarget));

            if (nodeData.hasAdditionalActions)
            {
                nodeData.dialogueProcessed?.Invoke(true);
            }
            nodeData.dialogueCanvas.enabled = true;
            //nextDialogueZone.GetComponent<Canvas>().enabled = true;
            nodeData.dialogueTextBox.text = nodeData.dialogue;



            yield return new WaitForSeconds(nodeData.dialogueDuration);


            //nodeData.dialogueTextBox.enabled = false;
            nodeData.dialogueCanvas.enabled = false;

            //do this when at last tag



            //move to next location
            if (!nodeData.isLast)
            {
                nextDialogueZone = nodeData.nextDialogueZone;
            }
            else
            {
                onboardingFinished = true;
            }

            //set new tag for raycast and dialogue and nextlocation lookup




        }
    }

    public IEnumerator RayCastCheckForNextOnboardingFocus(string nextZoneTag)
    {
        bool rayCastSuccess = false;
        while (!rayCastSuccess)
        {



            yield return new WaitForSeconds(0.25f);

            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.transform.tag == nextZoneTag)
                {
                    Debug.Log("hitting next onboarding zone");
                    rayCastSuccess = true;
                }
                Debug.Log(hit.transform.tag);
                Debug.DrawRay(ray.origin, ray.direction * 5, Color.red);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 5);
            }

        }
    }



}
