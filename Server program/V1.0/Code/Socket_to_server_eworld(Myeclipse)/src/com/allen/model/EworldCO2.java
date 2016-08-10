package com.allen.model;

public class EworldCO2 extends Eworld{
	private int eData;	//设备数据 4-400w?
	private String DeviceName= "CO2传感器";
	
	
	public String getDeviceName() {
		return DeviceName;
	}

	public int geteData() {
		return eData;
	}

	public void seteData(int eData) {
		this.eData = eData;
	}
}
