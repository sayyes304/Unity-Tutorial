using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int TotalItem;
    public int stage;
    public TextMeshProUGUI stageCount;
    public TextMeshProUGUI playerCount;

    private void Awake()
    {
        stageCount.text = "/" + TotalItem.ToString();
    }

    public void GetItemCount(int count)
    {
        playerCount.text = count.ToString();
    }
}
