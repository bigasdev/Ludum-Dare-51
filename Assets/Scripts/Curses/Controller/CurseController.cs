using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BigasTools;
using UnityEngine.Events;

namespace LudumDare
{
    public class CurseController : MonoBehaviour
    {
        private static CurseController instance;
        public static CurseController Instance{
            get{
                if(instance == null)instance = FindObjectOfType<CurseController>();
                return instance;
            }
        }
        public UnityEvent<int> OnSecond = new UnityEvent<int>();
        public UnityEvent<string> OnTickEvnt = new UnityEvent<string>();
        [SerializeField] public List<CurseProfile> curses = new List<CurseProfile>();
        float tickTimer = -1;
        private void Update() {
            CurseUpdate();
        }

        void CurseUpdate(){
            if(StateController.Instance.currentState != States.GAME_UPDATE)return;

            tickTimer += Time.deltaTime;
            OnSecond.Invoke(Mathf.FloorToInt(tickTimer));
            if(tickTimer >= 10){
                OnTick();
            }
        }

        public void OnTick(){
            tickTimer = 0;
            if(curses.Count == 0)return;

            var rnd = curses[Random.Range(0, curses.Count)];

            Hero.Instance.Cleanse();
            OnTickEvnt.Invoke(rnd.name);
            Hero.Instance.squashY = 1.25f;
            BDebug.Log(rnd.name, "Curses");
            CameraManager.Instance.SetShake(.15f, .125f, "Curse tick!");
            rnd.evnt.Invoke();
        }
    }
}
