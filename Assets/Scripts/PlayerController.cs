using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 3.0f;
    public float obstacleSpeed = 30.0f;

    private Animator playerAnim;
    private bool isOnGround;

    public bool gameOver = false;

    public int coolDownTime = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            /*if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
            {
                isOnGround = false;
                playerAnim.SetTrigger("Jump");
            }*/
        }
    }
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

    public void CoolDown()
    {
        StartCoroutine(PowerDown());
    }

    IEnumerator PowerDown()
    {
        for (int i = coolDownTime; i >= 0; i --) {
            yield return new WaitForSeconds(.1f);
        }
        Debug.Log("Power up used up!");
    }
}
