﻿using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	void OnAnimetionFinish()
    {
        Destroy(gameObject);
    }
}
