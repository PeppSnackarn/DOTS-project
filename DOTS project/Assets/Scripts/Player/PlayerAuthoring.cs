using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAuthoring : MonoBehaviour
{
    public float Speed = 5;
    
    public GameObject Bullet;

    //Conversion from GO to Entity
    class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            Entity playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            //adding all player components
            AddComponent<PlayerMoveInput>(playerEntity);
            AddComponent(playerEntity, new PlayerMoveSpeed()
            {
                value = authoring.Speed,
            });
            AddComponent<PlayerTag>(playerEntity);
            
            //Bullet components
            AddComponent<BulletTag>(playerEntity);
            SetComponentEnabled<BulletTag>(playerEntity,false);
            AddComponent(playerEntity, new Bullet()
            {
                bullet = GetEntity(authoring.Bullet, TransformUsageFlags.Dynamic)
            });
        }
    }
}

public struct PlayerMoveInput : IComponentData
{
    public float2 value;
}

public struct PlayerMoveSpeed : IComponentData
{
    public float value;
}

public struct PlayerTag : IComponentData
{
    
}

public struct Bullet : IComponentData
{
    public Entity bullet;
}

public struct BulletSpeed : IComponentData
{
    public float value;
}

public struct BulletTag : IComponentData, IEnableableComponent
{
    
}


