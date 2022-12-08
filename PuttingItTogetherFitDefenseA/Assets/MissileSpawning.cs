using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawning : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] missileSpawners = new GameObject[4];
    public GameObject missilePrefab;

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
    }










    //retarget


}
