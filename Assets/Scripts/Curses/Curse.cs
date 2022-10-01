using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LudumDare
{
    public class Curse : MonoBehaviour
    {
        private void Start() {
            var x = new UnityEvent();
            x.AddListener(()=>{
                Debug.Log("Test");
            });
            CurseController.Instance.AddCurse(x);
        }
    }
}
