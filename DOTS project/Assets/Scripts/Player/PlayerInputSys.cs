using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)] // Setting update group to be last thing to run before game logic is run
public partial class PlayerInputSys : SystemBase
{
   private Player_IA InputAction;
   private Entity Player;

   protected override void OnCreate()
   {
      // forces update loop to wait for player tag & input component to exist
      RequireForUpdate<PlayerTag>();
      RequireForUpdate<PlayerMoveInput>();
      InputAction = new Player_IA();
   }

   protected override void OnStartRunning()
   {
      InputAction.Enable();
      Player = SystemAPI.GetSingletonEntity<PlayerTag>(); // Gets a single entity and assume that there will always only be one of it
   }

   protected override void OnUpdate()
   {
      Vector2 move = InputAction.MoveShoot.WASDMove.ReadValue<Vector2>(); // Movement vector
      SystemAPI.SetSingleton(new PlayerMoveInput() { value = move}); // Sets speed
   }

   protected override void OnStopRunning()
   {
      InputAction.Disable();
      Player = Entity.Null;
   }
}
