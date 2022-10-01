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
        [SerializeField] public List<CurseProfile> curses = new List<CurseProfile>();
        float tickTimer = -10;
        private void Update() {
            CurseUpdate();
        }

        void CurseUpdate(){
            if(StateController.Instance.currentState != States.GAME_UPDATE)return;

            tickTimer += Time.deltaTime;
            if(tickTimer >= 10){
                OnTick();
                tickTimer = 0;
            }
        }

        void OnTick(){
            if(curses.Count == 0)return;

            var rnd = curses[Random.Range(0, curses.Count)];

            CameraManager.Instance.SetShake(.15f, .125f, "Curse tick!");
            rnd.evnt.Invoke();
        }
    }
}
