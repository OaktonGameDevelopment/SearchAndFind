using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().getDash();
            Destroy(gameObject);
        }
    }
}
// 2:R
