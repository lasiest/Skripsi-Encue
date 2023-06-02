using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovementScript : MonoBehaviour
{
    public GameObject npc;
    public GameObject[] pos;
    public bool[] curr_pos;
    public float index_curr_pos;
    public float movementSpeed;

    private void Update() {

        if(index_curr_pos == 0){
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, pos[1].transform.position, movementSpeed * Time.deltaTime);
        }else  if(index_curr_pos == 1){
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, pos[2].transform.position, movementSpeed * Time.deltaTime);
        }else if(index_curr_pos == 2){
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, pos[3].transform.position, movementSpeed * Time.deltaTime);
        }else if(index_curr_pos == 3){
            npc.transform.position = Vector3.MoveTowards(npc.transform.position, pos[0].transform.position, movementSpeed * Time.deltaTime);
        }

        if(npc.transform.position == pos[0].transform.position){
            index_curr_pos = 0;
        }else if(npc.transform.position == pos[1].transform.position){
            index_curr_pos = 1;
        }else if(npc.transform.position == pos[2].transform.position){
            index_curr_pos = 2;
        }else if(npc.transform.position == pos[3].transform.position){
            index_curr_pos = 3;
        }
    }
}
