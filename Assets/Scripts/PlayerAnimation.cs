using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public Animator anim;
	private bool Diagonal;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//8-way movement animations
		if(Input.GetKey(KeyCode.W) && Diagonal == false){
			anim.SetBool("Up", true);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", true);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.D) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", true);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", true);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.S) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", true);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", true);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", false);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.A) && Diagonal == false){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", true);
			anim.SetBool("UpLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			anim.SetBool("Up", false);
			anim.SetBool("UpRight", false);
			anim.SetBool("Right", false);
			anim.SetBool("DownRight", false);
			anim.SetBool("Down", false);
			anim.SetBool("DownLeft", false);
			anim.SetBool("Left", false);
			anim.SetBool("UpLeft", true);
			Diagonal = true;
		}
		if(Input.GetKey(KeyCode.W) && Diagonal == false){
			anim.SetBool("RunUp", true);
		}
		else{
			anim.SetBool("RunUp", false);
		}
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)){
			anim.SetBool("RunUpRight", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunUpRight", false);
		}
		if(Input.GetKey(KeyCode.D) && Diagonal == false){
			anim.SetBool("RunRight", true);
		}
		else{
			anim.SetBool("RunRight", false);
		}
		if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)){
			anim.SetBool("RunDownRight", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunDownRight", false);
		}
		if(Input.GetKey(KeyCode.S) && Diagonal == false){
			anim.SetBool("RunDown", true);
		}
		else{
			anim.SetBool("RunDown", false);
		}
		if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)){
			anim.SetBool("RunDownLeft", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunDownLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Diagonal == false){
			anim.SetBool("RunLeft", true);
		}
		else{
			anim.SetBool("RunLeft", false);
		}
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)){
			anim.SetBool("RunUpLeft", true);
			Diagonal = true;
		}
		else{
			anim.SetBool("RunUpLeft", false);
		}
		Diagonal = false;
		
		//Attack animation
		if(GetComponent<Player>().hasBottle){
			if(anim.GetBool("AttackDown")){
				anim.SetBool("AttackDown", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("Down") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunDown")){
				anim.SetBool("AttackDown", true);
			}
			if(anim.GetBool("AttackDownLeft")){
				anim.SetBool("AttackDownLeft", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("DownLeft") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunDownLeft")){
				anim.SetBool("AttackDownLeft", true);
			}
			if(anim.GetBool("AttackLeft")){
				anim.SetBool("AttackLeft", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("Left") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunLeft")){
				anim.SetBool("AttackLeft", true);
			}
			if(anim.GetBool("AttackUpLeft")){
				anim.SetBool("AttackUpLeft", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("UpLeft") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunUpLeft")){
				anim.SetBool("AttackUpLeft", true);
			}
			if(anim.GetBool("AttackUp")){
				anim.SetBool("AttackUp", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("Up") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunUp")){
				anim.SetBool("AttackUp", true);
			}
			if(anim.GetBool("AttackUpRight")){
				anim.SetBool("AttackUpRight", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("UpRight") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunUpRight")){
				anim.SetBool("AttackUpRight", true);
			}
			if(anim.GetBool("AttackRight")){
				anim.SetBool("AttackRight", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("Right") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunRight")){
				anim.SetBool("AttackRight", true);
			}
			if(anim.GetBool("AttackDownRight")){
				anim.SetBool("AttackDownRight", false);
			}
			if(Input.GetKeyUp(KeyCode.E) && anim.GetBool("DownRight") || Input.GetKeyUp(KeyCode.E) && anim.GetBool("RunDownRight")){
				anim.SetBool("AttackDownRight", true);
			}
		}
		else{
			return;
		}
	}
}
