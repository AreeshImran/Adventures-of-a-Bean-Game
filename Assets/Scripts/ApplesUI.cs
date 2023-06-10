using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplesUI : MonoBehaviour
{
    private TextMeshProUGUI appleText;

    // Start is called before the first frame update
    void Start()
    {
        appleText = GetComponent<TextMeshProUGUI>();
        
    }

    public void UpdateAppleText(playerInventory inv){
        appleText.text = inv.appleCollection.ToString();
    }
}
