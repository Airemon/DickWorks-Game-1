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
	}
}
