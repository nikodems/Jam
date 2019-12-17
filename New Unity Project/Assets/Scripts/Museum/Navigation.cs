using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    bool heldDown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!heldDown)
            {
                int layerMask = 1 << 16;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if (hit.collider != null)
                {
                    SceneManager.LoadSceneAsync("Map");
                }

                layerMask = ~layerMask;

                hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

               
                if (hit.collider != null)
                {
                    SceneManager.LoadSceneAsync("ExhibitOne");
                }
                heldDown = true;
            }
        }
        else
        {
            heldDown = false;
        }
    }
}
