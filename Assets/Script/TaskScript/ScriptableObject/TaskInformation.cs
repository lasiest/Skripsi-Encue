using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "Task Information")]
public class TaskInformation : ScriptableObject
{
    public int taskIndex;
    public string taskTitle;
    public string taskDescription;
    public int trashAvailable;
    public int reputationReward;
    public int moneyReward;
    public int timeLimit;

    public enum sceneNameEnun{
        Level_1,
        Level_2,
        Level_3
    }

    public sceneNameEnun sceneName;

}
