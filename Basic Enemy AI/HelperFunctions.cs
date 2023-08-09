using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FleqpeUtils
{
      public static class HelperFunctions
      {
            public static Vector3 GetDirection(GameObject enemy, GameObject player)
            {
                  return (player.transform.position - enemy.transform.position).normalized;
            }
      }
}