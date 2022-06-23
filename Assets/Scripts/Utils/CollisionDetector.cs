using System;
using UniRx;
using UnityEngine;

namespace Utils
{
    public class CollisionDetector : MonoBehaviour
    {
        private Subject<Collision> _collisions = new Subject<Collision>();

        public IObservable<Collision> Collisions => _collisions;

        private void OnCollisionStay(Collision collision)
        {
            _collisions.OnNext(collision);
        }
    }
}