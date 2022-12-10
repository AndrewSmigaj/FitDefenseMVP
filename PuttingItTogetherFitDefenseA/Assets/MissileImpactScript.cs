using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileImpactScript : MonoBehaviour
{

    public GameObject explosionPrefab;

    public GameObject smokePrefab;

    public ParticleSystem smokeVFX = null;

    public int hitCount = 0;
    //we want to update a collected score for buildings.  Mostly designed in for cars and residential areas where there are multiple residential buildings to target, without having too many damage scores.

    public GameObject buildingDamageObject = null;

    public int damageAmount = -10;
    void Start()
    {
        GameObject smoke = Instantiate(smokePrefab, this.transform.position, this.transform.rotation);

        smokeVFX = smoke.GetComponent<ParticleSystem>();

        smokeVFX.Pause();
        smokeVFX.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Missile")
        {

            hitCount += 1;

            if(hitCount == 1)
            {
                smokeVFX.Play();
            }
            Instantiate(explosionPrefab, transform.position, transform.rotation);

            buildingDamageObject.GetComponent<BuildingDamage>().AdjustDamage(damageAmount);
            Destroy(other.gameObject);
        }

    }
}
