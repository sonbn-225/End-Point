using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint
{
    public interface IRoutineRunner
    {
        Coroutine StartCoroutine(IEnumerator method);
    }
}
