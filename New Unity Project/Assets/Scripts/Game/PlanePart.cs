using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePart : MonoBehaviour
{
    public GameObject planePart;
    public GameObject textBox;
    // Start is called before the first frame update
    void Start()
    {
        planePart = this.gameObject;
        textBox = this.gameObject.transform.GetChild(0).gameObject;

        textBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTextBox()
    {
        textBox.SetActive(true);
    }

    public void HideTextBox()
    {
        textBox.SetActive(false);
    }
}
