using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace endpoint.game
{
    public class CreateGameFieldCommand : Command
    {
        [Inject(ContextKeys.CONTEXT_VIEW)]
        public GameObject contextView { get; set; }

        public override void Execute()
        {
            Vector3 center = Vector3.zero;

            //Setup the game field
            if (injectionBinder.GetBinding<GameObject>(GameElement.GAME_FIELD) == null)
            {
                GameObject gameField = new GameObject(GameElement.GAME_FIELD.ToString());
                gameField.transform.localPosition = center;
                gameField.transform.parent = contextView.transform;

                injectionBinder.Bind<GameObject>().ToValue(gameField).ToName(GameElement.GAME_FIELD);
            }
        }
    }
}