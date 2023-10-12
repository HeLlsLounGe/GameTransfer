using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 NoPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 HasPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float DestroyDelay = 0.5f;
    bool HasPackage = false;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent < SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OUCH! Was that a bone?!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !HasPackage)
        {
            Debug.Log("Package Picked Up!");
            HasPackage = true;
            spriteRenderer.color = HasPackageColor;
            Destroy(other.gameObject, DestroyDelay);
        }

        if (other.tag == "Customer" && HasPackage)
        {
            Debug.Log("Package Delivered");
            HasPackage = false;
            spriteRenderer.color = NoPackageColor;
            Destroy(other.gameObject, DestroyDelay);
        }
    }
}
