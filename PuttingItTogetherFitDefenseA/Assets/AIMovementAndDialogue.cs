using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementAndDialogue : MonoBehaviour
{

    public Dictionary<string, Tuple<Transform, string, string>> dict = new Dictionary<string, Tuple<Transform, string, string>>();
    public bool onboardingFinished = false;

    public Transform computerLocation = null;
    public Transform bedLocation = null;

    public string nextRaycastTarget = "onboarding0";

    public TMPro.TextMeshProUGUI dialogueText;
    public Canvas AICanvas;

    public GameObject AIDrone = null;

    public Camera camera = null;

    // Start is called before the first frame update
    void Start()
    {
        //build dict here for now
        dict.Add("onboarding0", new Tuple<Transform, string, string>(computerLocation, "test dialolgue 0", "onboarding1"));
        dict.Add("onboarding1", new Tuple<Transform, string, string>(bedLocation, "test dialolgue 1", "onboardingEnd"));

        StartCoroutine(BeginOnboarding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //we need to wait for raycast targets using tags
    //just wait for seconds for now

    public IEnumerator BeginOnboarding()
    {
        while (!onboardingFinished)
        {


            if (nextRaycastTarget == "onboardingEnd")
            {
                onboardingFinished = true;
                break;
            }


            //get dialogue and next location
            Tuple<Transform, string, string> nextTarget = dict[nextRaycastTarget];

            

            Transform nextLocation = nextTarget.Item1;

            Debug.Log(nextLocation);


            //move 


            dialogueText.enabled = false;
            AICanvas.enabled = false;


            yield return StartCoroutine(MoveAI(nextLocation));
            //raycast here
            nextRaycastTarget = nextTarget.Item3;

            yield return StartCoroutine(RayCastCheckForNextOnboardingFocus(nextRaycastTarget));

            AICanvas.enabled = true;
            dialogueText.enabled = true;
            dialogueText.text = nextTarget.Item2;

            yield return new WaitForSeconds(5);

            //do this when at last tag



            //move to next location

            //set new tag for raycast and dialogue and nextlocation lookup




        }
    }

    public IEnumerator RayCastCheckForNextOnboardingFocus(string nextZoneTag)
    {
        bool rayCastSuccess = false;
        while (!rayCastSuccess)
        {



            yield return null;

            Camera cam = GameObject.FindGameObjectWithTag("CameraContainer").GetComponent<Camera>();

            //Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1f))
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

    public float speed = 0.5f;
    public IEnumerator MoveAI(Transform nextPosition)
    {
        while(Vector3.Distance(nextPosition.position, transform.position) > 0.001f)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, step);
            yield return null;
        }

        transform.position = nextPosition.position;
        transform.rotation = nextPosition.rotation;

    }

}
