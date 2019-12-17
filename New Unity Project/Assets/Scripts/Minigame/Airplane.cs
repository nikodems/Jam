using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public GameObject bombPrefab;
    GameObject bomb;

    public GameController gameController;

    Vector3 moveX = new Vector3(7.5f, 0.0f, 0.0f);
    Vector3 moveY = new Vector3(0.0f, 7.5f, 0.0f);

    float rotationZ = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Flip the sprite in the x-axis
        this.gameObject.GetComponent<SpriteRenderer>().flipX = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameController.GameOver() && gameController.GameStart())
        {
            PlayerControls();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Destroy(this.gameObject);
    }

    private void PlayerControls()
    {
            if (Input.GetKey("left"))
            {
                //Move
                this.gameObject.transform.position -= (moveX * Time.deltaTime);

                //If it hasn't been flipped, flip it
                if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }

            }
            if (Input.GetKey("right"))
            {
                //Move
                this.gameObject.transform.position += (moveX * Time.deltaTime);

                //If it hasn't been flipped, flip it
                if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
            }
            if (Input.GetKey("up"))
            {
                //Move
                this.gameObject.transform.position += (moveY * Time.deltaTime);

                //if(this.gameObject.transform.eulerAngles.z - 360.0f < 45.0f || this.gameObject.transform.eulerAngles.z == 0.0f)
                //  {
                //      rotationZ += 0.1f;

                //      if(rotationZ < 45.0f)
                //      {
                //          this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ));
                //      }
                //      else if(rotationZ > 45.0f)
                //      {
                //          rotationZ = 45.0f;
                //      }
                //  }

                print(gameObject.transform.localEulerAngles);
            }
            if (Input.GetKey("down"))
            {
                //Move
                this.gameObject.transform.position -= (moveY * Time.deltaTime);


                //if(this.gameObject.transform.eulerAngles.z - 360.0f > -45.0f || this.gameObject.transform.eulerAngles.z == 0.0f)
                // {
                //     rotationZ -= 0.1f;

                //     if(rotationZ >= -45.0f)
                //     {
                //         this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ));
                //     }
                //     else if(rotationZ < -45.0f)
                //     {
                //         rotationZ = -45.0f;
                //     }
                // }
                print(gameObject.transform.localEulerAngles);
            }
            if (Input.GetKeyDown("space"))
            {
                //Spawn bomb
                bomb = Instantiate(bombPrefab, this.gameObject.transform.position + new Vector3(0.0f, -0.5f, 0.0f), Quaternion.identity);

                if (this.gameObject.GetComponent<SpriteRenderer>().flipX)
                {
                    bomb.GetComponent<Bomb>().FlipSprite();
                }
            }
    }

    private void RotateDown()
    {
        if (this.gameObject.transform.eulerAngles.z - 360.0f > -45.0f || this.gameObject.transform.eulerAngles.z == 0.0f)
        {
            rotationZ -= 0.1f;

            if (rotationZ >= -45.0f)
            {
                this.gameObject.transform.Rotate(new Vector3(0.0f, 0.0f, rotationZ));
            }
            else if (rotationZ < -45.0f)
            {
                rotationZ = -45.0f;
            }
        }

        if (!this.gameObject.GetComponent<SpriteRenderer>().flipX)
        {
            if (this.gameObject.transform.eulerAngles.z < 45.0f)
            {

            }
        }
    }


    public bool IsFlip()
    {
        return this.gameObject.GetComponent<SpriteRenderer>().flipX;
    }
}
