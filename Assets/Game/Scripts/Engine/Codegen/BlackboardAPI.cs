/**
* Code generation. Don't modify! 
 */
using System.Runtime.CompilerServices;
using Atomic.AI;
using Game.Engine;
using UnityEngine;
using Game.Engine.AI;
namespace Atomic.AI
{
    public static class BlackboardAPI
    {
        public const int Character = 1; // GameObject : class
        public const int SensorData = 2; // SensorData : struct
        public const int ColliderBuffer = 3; // BufferData<Collider2D> : struct
        public const int Target = 8; // GameObject : class


        ///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IBlackboard obj) => obj.HasObject(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject  GetCharacter(this IBlackboard obj) => obj.GetObject<GameObject >(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IBlackboard obj, out GameObject  value) => obj.TryGetObject(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IBlackboard obj, GameObject  value) => obj.SetObject(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IBlackboard obj) => obj.DelObject(Character);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSensorData(this IBlackboard obj) => obj.HasStruct(SensorData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref SensorData  GetSensorData(this IBlackboard obj) => ref obj.GetStruct<SensorData >(SensorData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSensorData(this IBlackboard obj, out Ref<SensorData > value) => obj.TryGetStruct(SensorData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSensorData(this IBlackboard obj, SensorData  value) => obj.SetStruct(SensorData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSensorData(this IBlackboard obj) => obj.DelObject(SensorData);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasColliderBuffer(this IBlackboard obj) => obj.HasStruct(ColliderBuffer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref BufferData<Collider2D>  GetColliderBuffer(this IBlackboard obj) => ref obj.GetStruct<BufferData<Collider2D> >(ColliderBuffer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetColliderBuffer(this IBlackboard obj, out Ref<BufferData<Collider2D> > value) => obj.TryGetStruct(ColliderBuffer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetColliderBuffer(this IBlackboard obj, BufferData<Collider2D>  value) => obj.SetStruct(ColliderBuffer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelColliderBuffer(this IBlackboard obj) => obj.DelObject(ColliderBuffer);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IBlackboard obj) => obj.HasObject(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject  GetTarget(this IBlackboard obj) => obj.GetObject<GameObject >(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IBlackboard obj, out GameObject  value) => obj.TryGetObject(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IBlackboard obj, GameObject  value) => obj.SetObject(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IBlackboard obj) => obj.DelObject(Target);

    }
}
