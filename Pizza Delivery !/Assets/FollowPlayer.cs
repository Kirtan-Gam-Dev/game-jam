using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public Transform FollowObject;

   void LateUpdate()
   {
      Vector3 pos = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);
         transform.position = pos;
   }
}
