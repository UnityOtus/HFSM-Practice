using System;
using UnityEngine;

namespace Game.Engine.AI
{
    [Serializable]
    public struct BufferData<T>
    {
        public T[] values;
        public int size;
    }
}