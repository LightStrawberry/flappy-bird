using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    public float timer;
    public int frameNumber = 10;//frame number one seconds(每秒显示的帧数)
    public int frameCount = 0;//frame counter（帧数统计）
	public int speed=4;//小鸟的速度

    // Use this for initialization
    void Start()
    {
        //this.rigidbody.velocity = new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //hard code here for test
        //Vector3 vel = this.rigidbody.velocity;
        //this.rigidbody.velocity = new Vector3(5, vel.y, vel.z);

        //animation
        if (GameManager._intance.GameState==GameManager.GAMESTATE_PLAYING)
        {
            timer+=Time.deltaTime;
            if (timer >= 1.0f / frameNumber)
            {
                frameCount++;
                timer -= 1.0f/frameNumber;
                int frameIndex = frameCount%3;
                //update material 's offset x
                //hov to set the property of(x offset)   Maintex:Main Texture
                this.renderer.material.SetTextureOffset("_MainTex", new Vector2(0.333333f * frameIndex, 0));
            }
        }

        if (GameManager._intance.GameState==GameManager.GAMESTATE_PLAYING)
        {
            //control jump
            if (Input.GetMouseButton(0))//left mouse button down
            {
                audio.Play();
                Vector3 vel2 = this.rigidbody.velocity;
                this.rigidbody.velocity = new Vector3(vel2.x, 5, vel2.z);
            }
        }
    }

    public void getLife()
    {
        rigidbody.useGravity = true;
        this.rigidbody.velocity = new Vector3(speed, 0, 0);
    }

	public void speedUp(){
		Vector3 vel2 = this.rigidbody.velocity;
		this.rigidbody.velocity = new Vector3(vel2.x+1, vel2.y, vel2.z);
	}
}
