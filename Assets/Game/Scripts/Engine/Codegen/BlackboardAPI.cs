/**
* Code generation. Don't modify! 
 */
using System.Runtime.CompilerServices;
using Modules.AI;
using Game.Engine;
using Atomic.Objects;
using UnityEngine;
using Game.Engine.AI;
namespace AIModule
{
    public static class BlackboardAPI
    {
        public const int Character = 1; // IAtomicObject : class
        public const int ExclamationPoint = 2; // GameObject : class
        public const int MeleeAttackData = 3; // AttackData : struct
        public const int StoppingDistance = 4; // float
        public const int RangeAttackData = 5; // AttackData : struct
        public const int Target = 6; // IAtomicObject : class
        public const int CollidersBuffer = 9; // BufferData<Collider2D> : struct
        public const int PatrolData = 12; // PatrolData : struct
        public const int AttackData = 13; // AttackData : struct
        public const int CircleSensorData = 14; // CircleSensorData : struct


        ///Extensions
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCharacter(this IBlackboard obj) => obj.HasObject(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAtomicObject  GetCharacter(this IBlackboard obj) => obj.GetObject<IAtomicObject >(Character);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCharacter(this IBlackboard obj, out IAtomicObject  value) => obj.TryGetObject(Character, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCharacter(this IBlackboard obj, IAtomicObject  value) => obj.SetObject(Character, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCharacter(this IBlackboard obj) => obj.DelObject(Character);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasExclamationPoint(this IBlackboard obj) => obj.HasObject(ExclamationPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static GameObject  GetExclamationPoint(this IBlackboard obj) => obj.GetObject<GameObject >(ExclamationPoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetExclamationPoint(this IBlackboard obj, out GameObject  value) => obj.TryGetObject(ExclamationPoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetExclamationPoint(this IBlackboard obj, GameObject  value) => obj.SetObject(ExclamationPoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelExclamationPoint(this IBlackboard obj) => obj.DelObject(ExclamationPoint);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMeleeAttackData(this IBlackboard obj) => obj.HasStruct(MeleeAttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref AttackData  GetMeleeAttackData(this IBlackboard obj) => ref obj.GetStruct<AttackData >(MeleeAttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMeleeAttackData(this IBlackboard obj, out IBlackboard.Ref<AttackData > value) => obj.TryGetStruct(MeleeAttackData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMeleeAttackData(this IBlackboard obj, AttackData  value) => obj.SetStruct(MeleeAttackData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMeleeAttackData(this IBlackboard obj) => obj.DelObject(MeleeAttackData);


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
		public static bool HasRangeAttackData(this IBlackboard obj) => obj.HasStruct(RangeAttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref AttackData  GetRangeAttackData(this IBlackboard obj) => ref obj.GetStruct<AttackData >(RangeAttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRangeAttackData(this IBlackboard obj, out IBlackboard.Ref<AttackData > value) => obj.TryGetStruct(RangeAttackData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRangeAttackData(this IBlackboard obj, AttackData  value) => obj.SetStruct(RangeAttackData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRangeAttackData(this IBlackboard obj) => obj.DelObject(RangeAttackData);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTarget(this IBlackboard obj) => obj.HasObject(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAtomicObject  GetTarget(this IBlackboard obj) => obj.GetObject<IAtomicObject >(Target);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTarget(this IBlackboard obj, out IAtomicObject  value) => obj.TryGetObject(Target, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTarget(this IBlackboard obj, IAtomicObject  value) => obj.SetObject(Target, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTarget(this IBlackboard obj) => obj.DelObject(Target);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCollidersBuffer(this IBlackboard obj) => obj.HasStruct(CollidersBuffer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref BufferData<Collider2D>  GetCollidersBuffer(this IBlackboard obj) => ref obj.GetStruct<BufferData<Collider2D> >(CollidersBuffer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCollidersBuffer(this IBlackboard obj, out IBlackboard.Ref<BufferData<Collider2D> > value) => obj.TryGetStruct(CollidersBuffer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCollidersBuffer(this IBlackboard obj, BufferData<Collider2D>  value) => obj.SetStruct(CollidersBuffer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCollidersBuffer(this IBlackboard obj) => obj.DelObject(CollidersBuffer);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPatrolData(this IBlackboard obj) => obj.HasStruct(PatrolData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref PatrolData  GetPatrolData(this IBlackboard obj) => ref obj.GetStruct<PatrolData >(PatrolData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPatrolData(this IBlackboard obj, out IBlackboard.Ref<PatrolData > value) => obj.TryGetStruct(PatrolData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPatrolData(this IBlackboard obj, PatrolData  value) => obj.SetStruct(PatrolData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPatrolData(this IBlackboard obj) => obj.DelObject(PatrolData);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackData(this IBlackboard obj) => obj.HasStruct(AttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref AttackData  GetAttackData(this IBlackboard obj) => ref obj.GetStruct<AttackData >(AttackData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackData(this IBlackboard obj, out IBlackboard.Ref<AttackData > value) => obj.TryGetStruct(AttackData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackData(this IBlackboard obj, AttackData  value) => obj.SetStruct(AttackData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackData(this IBlackboard obj) => obj.DelObject(AttackData);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCircleSensorData(this IBlackboard obj) => obj.HasStruct(CircleSensorData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref CircleSensorData  GetCircleSensorData(this IBlackboard obj) => ref obj.GetStruct<CircleSensorData >(CircleSensorData);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCircleSensorData(this IBlackboard obj, out IBlackboard.Ref<CircleSensorData > value) => obj.TryGetStruct(CircleSensorData, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCircleSensorData(this IBlackboard obj, CircleSensorData  value) => obj.SetStruct(CircleSensorData, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCircleSensorData(this IBlackboard obj) => obj.DelObject(CircleSensorData);

    }
}
