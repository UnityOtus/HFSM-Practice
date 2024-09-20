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
        public const int Target = 4; // GameObject : class
        public const int Waypoints = 5; // Transform[] : class
        public const int WaypointIndex = 6; // int
        public const int StoppingDistance = 7; // float
        public const int AttackDistance = 8; // float
        public const int ExclamationPointer = 9; // GameObject : class
        public const int MelleDistance = 10; // float
        public const int RangeDistance = 11; // float


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


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWaypoints(this IBlackboard obj) => obj.HasObject(Waypoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform[]  GetWaypoints(this IBlackboard obj) => obj.GetObject<Transform[] >(Waypoints);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWaypoints(this IBlackboard obj, out Transform[]  value) => obj.TryGetObject(Waypoints, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWaypoints(this IBlackboard obj, Transform[]  value) => obj.SetObject(Waypoints, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWaypoints(this IBlackboard obj) => obj.DelObject(Waypoints);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWaypointIndex(this IBlackboard obj) => obj.HasInt(WaypointIndex);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int GetWaypointIndex(this IBlackboard obj) => obj.GetInt(WaypointIndex);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWaypointIndex(this IBlackboard obj, out int value) => obj.TryGetInt(WaypointIndex, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWaypointIndex(this IBlackboard obj, int value) => obj.SetInt(WaypointIndex, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWaypointIndex(this IBlackboard obj) => obj.DelInt(WaypointIndex);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasStoppingDistance(this IBlackboard obj) => obj.HasFloat(StoppingDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetStoppingDistance(this IBlackboard obj) => obj.GetFloat(StoppingDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetStoppingDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(StoppingDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetStoppingDistance(this IBlackboard obj, float value) => obj.SetFloat(StoppingDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelStoppingDistance(this IBlackboard obj) => obj.DelFloat(StoppingDistance);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackDistance(this IBlackboard obj) => obj.HasFloat(AttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetAttackDistance(this IBlackboard obj) => obj.GetFloat(AttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(AttackDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackDistance(this IBlackboard obj, float value) => obj.SetFloat(AttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackDistance(this IBlackboard obj) => obj.DelFloat(AttackDistance);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasExclamationPointer(this IBlackboard obj) => obj.HasObject(ExclamationPointer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject  GetExclamationPointer(this IBlackboard obj) => obj.GetObject<GameObject >(ExclamationPointer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExclamationPointer(this IBlackboard obj, out GameObject  value) => obj.TryGetObject(ExclamationPointer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExclamationPointer(this IBlackboard obj, GameObject  value) => obj.SetObject(ExclamationPointer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExclamationPointer(this IBlackboard obj) => obj.DelObject(ExclamationPointer);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMelleDistance(this IBlackboard obj) => obj.HasFloat(MelleDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetMelleDistance(this IBlackboard obj) => obj.GetFloat(MelleDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMelleDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(MelleDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMelleDistance(this IBlackboard obj, float value) => obj.SetFloat(MelleDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMelleDistance(this IBlackboard obj) => obj.DelFloat(MelleDistance);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRangeDistance(this IBlackboard obj) => obj.HasFloat(RangeDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetRangeDistance(this IBlackboard obj) => obj.GetFloat(RangeDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRangeDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(RangeDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRangeDistance(this IBlackboard obj, float value) => obj.SetFloat(RangeDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRangeDistance(this IBlackboard obj) => obj.DelFloat(RangeDistance);

    }
}
