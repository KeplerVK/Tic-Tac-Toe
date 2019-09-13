using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //create a map 3*3
    private int[,] map = new int[3, 3];
    //who is play,0代表O的回合，1代表×的回合
    private int turn = 0;

    //如果O在棋盘某个位置下了，那么这个位置的值为1，如果X方下了，则为2。初始值均为0
    //reset the map
    void Reset()
    {
        turn = 0;//O先下
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                map[i, j] = 0;
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tic Tac Toe start!");
        Reset();
    }

    int Check()
    {
        //检查横排
        for (int i = 0; i < 3; i++)
        {
            if (map[i, 0] != 0 && map[i, 0] == map[i, 1] && map[i, 1] == map[i, 2])
                return map[i, 0];
        }
        //检查竖排
        for (int j = 0; j < 3; j++)
        {
            if (map[0, j] != 0 && map[0, j] == map[1, j] && map[1, j] == map[2, j])
                return map[0, j];
        }
        //检查斜排
        if ((map[0, 0] != 0 && map[0, 0] == map[1, 1] && map[1, 1] == map[2, 2]) || (map[0, 2] != 0 && map[0, 2] == map[1, 1] && map[1, 1] == map[2, 0]))
            return map[1, 1];
        //否则都没连成线
        return 0;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(285, 200, 200, 300), "");
        GUIStyle style = new GUIStyle();
        style.normal.textColor = new Color(1, 30, 2);
        style.fontSize = 25;

        if (GUI.Button(new Rect(333, 430, 100, 50), "reset"))
        {
            Reset();
        }
        if (turn == 0)
        {
            GUI.Label(new Rect(180, 220, 100, 50), "○ turn:", style);
        }
        else
            GUI.Label(new Rect(180, 220, 100, 50), "× turn:", style);

        int winner = Check();
        if (winner == 1)
        {
            GUI.Label(new Rect(330, 385, 100, 50), "○ win!!!", style);
        }
        else if (winner == 2)
        {
            GUI.Label(new Rect(330, 385, 100, 50), "× win!!!", style);
        }

        int flag = 0;//记录是否占满九个格
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                if (map[i, j] == 0)//有没占用的格子
                    flag = 1;
        }
        if (flag == 0 && winner==0)//平局
        {
            GUI.Label(new Rect(327, 385, 100, 50), "A dead heat! ", style);
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (map[i, j] == 1)
                {
                    GUI.Button(new Rect(i * 50 + 310, j * 50 + 205, 50, 50), "○");
                }
                if (map[i, j] == 2)
                {
                    GUI.Button(new Rect(i * 50 + 310, j * 50 + 205, 50, 50), "×");
                }
                if (GUI.Button(new Rect(i * 50 + 310, j * 50 + 205, 50, 50), ""))
                {
                    if (turn == 0) map[i, j] = 1;
                    if (turn == 1) map[i, j] = 2;
                    turn = 1 - turn;
                }
            }
        }

    }

    // Update is called once per frame 
    void Update()
    {

    }

}
