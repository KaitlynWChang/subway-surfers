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

    delegate void MultiDelegate();
    MultiDelegate updatePoints;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        playerAnim = GetComponent<Animator>();
        updatePoints += IncrementPoints;
        updatePoints += DisplayPoints;
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
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            updatePoints();
            Destroy(collision.gameObject);
        }
    }

    public void IncrementPoints()
    {
        Points.Instance.point++;
    }

    public void DisplayPoints()
    {
        Debug.Log("Points: " + Points.Instance.point);
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
