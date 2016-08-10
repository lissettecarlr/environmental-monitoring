#ifndef __TRANSMISSION_H
#define __TRANSMISSION_H

#include "stm32f10x.h"
#include "USART.h"
#include "esp8266.h"

/*define**************************************************/
#define HumidityNumber 		0x01
#define TemperatureNumber 0x02
#define CO2Number 				0x03
#define DustNumber 				0x04
#define HCHONumber				0x05

#define ModuleNuber       0x00000004

/*END*****************************************************/



class Transmission{
	
	private:
		u8 ModuleToModule[20];
		u8 ModuleToUser[20];
	public:
		Transmission();
	
	  u8 *ToServerPack(u8 DataType,u8 DataH,u8 DataL,u8 adc);
		u8 *ToClientPack(u8 DataType,u8 DataH,u8 DataL,u8 adc);
	

		u8 CommandParsing(u8 command[8]);//命令协议校验解包
	
		u8 GetStateOrder(USART &ListeningCOM);//监听某个端口 返回命令字节

		void SendAlive(esp8266 &esp,u8 DataType,bool mode); //true: send server   false send client
		
		bool GetWifiNameAndPassword(char *name,char *password,USART &ListeningCOM);
	
};

extern Transmission CMCT_Tool;

#endif
