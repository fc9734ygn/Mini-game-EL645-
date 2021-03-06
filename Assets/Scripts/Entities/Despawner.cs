﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{ 
    // Destroy grocery on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Grocery")
        {
            Destroy(collision.gameObject);
        }
    }
}
