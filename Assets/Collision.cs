using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    [SerializeField] float delay;
    
    bool hasPackage=false;
    SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("You bump into something!");    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag=="Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,delay);
        }
        if (other.tag=="Customer" && hasPackage)
        {
            Debug.Log("Package Delivered!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
