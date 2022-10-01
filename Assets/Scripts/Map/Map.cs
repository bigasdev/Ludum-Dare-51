using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

namespace LudumDare
{
    public class Map : MonoBehaviour
    {
        [SerializeField] bool isStartingPoint;

        private void Start() {
            if(isStartingPoint)SetTarget();
        }
        public void SetTarget(){
            CameraManager.Instance.SetTarget(this.transform);
        } 
    }
}
