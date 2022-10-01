using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

namespace LudumDare
{
    public class Curse : MonoBehaviour
    {
        [SerializeField] List<CurseProfile> curses = new List<CurseProfile>();
        private void Start() {
            CurseController.Instance.curses = curses;

            GetCurse("Freeze").evnt.AddListener(()=>{
                Debug.Log("Freeze");
            });
        }
        public CurseProfile GetCurse(string name){
            return curses.Where(x=>x.name == name).FirstOrDefault();
        }
    }
    [System.Serializable]
    public class CurseProfile{
       public string name;
       public string description;
       public Sprite icon;
       public UnityEvent evnt = new UnityEvent();

        public CurseProfile(string name, string description, Sprite icon)
        {
            this.name = name;
            this.description = description;
            this.icon = icon;
        }
    }
}
