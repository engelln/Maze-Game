using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;

	private void LateUpdate()
	{
        Vector2 newPosition = Vector2.Lerp(transform.position, player.getPlayerPos(), 2 * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);


    }
}
