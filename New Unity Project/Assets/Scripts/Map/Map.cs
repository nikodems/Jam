using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseControls();
    }

    private void MouseControls()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Which layers to hit
            int layerMask = 1 << 14;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

            print("bbb");

            if (hit.collider != null)
            {
                SceneManager.LoadSceneAsync("ExhibitOne");
            }
        }
    }
}
