using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
      public float speed;
      private void Update()
      {
            Vector3 movementVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            this.gameObject.transform.position += movementVector * Time.deltaTime * speed;
      }
}
