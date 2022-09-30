using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;
using BigasTools.InputSystem;
using BigasTools.Hero;

namespace LudumDare
{
    public class Hero : Entity
    {
        [SerializeField] Vector2 movement;
        private void Update() {
            var x = BGameInput.Instance.GetAxis().x;
            var y = BGameInput.Instance.GetAxis().y;

            movement = new Vector2(x,y).normalized;
        }
        private void FixedUpdate() {
            OnMove();
        }
        protected override void OnSpawn()
        {
            base.OnSpawn();
            CameraManager.Instance.SetTarget(this.transform, true, true, "Spawn of the hero!");
        }
        protected override void OnMove()
        {
            base.OnMove();
            
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), moveSpeed * Time.deltaTime);
        }
    }
}
