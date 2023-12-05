using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    private float zBound = 4.5f;

    public float speed = 3.0f;
    public float obstacleSpeed = 30.0f;

    private Animator playerAnim;

    public bool gameOver = false;

    public int coolDownTime = 100;

    delegate void MultiDelegate();
    MultiDelegate updatePoints;

    public TMP_Text gameOverText;

    public TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        /*gameOverText = GameObject.Find("Game Over").GetComponent<TMP_Text>();
        scoreText = GameObject.Find("Score").GetComponent<TMP_Text>();*/
        playerAnim = GetComponent<Animator>();
        updatePoints += IncrementPoints;
        updatePoints += DisplayPoints;
        gameOverText.SetText("");
        scoreText.SetText("Score: ");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            scoreText.SetText("Score: " + Points.Instance.point);
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

            if (transform.position.z < -zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
            }

            else if (transform.position.z > zBound)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
            }
        }
    }
  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            gameOverText.SetText("Game Over!");
            scoreText.SetText("Score: " + Points.Instance.point);
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
