using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOne : MonoBehaviour
{
    public Camera cam;

    List<GameObject> activeTextBox = new List<GameObject>();

    public GameObject[] planeParts = new GameObject[4];

    bool heldDown;
    bool click;

    int arraySelector = 0;
    // Start is called before the first frame update
    void Start()
    {
        heldDown = false;
        click = false;
        

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
                print(planeParts.Length);
                //Raycast for cycle buttons
                int layerMask = 1 << 15;

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if(hit.collider != null)
                {
                    //if (!activeTextBox.Contains(hit.collider.gameObject))
                    //{
                    //    print(hit.collider.ToString());
                    //    hit.collider.gameObject.GetComponent<PlanePart>().ShowTextBox();
                    //    activeTextBox.Add(hit.collider.gameObject);
                    //}
                    //else
                    //{
                    //    activeTextBox.Remove(hit.collider.gameObject);

                    //    hit.collider.gameObject.GetComponent<PlanePart>().HideTextBox();
                    //}
                    if(hit.collider.gameObject.name == "Up")
                    {
                        if (arraySelector < planeParts.Length - 1)
                        {
                            arraySelector += 1;
                        }
                        else if(arraySelector == planeParts.Length - 1)
                        {
                            arraySelector = 0;
                        }
                    }
                    else if(hit.collider.gameObject.name == "Down")
                    {
                        if(arraySelector > 0)
                        {
                            arraySelector -= 1;
                        }
                        else if(arraySelector == 0)
                        {
                            arraySelector = planeParts.Length - 1;
                        }
                    }
                }


                //--------------------------------------
                //Raycast for navigation buttons
                layerMask = 1 << 16;

                hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, layerMask);

                if(hit.collider != null)
                {
                    if (hit.collider.gameObject.name == "Map")
                    {
                        SceneManager.LoadSceneAsync("Museum");
                    }
                    else if(hit.collider.gameObject.name == "Minigame")
                    {
                        SceneManager.LoadScene("Minigame");
                    }
                }

                //--------------------------------

                //Ensure code runs only once a mouse click
                heldDown = true;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            heldDown = false;
        }

        if(Input.GetKeyDown("space"))
        {
            if (!click)
            {
                if (planeParts[arraySelector].GetComponent<PlanePart>().IsTextBoxActive())
                {
                    planeParts[arraySelector].GetComponent<PlanePart>().HideTextBox();
                }
                else
                {
                    planeParts[arraySelector].GetComponent<PlanePart>().ShowTextBox();
                }

                click = true;
            }
        }
        else
        {
            click = false;
        }
    }
}

