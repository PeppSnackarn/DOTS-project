using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public float spawnRate;
    public GameObject enemyPrefab;

    class SpawnerAuthoringBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None); //trasnformusageflags.none since it will never move
            
            AddComponent(entity, new Spawner
            {
                Prefab = GetEntity(authoring.enemyPrefab,TransformUsageFlags.Dynamic),
                NextSpawnTime = 0,
                SpawnRate = authoring.spawnRate,
                Position = authoring.transform.position
            });
        }
    }
}

public struct Spawner : IComponentData
{
    public Entity Prefab;
    public float NextSpawnTime;
    public float SpawnRate;
    public Vector2 Position;
}
