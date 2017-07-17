using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace endpoint.ui
{
    public interface ISocialService
    {
        void Init();
        bool isLoggedIn();
        void OnFacebookLoginClick();
    }
}
