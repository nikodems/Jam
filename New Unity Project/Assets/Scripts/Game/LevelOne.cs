using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{
    public Camera camera;

    bool heldDown;
    // Start is called before the first frame update
    void Start()
    {
        heldDown = false;

        //Scene game = SceneManager.LoadSceneAsync("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!heldDown)
            {
                print("a");
                int layerMask = 1 << 8;

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if(hit.collider != null)
                {
                    print(hit.collider.ToString());
                    SceneManager.LoadSceneAsync("Game");
                }
                //Ensure code runs only once a mouse click
                heldDown = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            heldDown = false;
        }
    }
}

