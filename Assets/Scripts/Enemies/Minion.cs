using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;

namespace LudumDare
{
    public class Minion : Entity
    {
        [SerializeField] float minionDamage = 2f;
        protected override void OnSpawn()
        {
            base.OnSpawn();
            Hero.Instance.OnTouch.AddListener((e)=>{
                if(e == this){
                    Hero.Instance.Hit(minionDamage, this);
                }
            });
        }
        private void Update() {
            OnShake();
            OnBlink();
            OnSquash();
        }
    }
}
