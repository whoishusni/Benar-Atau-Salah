using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InernetConnCheck : MonoBehaviour
{
   
    public Button[] button;
    void Start()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            foreach (Button btn in button) {
                btn.interactable = false;
            }
            SSTools.ShowMessage("Cek Koneksi Internet Anda", SSTools.Position.bottom, SSTools.Time.threeSecond);
            StartCoroutine(ExitGame());
            
        }
        IEnumerator ExitGame() {
            yield return new WaitForSeconds(3);
            Application.Quit();
        }
    }

    
   
}
