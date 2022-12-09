using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControl : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSlider(float currentAmount)
    {
        this.gameObject.GetComponent<Slider>().UpdateSlider(currentAmount);
    }
}
