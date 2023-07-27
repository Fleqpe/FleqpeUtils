using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow : MonoBehaviour
{
      public Color color;
      public void GlowPlayer()
      {
            StartCoroutine("GlowPlayer_Coroutine");
      }
      public IEnumerator GlowPlayer_Coroutine()
      {
            yield return null;
      }
}
