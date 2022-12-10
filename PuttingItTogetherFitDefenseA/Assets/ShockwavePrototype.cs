using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwavePrototype : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxScale = 10;
    public float currentScale = 1;

    public GameObject explosionPrefab;
    void Start()
    {
        StartCoroutine(testShockwaveLogic());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator testShockwaveLogic()
    {
        while(currentScale < maxScale)
        {
            currentScale += 0.3f;

            this.transform.localScale = Vector3.one * currentScale;
            yield return new WaitForSeconds(0.025f);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Missile"){


            Instantiate(explosionPrefab, other.transform.position, other.transform.rotation);

            //buildingDamageObject.GetComponent<BuildingDamage>().AdjustDamage(damageAmount);
            Destroy(other.gameObject);
        }
    }


}
