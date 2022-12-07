using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWallJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerMovement>().getWallJump();
            Destroy(gameObject);
        }
    }
}
