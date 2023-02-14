using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriangleController : MonoBehaviour
{
    public float speed = 6.0f;

    public GameObject projectilePrefab;//declares the projectile so can attach it to the triangle

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int maxKeys = 3;

    public int health { get { return currentHealth; } }
    public int keys { get { return currentKeys; } }
    int currentHealth;
    public int currentKeys;

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    private Rigidbody2D rb;
    float horizontal;
    float vertical;

    bool knockback = false;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;//resets health on start
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");//stores result of input get axis
        vertical = Input.GetAxis("Vertical");//stores result of input get axis

        Vector2 move = new Vector2(horizontal, vertical);//stores input into a vector

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))//checks x and y aren't 0 using more accurate to store floats
        {
            lookDirection.Set(move.x, move.y);//means if they're not 0 triangle is moving
            lookDirection.Normalize();//makes look direction have length of 1
        }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;//means if invincible timer starts counting down
            if (invincibleTimer < 0)//when timer has run out
                isInvincible = false;//triangle no longer invincible
        }
        if (Input.GetKeyDown(KeyCode.C))//when c key is pressed
        {
            Launch();//calls the launch function
        }

        if (Input.GetKeyDown(KeyCode.X))//when x key is pressed
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 10.0f, LayerMask.GetMask("NPC"));
            /*stores result of a raycast. The 4 arguments are triangle position with extra y axis so it's from the middle, then the direction 
             triangle is looking, max length of raycast and a layer mask so only tests that particular layer*/
            if (hit.collider != null)//if the hit is valid and happens
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)//if character is valid
                {
                    character.DisplayDialog();//calls function from NPC script to display dialogue box
                }
            }
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)//if amount is greater than one meaning there's been a hit
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            // ensures health (first parameter) never goes below 0 (second parameter) and never above the max health (third parameter)
            UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);//sends new values for mask to resize
        }
        if (currentHealth <= 0)//if player runs out of health
        {
            Invoke("GameOver", 1.0f);//waits a second and then calls the game over function
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float bounce = 1200f; //amount of force to apply
        rigidbody2d.AddForce(collision.contacts[0].normal * bounce);//calculates how much knockback occurs
        knockback = true;
        Invoke("noKnockback", 5.0f);//time before returns
    }

    public void ChangeKeys(int amount)
    {
        currentKeys = Mathf.Clamp(currentKeys + amount, 0, maxKeys);
        // ensures keys (first parameter) never goes below 0 (second parameter) and never above the max keys (third parameter)
        UIKeysBar.instance.SetValue(currentKeys / (float)maxKeys);//sends new values for mask to resize
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);
        //copies projectile at position specified, not rotation
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        //launches projectile in direction triangle is looking, second parameter is the force and is high due to it being in newtons
    }

    void noKnockback()
    {
        knockback = false;//ends the knockback
    }

    void GameOver()
    {
        SceneManager.LoadScene("gameOver");//loads game over scene
    }

}
