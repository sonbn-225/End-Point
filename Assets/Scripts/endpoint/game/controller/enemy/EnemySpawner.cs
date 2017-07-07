using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.game
{
    public class EnemySpawner : ISpawner
	{
        [Inject]
        public CreateEnemySignal createEnemySignal { get; set; }

        [Inject]
        public IRoutineRunner routineRunner { get; set; }

        [Inject]
        public IGameConfig gameConfig { get; set; }

        private bool isRunning = false;

        [PostConstruct]
        public void PostConstruct()
        {
            
        }

		// Use this for initialization
        public void Start()
		{
            isRunning = true;
            routineRunner.StartCoroutine(spawn());
		}

        public void Stop()
		{
            isRunning = false;
		}

        IEnumerator spawn()
        {
            while (isRunning)
            {
                yield return new WaitForSeconds(1);
                Vector3 startPos = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
                EnemyType enemyType = (EnemyType)UnityEngine.Random.Range(0, 4);
                createEnemySignal.Dispatch(1, startPos, enemyType);
            }
        }
	}
}

