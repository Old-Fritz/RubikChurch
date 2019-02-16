using UnityEngine;

namespace Common.PlayerComps
{
	public class MouseRotation : MonoBehaviour
	{
		[SerializeField] private GameObject camera;
		[SerializeField] private float sensitivity = 10;
		[SerializeField] private float minX = -360;
		[SerializeField] private float maxX = 360;
		[SerializeField] private float minY = -90;
		[SerializeField] private float maxY = 90;

		private Quaternion originRotation;
		private float rotX, rotY;
	
		// Use this for initialization
		void Start ()
		{
			originRotation = camera.transform.localRotation;
		}
	
		// Update is called once per frame
		void Update ()
		{
			rotX += Input.GetAxis("Mouse X")*sensitivity;
			rotY += Input.GetAxis("Mouse Y")*sensitivity;

			rotX %= 360;
			rotY %= 360;

			rotX = Mathf.Clamp(rotX, minX, maxX);
			rotY = Mathf.Clamp(rotY, minY, maxY);
		
			Quaternion rotationX = Quaternion.AngleAxis(rotX, Vector3.up);
			Quaternion rotationY = Quaternion.AngleAxis(rotY, Vector3.left);

			camera.transform.localRotation = originRotation *rotationX* rotationY;

		}

		public void setDefault()
		{
			camera.transform.localRotation = originRotation;
		}

		public void setRotation(Quaternion newRotation)
		{
			camera.transform.localRotation = newRotation;
		}
	}
}
