﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class DestroyOnLifetime : MonoBehaviour
    {
        public float lifeTime = 5f;

        // Use this for initialization
        void Start()
        {
            Destroy(gameObject, lifeTime);
        }
    }
}


