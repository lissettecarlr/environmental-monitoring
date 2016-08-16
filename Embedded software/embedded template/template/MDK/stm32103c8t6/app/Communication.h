#ifndef _COMMUNICATION_H_
#define _COMMUNICATION_H_

#include "stm32f10x.h"
#include "USART.h"
#include "Vector3.h"


#define BYTE0(dwTemp)       ( *( (char *)(&dwTemp)		) )
#define BYTE1(dwTemp)       ( *( (char *)(&dwTemp) + 1) )
#define BYTE2(dwTemp)       ( *( (char *)(&dwTemp) + 2) )
#define BYTE3(dwTemp)       ( *( (char *)(&dwTemp) + 3) )


/*define**************************************************/
#define TemperatureNumber 0x01
#define HumidityNumber 		0x02
#define CO2Number 				0x03
#define HCHONumber				0x04
#define DustNumber 				0x05

#define ModuleNuber       0x0001

/*END*****************************************************/


class Communication{
	
	private:
		u8 SendData[10];
		bool Calibration(u8 *data,int lenth,u8 check);
	
	public:
		
//接收
		bool State; //false 待机 true 启动发送
		bool Resert;//复位
		bool Ack;//存确认
	
		Communication();
		bool DataListening(USART &ListeningCOM);//数据接收监听
		
		//返回一个数据包,  数据类型，值，放大倍数，电压
		u8 *ToServerPack(u8 DataType,float Value,u16 Multiple,float Adc);
		
	
};



#endif
