package com.allen.model;

public class EworldDust extends Eworld{
	private float eData;
	private String DeviceName= "·Û³¾£¨PM2.5£©´«¸ÐÆ÷";
	
	
	public String getDeviceName() {
		return DeviceName;
	}
	public float geteData() {
		return eData;
	}

	public void seteData(float eData) {
		this.eData = eData;
	}
}
