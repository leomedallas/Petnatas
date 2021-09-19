using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAldo : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprRndr;
    public bool isFlip;
    public float runSpeed = 10.0f;
    public GameObject Projectile;
    public Transform parent;
    public bool canThrow = false;
    public int candies = 0;
    public Collider2D player;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRndr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        rb.velocity = new Vector2(0, 0);
        anim.SetBool("IsMoving", false);

        if (Input.GetKey("d") || Input.GetKey("right")) //Move character to the right with arrows and WASD
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            sprRndr.flipX = false;
            isFlip = false;
            anim.SetBool("IsMoving", true);
        }
        if (Input.GetKey("a") || Input.GetKey("left")) //Move character to the left with arrows and WASD
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            sprRndr.flipX = true;
            isFlip = true;
            anim.SetBool("IsMoving", true);
        }
        if (Input.GetKey("w") || Input.GetKey("up")) //Move character to the left with arrows and WASD
        {
            rb.velocity = new Vector2(rb.velocity.x, runSpeed);
            anim.SetBool("IsMoving", true);
            transform.localScale = transform.localScale - new Vector3(0.02f, 0.02f, 0.02f);
        }
        if (Input.GetKey("s") || Input.GetKey("down")) //Move character to the left with arrows and WASD
        {
            rb.velocity = new Vector2(rb.velocity.x, -runSpeed);
            anim.SetBool("IsMoving", true);
            transform.localScale = transform.localScale + new Vector3(0.02f, 0.02f, 0.02f);
        }

        if (canThrow == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                StartCoroutine("Esperar");
                InstatiateStick();
            }
        }
    }

    public void _destroy()
    {
        Destroy(gameObject);
    }

    IEnumerator Esperar()
    {
        player.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        player.GetComponent<Collider2D>().enabled = true;
    }

    void InstatiateStick()
    {
        GameObject go = Instantiate(Projectile, parent);
        go.transform.rotation = Quaternion.identity;
        go.transform.localPosition = Vector3.zero;
        if (isFlip)
        {
            go.GetComponent<StickThrow>().speedMovement *= -1;
        }
        else
        {
            go.GetComponent<StickThrow>().speedMovement *= 1;
        }
        go.GetComponent<StickThrow>().SetUp();
        go.transform.parent = null;
        canThrow = false;
    }
}
