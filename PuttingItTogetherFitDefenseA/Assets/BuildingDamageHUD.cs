using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDamageHUD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buildingDamageObject = null;
    public TMPro.TextMeshProUGUI textBox = null;

    void Start()
    {
        StartCoroutine(UpdateBuildingHud());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator UpdateBuildingHud()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);

            textBox.text = buildingDamageObject.GetComponent<BuildingDamage>().currentDamage.ToString() + "%";

        }

    }
}
