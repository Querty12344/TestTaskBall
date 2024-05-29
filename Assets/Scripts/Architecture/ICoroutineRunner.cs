using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public interface ICoroutineRunner
    {
        void StopAllCoroutines();
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}