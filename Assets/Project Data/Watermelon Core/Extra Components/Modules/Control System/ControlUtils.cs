using UnityEngine;
using YG;

namespace Watermelon
{
    public static class ControlUtils
    {
        public static InputType GetCurrentInputType()
        {
#if UNITY_EDITOR
#if UNITY_ANDROID || UNITY_IOS
            return InputType.UIJoystick;
#else
            return InputType.Keyboard;
#endif
#else
#if UNITY_ANDROID || UNITY_IOS
            return InputType.UIJoystick;
#elif UNITY_WEBGL
            Debug.Log("UNITY_WEBGL!!!!!!!!!!!!!!!!!!!!!");
            return YandexGame.EnvironmentData.isMobile ? InputType.UIJoystick : InputType.Keyboard;
#else
            return InputType.Keyboard;
#endif
#endif
        }
    }
}