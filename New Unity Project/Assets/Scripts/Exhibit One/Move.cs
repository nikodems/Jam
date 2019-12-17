using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    public Camera camera;

    bool heldDown;

    // Start is called before the first frame update
    void Start()
    {
        heldDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetMouseButton(0))
        //{
        //    MouseToScreen();
        //}
    }

    void OnGUI()
    {
        if (Input.GetMouseButton(0))
        {
            if (!heldDown)
            {
                //Vector2 mousePos = new Vector2();
                //Vector3 point = new Vector3();
                //Event currentEvent = Event.current;

                //mousePos.x = currentEvent.mousePosition.x;
                //mousePos.y = camera.pixelHeight - currentEvent.mousePosition.y;

                //point = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 4.7f));

                ////gameObj.transform.position = point;

                //print("P: " + point);
                //print("S: " + camera.pixelWidth + ", " + camera.pixelHeight);

                //Get ray from mouse position
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                //Create a layermask for the 8th layer
                //Ray will only collide with objects in this layer
                int layerMask = 1 << 8;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    print("TRUE");
                    print(hit.collider.ToString());

                    SceneManager.LoadSceneAsync("LevelOne");
                }

                print("a");
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
