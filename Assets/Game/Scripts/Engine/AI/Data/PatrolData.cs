// using System;
// using UnityEngine;
//
// namespace Game.Engine.AI
// {
//     [Serializable]
//     public struct PatrolData
//     {
//         public bool enabled;
//         public int index;
//         public Transform[] points;
//
//         public Vector2 CurrentPosition
//         {
//             get { return this.points[this.index].position; }
//         }
//
//         public void NextIndex()
//         {
//             this.index = (this.index + 1) % this.points.Length;
//         }
//         
//         public override string ToString()
//         {
//             return $"{nameof(enabled)}: {enabled}, {nameof(index)}: {index}, {nameof(points)}: {points}";
//         }
//     }
// }