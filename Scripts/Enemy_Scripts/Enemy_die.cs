using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_die : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Animator enemyAnimator;
    public Enemy_controller enemy_Controller;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            enemy_Controller.left_speed = 0f;
            enemy_Controller.right_speed = 0f;
            deathAnimation();
            StartCoroutine(enemyDie());
            
        }
    }

    private void deathAnimation()
    {
        enemyAnimator.SetBool("death", true);
    }

    IEnumerator enemyDie()
    {
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(1.04f);
        Destroy(enemy);
    }

}
