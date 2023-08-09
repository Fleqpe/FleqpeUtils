using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FleqpeUtils;
public class Follow : MonoBehaviour
{
      private GameObject player;
      public Rigidbody2D rb;
      private void Awake()
      {
            player = GameObject.FindGameObjectWithTag("Player");
            InvokeRepeating("SetSpeed", 0f, Random.Range(0.5f, 1.3f));
      }
      public void SetSpeed()
      {
            rb.velocity = HelperFunctions.GetDirection(this.gameObject, player) * 10;
      }
}
