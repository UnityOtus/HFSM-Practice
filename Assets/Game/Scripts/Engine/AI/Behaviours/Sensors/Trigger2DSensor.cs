// using AIModule;
// using Atomic.Objects;
// using Modules.AI;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     public sealed class Trigger2DSensor : MonoBehaviour
//     {
//         [SerializeField] 
//         private SceneBlackboard blackboard;
//
//         private void OnTriggerEnter2D(Collider2D col)
//          {
//              if (col.TryGetComponent(out IAtomicObject obj))
//              {
//                  this.blackboard.SetTarget(obj);
//              }
//          }
//
//          private void OnTriggerExit2D(Collider2D col)
//          {
//              if (col.TryGetComponent(out IAtomicObject _))
//              {
//                  this.blackboard.DelTarget();
//              }
//          }
//      }
// }