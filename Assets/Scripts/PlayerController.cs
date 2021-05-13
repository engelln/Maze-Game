using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    private Stack<GameObject> playerTrail;
    private Vector3 pos = Vector3.zero;
    private MazeController mazeController;
    private GameObject currentPlayer;

    private void Start()
	{
        playerTrail = new Stack<GameObject>();
        currentPlayer = Instantiate(player, pos, Quaternion.identity);
        mazeController = GetComponent<MazeController>();
        StartCoroutine("MovePlayer");
    }
	
	private void Update()
	{


    }

    public IEnumerator MovePlayer()
    {
        while (true)
        {
            Vector3 newPos = pos;
            if (Input.GetKey("w"))
            {
                newPos = new Vector3(pos.x, pos.y + 1, pos.z);
            }
            else if (Input.GetKey("a"))
            {
                newPos = new Vector3(pos.x - 1, pos.y, pos.z);
            }
            else if (Input.GetKey("s"))
            {
                newPos = new Vector3(pos.x, pos.y - 1, pos.z);
            }
            else if (Input.GetKey("d"))
            {
                newPos = new Vector3(pos.x + 1, pos.y, pos.z);
            }

            if (newPos != pos)
            {
                int translatedX = (int)-newPos.y;
                int translatedY = mazeController.x + (int)newPos.x;
                if (mazeController.getMaze().getArray()[translatedY, translatedX] == CellType.Open)
                {

                    if ((playerTrail.Count != 0) && playerTrail.Peek().transform.position == newPos)
                    {
                        pos = playerTrail.Peek().transform.position;
                        Destroy(currentPlayer);
                        currentPlayer = playerTrail.Pop();

                    }
                    else
                    {
                        playerTrail.Push(currentPlayer);
                        currentPlayer = Instantiate(player, newPos, Quaternion.identity);
                        pos = newPos;
                    }

                }

            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public Vector3 getPlayerPos()
    {
        return pos;
    }
}
