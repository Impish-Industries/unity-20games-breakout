using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
  [SerializeField]
  float timeToDieInMiliseconds;

  private void OnCollisionEnter2D(Collision2D other) {
    StartCoroutine(Die());
  }

  IEnumerator Die(){
    float delayInMs = 0.1f;
    float ms = Time.deltaTime;
    while(ms <= delayInMs )
    {
      ms += Time.deltaTime;
      yield return null;
    }
    BreakoutManager.Instance.UpdateScore(10);
    Destroy(gameObject);
  }



}
