using System;
using UnityEngine;
using System.Collections;

public class CameraNav : MonoBehaviour {

    /// <summary>
    /// Максимальное отклюнение камеры по оси Х при соотношении сторон экрана 16х9
    /// </summary>
    public float CameraAxisMax16x9;

	/// <summary>
	/// Максимальное отклюнение камеры по оси Х при соотношении сторон экрана 16х10
	/// </summary>
	public float CameraAxisMax16x10;

	/// <summary>
	/// Максимальное отклюнение камеры по оси Х при соотношении сторон экрана 4х3
	/// </summary>
	public float CameraAxisMax4x3;

	float _cameraAxisMax;

    float _screenWidth;

    float _speed = 0.3f;
    
    Transform _cameraTransform;

	void Start () {
		float screenRatio = (float)Math.Round((float)Screen.width / (float)Screen.height, 2);
		if (screenRatio == 1.78f) // 16x9
			_cameraAxisMax = CameraAxisMax16x9;
		else if (screenRatio == 1.60f) // 16x10
			_cameraAxisMax = CameraAxisMax16x10;
		else if (screenRatio == 1.33f) // 4x3
			_cameraAxisMax = CameraAxisMax4x3;
		else
			throw new NotImplementedException (string.Format("Not implemented for Screen.width={0} and Screen.height={1}", Screen.width, Screen.height));

        _screenWidth = Screen.width;
        _cameraTransform = gameObject.transform.Find("MainCamera");
	}
	
	void Update () {
		float x;
		if (Input.mousePosition.x <= 1 && _cameraTransform.localPosition.x >= (-_cameraAxisMax))
        {
			x = _cameraTransform.localPosition.x - (_speed * Time.deltaTime);
			if(x < (-_cameraAxisMax))
				x = -_cameraAxisMax;
			_cameraTransform.localPosition = new Vector3(x, _cameraTransform.localPosition.y, _cameraTransform.localPosition.z);
        }
		else if(Input.mousePosition.x >= _screenWidth && _cameraTransform.localPosition.x <= _cameraAxisMax)
		{
			x = _cameraTransform.localPosition.x + (_speed * Time.deltaTime);
			if(x > _cameraAxisMax)
				x = _cameraAxisMax;
			_cameraTransform.localPosition = new Vector3(x, _cameraTransform.localPosition.y, _cameraTransform.localPosition.z);
		}
	}
}
