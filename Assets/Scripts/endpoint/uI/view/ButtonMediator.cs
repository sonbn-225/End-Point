﻿using System.Collections;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace endpoint.ui
{
    public class ButtonMediator : Mediator
    {
        [Inject]
        public ButtonView view { get; set; }

        [Inject]
        public ButtonClickSignal buttonClickSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.pressSignal.AddListener(onButtonClick);
        }

        //protected void OnMouseDown()
        //{
        //    view.pressBegan();
        //}

        //protected void OnMouseUp()
        //{
        //    view.pressEnded();
        //}

        //protected void OnMouseEnter()
        //{
        //    view.background.GetComponent<Renderer>().material.color = view.overColor;
        //}

        //protected void OnMouseExit()
        //{
        //    view.background.GetComponent<Renderer>().material.color = view.normalColor;
        //}

        private void onButtonClick()
        {
            buttonClickSignal.Dispatch(view.gameObject.name);
        }
    }
}
