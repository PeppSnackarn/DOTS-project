using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
   public float moveSpeed = 5;

   class EnemyAuthoringBaker : Baker<EnemyAuthoring>
   {
      public override void Bake(EnemyAuthoring authoring)
      {
         Entity entity = GetEntity(TransformUsageFlags.Dynamic);
         AddComponent(entity, new EnemyValues
         {
            EnemyMoveSpeed = authoring.moveSpeed
         });
      }
   }
}

public struct EnemyValues : IComponentData
{
   public float EnemyMoveSpeed;
}
