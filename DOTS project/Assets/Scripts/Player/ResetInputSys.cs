using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup), OrderLast = true)]
[UpdateAfter(typeof(EndSimulationEntityCommandBufferSystem))]
public partial struct ResetInputSys : ISystem
{
   public void OnUpdate(ref SystemState state)
   {
      var ecb = new EntityCommandBuffer(Allocator.Temp);
      foreach (var (tag, entity) in SystemAPI.Query<BulletTag>().WithEntityAccess())
      {
         ecb.SetComponentEnabled<BulletTag>(entity, false);
      }
      ecb.Playback(state.EntityManager);
      ecb.Dispose();
   }
}