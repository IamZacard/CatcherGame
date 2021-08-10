using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPicker : MonoBehaviour
{
    public GameObject Player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Soul"))
        {
            Player.gameObject.GetComponent<SoulManager>()._pickUpSoul();
            Destroy(other.gameObject);
        }
    }
}
