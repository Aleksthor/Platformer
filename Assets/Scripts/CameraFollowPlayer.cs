using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Game.Main
{
    public class CameraFollowPlayer : MonoBehaviour
    {

        [SerializeField] private Transform player;
        private PixelPerfectCamera pixelCam;
        Camera cam;
        float width;
        float height;

        private void Awake()
        {
            cam = GetComponent<Camera>();
            pixelCam = GetComponent<PixelPerfectCamera>();
        }

        private void Start()
        {
            width = pixelCam.refResolutionX / pixelCam.assetsPPU;
            height = pixelCam.refResolutionY / pixelCam.assetsPPU;
        }

        private void Update()
        {
            float x = (player.position.x + (width / 2)) / width;
            float y = (player.position.y + (height / 2)) / height;

            transform.position = new Vector3(Mathf.FloorToInt(x) * width, Mathf.FloorToInt(y) * height, -10f); ;
        }


    }
}