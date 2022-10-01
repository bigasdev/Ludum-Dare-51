using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools.InputSystem;

namespace LudumDare
{
    public class UnitTests : MonoBehaviour
    {
        private void Update() {
            if(BGameInput.Instance.GetKeyPress("Debug")){
                CurseController.Instance.OnTick();
            }
        }
    }
}
