using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBonusDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    public BuildingDamage buildingDamage = null;

    public GameObject bonusDisplay = null;

    public AdjustableParameters paramsToAdjust = null;

    public float bonusThresholdToActivate = 0.5f;

    public string paramName = "";

    public bool bonusOn = true;

    void Start()
    {
        StartCoroutine(UpdateBonus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator UpdateBonus()
    {

        while (true)
        {

            if (bonusOn)
            {
                if((buildingDamage.currentDamage / (float) buildingDamage.maxDamage) < bonusThresholdToActivate)
                {
                    bonusOn = false;
                    bonusDisplay.SetActive(false);
                }
            }
            else
            {
                if ((buildingDamage.currentDamage / (float) buildingDamage.maxDamage) >= bonusThresholdToActivate)
                {
                    bonusOn = true;
                    bonusDisplay.SetActive(true);
                }
            }


            yield return new WaitForSeconds(1f);


        }



    }
}
