using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickThrow : MonoBehaviour
{
    [Header("Throw")]
    public float speedMovement;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
    public float lifetime = 2;
    public float waitTime = 2f;
    float timer;
    public Transform posx;
    public Transform objTransform;

    public enum pickupObject { CANDY, STICK };
    public pickupObject currentObject;
    public GameObject lootDrop;

    void Update()
    {
        
        timer += Time.deltaTime;
        
        if (timer >= waitTime)
        {
            StickAldo._stick.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            Destroy(gameObject);

            timer = 0f;
            StickAldo._stick.SetActive(true);
        }
        
        transform.Rotate(new Vector3(0, 0, -2));
    }
    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        
        if (playerCollider.CompareTag("Player"))
        {
            
            if (currentObject == pickupObject.STICK)
            {
                int i = 0;
                playerCollider.GetComponent<PlayerAldo>()._destroy();
                while (i < playerCollider.GetComponent<PlayerAldo>().candies)
                {
                    Instantiate(lootDrop, transform.position, Quaternion.identity);
                    i++;
                } 
            }
        }
        if (playerCollider.CompareTag("Wall"))
        {
            transform.position = new Vector2(0, 0);
            rbody.velocity = Vector2.zero;
            waitTime = waitTime - 2;
        }
    }
    public void SetUp()
    {
        rbody.velocity = Vector2.right * speedMovement;

        if (rbody.velocity.x < 0)
            sprRenderer.flipX = true;
        else
            sprRenderer.flipX = false;
    }

   

}
