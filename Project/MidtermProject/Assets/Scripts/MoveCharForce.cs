using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharForce : MonoBehaviour
{
    Vector2 newPos;

    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        newPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(+speed, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
        }
    }
}
