using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PillarController : MonoBehaviour
{
   [SerializeField] private Vector2 minMaxSizeRange;
   
   [ContextMenu(nameof(SetRandomSize))]
   public void SetRandomSize()
   {
      var newScale = transform.localScale;
      newScale.x = Random.Range(minMaxSizeRange.x, minMaxSizeRange.y);
      transform.localScale = newScale;
   }
}