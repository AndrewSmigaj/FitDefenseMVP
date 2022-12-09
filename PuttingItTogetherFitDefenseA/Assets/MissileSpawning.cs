using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] missileSpawners = new GameObject[4];
    public GameObject missilePrefab;

    public GameObject targetSignifier = null;

    public List<Transform> targets = new List<Transform>(4);

    public bool isLaunchingMissiles = false;

    void Start()
    {
/*        targets.Add(null);
        targets.Add(null);
        targets.Add(null);
        targets.Add(null);*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchMissile(int spawnIndex)
    {
        if (isLaunchingMissiles)
        {
      
            if(targets[3] != null)
            {
                GameObject nextMissile = Instantiate(missilePrefab, missileSpawners[spawnIndex].transform.position, missileSpawners[spawnIndex].transform.rotation);
                nextMissile.GetComponent<BezierCurveTest>().controlPoints[2] = targets[spawnIndex];
            }

            
        }
    }

    public void SetTarget(int spawnIndex, Transform newTarget)
    {


        targets[spawnIndex] = newTarget;
        StartCoroutine(TargetLocationVisual(newTarget));

    }

    IEnumerator TargetLocationVisual(Transform newTarget)
    {
        GameObject visual = Instantiate(targetSignifier, newTarget.position, newTarget.rotation);

        yield return new WaitForSeconds(1);
        Destroy(visual);
    }










    //retarget


}
