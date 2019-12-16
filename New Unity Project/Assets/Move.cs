using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Camera camera;
    public GameObject gameObj;

    // Start is called before the first frame update
    void Start()
    {
        
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
            Vector2 mousePos = new Vector2();
            Vector3 point = new Vector3();
            Event currentEvent = Event.current;

            mousePos.x = currentEvent.mousePosition.x;
            mousePos.y = camera.pixelHeight - currentEvent.mousePosition.y;

            point = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, camera.nearClipPlane));

            gameObj.transform.position = point;

            print("P: " + point);
            print("S: " + camera.pixelWidth + ", " + camera.pixelHeight);
        }
    }
}
