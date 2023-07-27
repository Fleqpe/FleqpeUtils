using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPointOnMap : MonoBehaviour
{

      void Start()
      {
            this.gameObject.transform.position = new Vector3(Random.Range(0f, 15f), Random.Range(0f, 15f), 0);
      }


}
