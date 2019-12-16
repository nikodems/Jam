using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{
    public Camera camera;

    List<GameObject> activeTextBox = new List<GameObject>();

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
                //print("a");
                int layerMask = 1 << 8;

                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if(hit.collider != null)
                {
                    if (!activeTextBox.Contains(hit.collider.gameObject))
                    {
                        print(hit.collider.ToString());
                        hit.collider.gameObject.GetComponent<PlanePart>().ShowTextBox();
                        activeTextBox.Add(hit.collider.gameObject);
                    }
                    else
                    {
                        activeTextBox.Remove(hit.collider.gameObject);

                        hit.collider.gameObject.GetComponent<PlanePart>().HideTextBox();
                    }
                    //SceneManager.LoadSceneAsync("Game");
                }

                layerMask = 1 << 9;

                hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if(hit.collider != null)
                {
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

