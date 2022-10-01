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
        private static Hero instance;
        public static Hero Instance{
            get{
                if(instance == null)instance = FindObjectOfType<Hero>();
                return instance;
            }
        }
        [SerializeField] Vector2 movement;
        [SerializeField] float attackingTimer = .125f;
        [SerializeField] Animator animator;
        [SerializeField] GameObject spriteHolder;

        bool attacking = false;
        float attackCd = 0;
        float localScale = 1;
        //Util functions
        bool IsMoving(){
            return movement.x != 0 || movement.y != 0;
        }
        private void Update() {
            var x = BGameInput.Instance.GetAxis().x;
            var y = BGameInput.Instance.GetAxis().y;

            movement = new Vector2(x,y).normalized;


            ListenForInput();
            LocalScale();
            Animation();
            Cooldown();
            OnShake();
            OnBlink();
            OnSquash();
            RaycastWaypoint();
            RaycastEnemies();
        }
        void Cooldown(){
            if(attacking){
                attackCd += Time.deltaTime;
                if(attackCd >= attackingTimer){
                    attacking = false;
                    attackCd = 0;
                }
            }
        }
        void ListenForInput(){
            if(BGameInput.Instance.GetKeyPress("Attack")){
                attacking = true;
            }
        }
        void LocalScale(){
            localScale = Mathf.Floor(movement.x);
            if(localScale == 0)localScale = 1;
            spriteHolder.transform.localScale = new Vector2(-localScale, 1);
        }
        void Animation(){
            animator.SetBool("Moving", IsMoving());
            animator.SetInteger("Up", (int)movement.y);
            animator.SetBool("Side", movement.x != 0);
        }
        private void FixedUpdate() {
            OnMove();
        }

        void RaycastEnemies(){
            if(!attacking)return;
            RaycastHit2D hit;

            hit = Physics2D.BoxCast(new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), Vector2.one, 1, transform.forward);
            if(hit){
                var m = hit.collider.GetComponentInParent<Minion>();
                if(m == null)return;
                m.Blink(.125f, 3, Color.red);
                m.Hit(1);
                attacking = false;
                return;
            }
        }
        void RaycastWaypoint(){
            if(!IsMoving())return;
            RaycastHit2D hit;

            hit = Physics2D.BoxCast(new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), Vector2.one, 1, transform.forward);
            if(hit){
                Debug.Log(hit);
                var w = hit.collider.GetComponent<Waypoint>();
                Debug.Log(w);
                if(w == null)return;
                Debug.Log(w);
                w.Enter();
            }
        }
        protected override void OnSpawn()
        {
            base.OnSpawn();
            CameraManager.Instance.SetTarget(this.transform, true, true, "Spawn of the hero!");
        }
        protected override void OnMove()
        {
            base.OnMove();
            
            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), moveSpeed * Time.fixedDeltaTime);
        }
        public void Cleanse(){

        }

        private void OnDrawGizmosSelected() {
            if(attacking){
                Gizmos.color = Color.green;
                Gizmos.DrawCube(new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), Vector3.one);
            }
            if(IsMoving()){
                Gizmos.color = Color.red;
                Gizmos.DrawCube(new Vector2(this.transform.position.x+movement.x, this.transform.position.y+movement.y), (Vector3.one*.5f));
            }
        }
    }
}
