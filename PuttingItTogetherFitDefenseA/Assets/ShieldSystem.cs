using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject slider = null;
    public TMPro.TextMeshProUGUI numericDisplay = null;

    public float currentAmount = 0;
    public float maxAmount = 930;


    public AdjustableParameters adjustableParameters = null;

    Coroutine shieldRechargeCoroutine = null;

    public RectTransform sliderFill = null;

    void Start()
    {
        //StartRecharging();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRecharging()
    {
        shieldRechargeCoroutine = StartCoroutine(ShieldRecharge());
    }

    public void StopRecharging()
    {
        StopCoroutine(shieldRechargeCoroutine);
    }

    IEnumerator ShieldRecharge()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            while (currentAmount <= maxAmount)
            {
                currentAmount += adjustableParameters.shieldRechargeAmount;
                numericDisplay.text = currentAmount.ToString() + "/" + maxAmount.ToString();

                sliderFill.sizeDelta = new Vector2(currentAmount, 0);

                yield return new WaitForSeconds(1);
            }


        }
    }
}
