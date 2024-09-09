using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct BulletMoveSystem : ISystem
{
   [BurstCompile]
   public void OnUpdate(ref SystemState state)
   {
      float deltaTime = SystemAPI.Time.DeltaTime;

      foreach (var (transform, movespeed) in SystemAPI.Query<RefRW<LocalTransform>,BulletSpeed>())
      {
         transform.ValueRW.Position += transform.ValueRO.Up() * movespeed.value * deltaTime;
      }
   }
}
