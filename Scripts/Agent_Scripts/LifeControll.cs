using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeControll : MonoBehaviour
{
    public Animator playerAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Traphole")
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (collision.tag == "Finish")
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "EnemyBody")
        {
            deathAnimation();
            StartCoroutine(gameOver());
        }
    }

    private void deathAnimation()
    {
        playerAnimator.SetBool("jump", false);
        playerAnimator.SetBool("idle", false);
        playerAnimator.SetBool("walk", false);
        playerAnimator.SetBool("death", true);

    }

    IEnumerator gameOver ()
    {
        yield return new WaitForSeconds(1.04f);
        SceneManager.LoadScene("SampleScene");
    }


}
