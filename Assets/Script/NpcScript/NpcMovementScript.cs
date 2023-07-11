using UnityEngine;

public class NpcMovementScript : MonoBehaviour
{
    [SerializeField]
    private Transform npc;

    [SerializeField]
    private Transform[] target;

    [SerializeField]
    private bool[] curr_pos;

    [SerializeField]
    private int index_curr_pos;

    [SerializeField]
    private float movementSpeed;

    private Vector3 TargetPosition => index_curr_pos == 3 ? target[0].position : target[index_curr_pos + 1].position;

    private void Update() {
        npc.position = Vector3.MoveTowards(npc.position, TargetPosition, movementSpeed * Time.deltaTime);
        for (int i = 0; i <= 3; i++) if (npc.position == target[i].position) index_curr_pos = i;
    }
}