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
        public const int Waypoints = 4; // Transform[] : class
        public const int WaypointIndex = 5; // int
        public const int StoppingDistance = 6; // float
        public const int CurrentAttackDistance = 7; // float
        public const int Target = 8; // GameObject : class
        public const int ExclamationView = 9; // GameObject : class
        public const int MeleeAttackDistance = 11; // float
        public const int RangeAttackDistance = 12; // float


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
		public static bool HasCurrentAttackDistance(this IBlackboard obj) => obj.HasFloat(CurrentAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetCurrentAttackDistance(this IBlackboard obj) => obj.GetFloat(CurrentAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCurrentAttackDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(CurrentAttackDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCurrentAttackDistance(this IBlackboard obj, float value) => obj.SetFloat(CurrentAttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCurrentAttackDistance(this IBlackboard obj) => obj.DelFloat(CurrentAttackDistance);


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
		public static bool HasExclamationView(this IBlackboard obj) => obj.HasObject(ExclamationView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject  GetExclamationView(this IBlackboard obj) => obj.GetObject<GameObject >(ExclamationView);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExclamationView(this IBlackboard obj, out GameObject  value) => obj.TryGetObject(ExclamationView, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExclamationView(this IBlackboard obj, GameObject  value) => obj.SetObject(ExclamationView, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExclamationView(this IBlackboard obj) => obj.DelObject(ExclamationView);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMeleeAttackDistance(this IBlackboard obj) => obj.HasFloat(MeleeAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetMeleeAttackDistance(this IBlackboard obj) => obj.GetFloat(MeleeAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMeleeAttackDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(MeleeAttackDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMeleeAttackDistance(this IBlackboard obj, float value) => obj.SetFloat(MeleeAttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMeleeAttackDistance(this IBlackboard obj) => obj.DelFloat(MeleeAttackDistance);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRangeAttackDistance(this IBlackboard obj) => obj.HasFloat(RangeAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetRangeAttackDistance(this IBlackboard obj) => obj.GetFloat(RangeAttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRangeAttackDistance(this IBlackboard obj, out float value) => obj.TryGetFloat(RangeAttackDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRangeAttackDistance(this IBlackboard obj, float value) => obj.SetFloat(RangeAttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRangeAttackDistance(this IBlackboard obj) => obj.DelFloat(RangeAttackDistance);

    }
}
