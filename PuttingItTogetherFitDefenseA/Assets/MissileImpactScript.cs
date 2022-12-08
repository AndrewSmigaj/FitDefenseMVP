using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileImpactScript : MonoBehaviour
{

    public GameObject explosionPrefab;

    //we want to update a collected score for buildings.  Mostly designed in for cars and residential areas where there are multiple residential buildings to target, without having too many damage scores.

    public GameObject buildingDamageObject = null;

    public int damageAmount = -10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        buildingDamageObject.GetComponent<BuildingDamage>().AdjustDamage(damageAmount);
        Destroy(other.gameObject);
    }
}
