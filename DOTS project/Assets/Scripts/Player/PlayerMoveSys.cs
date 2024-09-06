
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct PlayerMoveSys : ISystem
{
  [BurstCompile]
  public void OnUpdate(ref SystemState state)
  {
    float deltaTime = SystemAPI.Time.DeltaTime;

    new PlayerMoveJob
    {
      DeltaTime = deltaTime
    }.Schedule();
  }
  
  //A job: a part of code that you can delegate to another thread to then run & "return" with the complete task
  [BurstCompile]
  public partial struct PlayerMoveJob : IJobEntity
  {
    public float DeltaTime;
    private void Execute(ref LocalTransform transform, in PlayerMoveInput input, PlayerMoveSpeed speed) // Will find input and speed itself.
    {
      transform.Position.xy += input.value * speed.value * DeltaTime;
    }
    
  }
}
