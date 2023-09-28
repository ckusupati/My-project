using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Jump : MonoBehaviour
{
    public Rigidbody2D rb;
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    float jumpTime;
    bool jumping;
    public int Respawn;
    public float delay = 3;
    float timer;
    private float speed;
    private float boostTimer;
    private bool boosting;

    public TextMeshProUGUI boostText;

    private void Start()
    {
        speed = 1;
        boostTimer = 0;
        boosting = false;

        SetBoostText();
    }

    private void Update()
    {
        SetBoostText();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            jumpTime = 0;
        }
        if (jumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount*speed);
            jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }
        timer += Time.deltaTime;
        if (timer > delay)
        {
            speedCheck();
        }
        if (boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 1)
            {
                speed = 1;
                boostTimer = 0;
                boosting = false;

                SetBoostText();
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "SpeedBoost")
        {
            boosting = true;
            speed = 2;
            Destroy(other.gameObject);

        }
    }

    void speedCheck()
    {
        if (rb.velocity.x*2 < 0.1)
        {
            SceneManager.LoadScene(Respawn);
        }
        Debug.Log("Hello!");
    }

    void SetBoostText()
    {
        boostText.text = "Boost : " + boostTimer.ToString("0");
    }
}