using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperbombGesturePrototypeScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject other;
    public GameObject shockWave;

    public Transform shockWavePosition = null;

    public bool isTriggered;

    public bool fireShockwave = true;

    public float rechargeTime = 120;
    public float currentTime = 0;


    public AdjustableParameters parameters = null;

    public int currrentSBCount = 0;

    public TMPro.TextMeshProUGUI superbombCountTextbox = null;
    public RectTransform superBombSlider = null;


    void Start()
    {
        StartCoroutine(Recharge());
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && other.GetComponent<SecondSuperbombTriggerzoneScript>().isTriggered && currrentSBCount >= 1)
        {
            Debug.Log("Got to trigger shockwave.");
            fireShockwave = false;
            currrentSBCount -= 1;

            superbombCountTextbox.text = currrentSBCount.ToString();


            Instantiate(shockWave, shockWavePosition.position, shockWavePosition.rotation); 

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        Debug.Log("First Zone Triggered");

    }

    private void OnTriggerExit(Collider other)
    {

        isTriggered = false;
    }


    IEnumerator Recharge()
    {
        while (true)
        {
            while (currentTime < rechargeTime)
            {
                currentTime += 0.1f * parameters.superbombConstructionAmount;




                superBombSlider.sizeDelta = new Vector2(currentTime * 3, 0);

                yield return new WaitForSeconds(0.1f);
            }
            currentTime = 0;
            currrentSBCount += 1;
            superbombCountTextbox.text = currrentSBCount.ToString();

            fireShockwave = true;
        }



    }

    


    
}
