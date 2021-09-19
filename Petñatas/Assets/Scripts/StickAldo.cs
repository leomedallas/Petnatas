using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAldo : MonoBehaviour
{

    public float speedMovement;
    public Rigidbody2D rbody;
    public SpriteRenderer sprRenderer;
 
    public static GameObject _stick;

    private void Start()
    {
        _stick = GameObject.Find("Stick");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.GetComponent<PlayerAldo>().canThrow = true;
            //Player.canThrow = true;
            _stick.SetActive(false);
        }
       
    }
}
