using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDisplay : MonoBehaviour
{
    // Start is called before the first frame update

    public string goalText = "";
    public string goalKey = "";

    public TMPro.TextMeshProUGUI descTextBox = null;
    public TMPro.TextMeshProUGUI progressTextbox = null;


    void Start()
    {
        //look up progress, replace with dictionary entries and refactor

        PlayerProgress data = GameObject.FindGameObjectWithTag("PlayerProgress").GetComponent<PlayerProgress>();

        //PLACEHOLDER
        descTextBox.text = goalText;
        progressTextbox.text = data.missilesIntercepted + "/" + data.missileInterceptGoal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
