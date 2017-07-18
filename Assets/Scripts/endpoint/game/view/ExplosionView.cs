using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace endpoint.game
{
	public class ExplosionView : View
	{
        internal Signal animationCompleteSignal = new Signal();

        void FixedUpdate()
        {
            if (gameObject.GetComponent<ParticleSystem>().IsAlive() == false)
            {
                animationCompleteSignal.Dispatch();
            }
        }

        internal void resetAnimation()
        {
            gameObject.GetComponent<ParticleSystem>().time = 0f;
        }
    }
}