using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
  float innerBounds;
  [SerializeField] GameObject topBarrier;
  [SerializeField] GameObject leftBarrier;
  [SerializeField] GameObject rightBarrier;
  [SerializeField] GameObject bottomBarrier;

  private void Awake() {
    CalculateInnerBounds();


  }

  void CalculateInnerBounds() {
    Renderer leftBarrierRenderer = leftBarrier.GetComponent<Renderer>();
    Renderer rightBarrierRenderer = rightBarrier.GetComponent<Renderer>();
    innerBounds = rightBarrierRenderer.bounds.min.x - leftBarrierRenderer.bounds.max.x;
  }

}
