using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDamage : MonoBehaviour
{
    // buildings impact a collected damage score.  Mostly for residential and cars because there are multiple ones and I don't want to have bonuses for each.

    public int maxDamage = 100;
    public int currentDamage = 100;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AdjustDamage(int damageAmount)
    {
        currentDamage += damageAmount;
    }

}
