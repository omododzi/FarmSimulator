using System;
using UnityEngine;

public class LookcAtPlayer : MonoBehaviour
{
  private void FixedUpdate()
  {
    gameObject.transform.LookAt(Camera.main.transform);
  }
}
