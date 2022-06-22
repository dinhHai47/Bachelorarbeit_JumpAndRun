using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public SpriteRenderer sprite;

    public float right_speed = 1f;
    public float left_speed = -1f;

    bool rightWalk = true;


   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(walkCoroutine());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (rightWalk)
        {
            rigidbody2D.transform.position += new Vector3(right_speed, 0f, 0f) * Time.deltaTime;
        }
        else
        {
            rigidbody2D.transform.position += new Vector3(left_speed, 0f, 0f) * Time.deltaTime;
        }
    }

    IEnumerator walkCoroutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(4f);
            rightWalk = !rightWalk;
            sprite.flipX = !rightWalk;
        }
    }
}
