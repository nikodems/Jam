using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public GameObject bombPrefab;
    GameObject bomb;

    Vector3 moveX = new Vector3(50.0f, 0.0f, 0.0f);
    Vector3 moveY = new Vector3(0.0f, 50.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        //Flip the sprite in the x-axis
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left"))
        {
            //Move
            this.gameObject.transform.position -= (moveX * Time.deltaTime);

            //If it hasn't been flipped, flip it
            if(this.gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            
        }
        if(Input.GetKeyDown("right"))
        {
            //Move
            this.gameObject.transform.position += (moveX * Time.deltaTime);

            //If it hasn't been flipped, flip it
            if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if(Input.GetKeyDown("up"))
        {
            //Move
            this.gameObject.transform.position += new Vector3(0.0f, 1.0f, 0.0f);
        }
        if (Input.GetKeyDown("down"))
        {
            //Move
            this.gameObject.transform.position += new Vector3(0.0f, -1.0f, 0.0f);
        }
        if(Input.GetKeyDown("space"))
        {
            //Spawn bomb
            bomb = Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Destroy(this.gameObject);
    }
}
