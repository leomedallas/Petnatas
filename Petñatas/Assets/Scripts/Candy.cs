using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [Header("Candy Random Splash")]
    public Transform objTransform;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 1.8f;
    private Vector3 off;

    public enum pickupObject { CANDY, STICK };
    public pickupObject currentObject;
    public int pickupQuantity;


    void Update()
    {
        if (when >= delay)
        {
            pasttime = Time.deltaTime;

            objTransform.position += off * Time.deltaTime;
            delay += pasttime;
            if (objTransform.position.x > 0)
                transform.Rotate(new Vector3(0, 0, 2));
            else
                transform.Rotate(new Vector3(0, 0, -2));
        }
    }
    public void Awake()
    {
        //Random for x
        off = new Vector3(Random.Range(-1.8f, 1.8f), off.y, off.z);
        //Random for y
        off = new Vector3(off.x, Random.Range(-1.8f, 1.8f), off.z);
    }
    //Method for the player get candies.
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentObject == pickupObject.CANDY)
            {
                other.GetComponent<PlayerAldo>().candies += pickupQuantity;
                Debug.Log(other.GetComponent<PlayerAldo>().candies);
            }

            Destroy(gameObject);
        }
    }
}
