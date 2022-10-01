using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

namespace LudumDare
{
    public class Minion : Entity
    {
        private void Update() {
            OnShake();
            OnBlink();
            OnSquash();
        }
    }
}
