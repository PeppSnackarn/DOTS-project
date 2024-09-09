using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct BulletSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Allocator.TempJob); // an ECB is like an array where you can store commands to run on entities
        foreach (var (Bullet, transform) in SystemAPI.Query<Bullet, LocalTransform>().WithAll<BulletTag>())
        {
            var newBullet = ecb.Instantiate(Bullet.bullet);
            var bulletTransform = LocalTransform.FromPositionRotation(transform.Position, transform.Rotation);
            ecb.SetComponent(newBullet, bulletTransform);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
