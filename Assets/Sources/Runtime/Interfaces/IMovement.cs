﻿using System;
using UnityEngine;

namespace Sources.Runtime.Interfaces
{
    public interface IMovement
    {
        public event Action<Vector2> Moved;
        
        public float Speed { get; }
        
        void Move(Vector2 direction);

        void IncreaseSpeed(float value);
    }
}