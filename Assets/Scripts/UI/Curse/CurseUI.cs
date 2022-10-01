using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LudumDare
{
    public class CurseUI : MonoBehaviour
    {
        private static CurseUI instance;
        public static CurseUI Instance{
            get{
                if(instance == null)instance = FindObjectOfType<CurseUI>();
                return instance;
            }
        }
        [SerializeField] Text secondsText, currentCurseText, curseNamePopup;
        [SerializeField] Animator tipAnim, secondsAnim, currentCurseAnim;

        private void Start() {
            CurseController.Instance.OnSecond.AddListener((second)=>{
                PassSecond(second);
            });
            CurseController.Instance.OnTickEvnt.AddListener((curse)=>{
                AddCurse(curse);
            });
        }

        public void PassSecond(int second){
            secondsText.text = second.ToString();
            secondsAnim.SetTrigger("Pass");
        }
        public void AddCurse(string curse){
            currentCurseText.text = curse;
            curseNamePopup.text = curse;
            tipAnim.SetTrigger("Enter");
        }
    }
}
