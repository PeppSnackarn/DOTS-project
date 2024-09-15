using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[BurstCompile]
public partial struct EnemyMoveSys : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new EnemyMovejob
        {
            DeltaTime = deltaTime
        }.Schedule();
    }
}

[BurstCompile]
public partial struct EnemyMovejob : IJobEntity
{
    public float DeltaTime;

    private void Execute(ref LocalTransform transform, EnemyValues values)
    {
        transform.Position.y += -1 * values.EnemyMoveSpeed * DeltaTime;
    }
}
