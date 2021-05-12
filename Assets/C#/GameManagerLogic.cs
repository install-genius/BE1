using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public int totalItemcount;
    public int Stage;
    public Text stageCountText;
    public Text playerCountText;

    void Awake()
    {
        stageCountText.text = " / " + totalItemcount;
    }

    public void GetItem(int count)
    {
        playerCountText.text = count.ToString();
    }
}
