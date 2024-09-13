using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public partial struct SpawnerSys : ISystem
{
  public void OnUpdate(ref SystemState state)
  {
    foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
    {
      if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
      {
        Entity newEnemy = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
        float3 pos = new float3(spawner.ValueRO.Position.x, spawner.ValueRO.Position.y, 0);
        state.EntityManager.SetComponentData(newEnemy,LocalTransform.FromPosition(pos));
        spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + (1/spawner.ValueRO.SpawnRate);
      }
    }
  }
}
