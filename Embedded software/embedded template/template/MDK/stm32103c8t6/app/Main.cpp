#include "stm32f10x.h"
#include "Configuration.h"
#include "TaskManager.h"
#include "USART.h"
#include "I2C.h"
#include "Timer.h"
#include "ADC.h"
#include "PWM.h"
#include "flash.h"
#include "InputCapture_TIM.h"
#include "InputCapture_EXIT.h"
#include "LED.h"
#include "MHZ14.h"
#include "HCHO.h"
#include "ZPH01.h"
#include "ESP8266.h"


//Timer T1(TIM1,1,2,3); //使用定时器计，溢出时间:1S+2毫秒+3微秒
USART com(1,115200,true);
USART senser(2,9600,true);
USART WIFI(3,115200,true);
esp8266 wifi(WIFI);
//I2C abc(2); 
//PWM pwm2(TIM2,1,1,1,1,20000);  //开启时钟2的4个通道，频率2Whz
//InputCapture_TIM t4(TIM4, 400, true, true, true, true);
//InputCapture_EXIT ch1(GPIOB,6);
//ADC pressure(1); //PA1读取AD值
//flash InfoStore(0x08000000+100*MEMORY_PAGE_SIZE,true);     //flash

GPIO ledRedGPIO(GPIOB,0,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);//LED GPIO
GPIO ledBlueGPIO(GPIOB,1,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);//LED GPIO
LED ledRed(ledRedGPIO);//LED red
LED ledBlue(ledBlueGPIO);//LED blue

//ZPH01 zph01(senser);
//MHZ14 CO2(senser,1);

int main()
{
	tskmgr.DelayS(1);
	double record_SenserUpdata=0;
	double record_OrderDeal=0;
	double record_DataSend=0;
	double record_DataReceive=0;
	u8 exception;
	bool network;
	bool UpdataErrorNumber=0;
	
	//服务器连接
	 exception=wifi.ConnectNetwork_client("Tenda_0202","f19940202","192.168.0.102",1111);
	 if(exception==0xff)
	 {
			com<<"connect succeed"<<"\n";
			network=true;  
	 }
	 else
	 {
		 com<<"connect fail,errorNumber:"<<exception<<"\n";
		 network=false; 
	 }
	
	 if(!network)
		 ledRed.On();
	 else
		 ledRed.Blink(4,300,true);
	 
	while(1) 
	{
		if(tskmgr.TimeSlice(record_SenserUpdata,0.5)) 
		{
//			//数据更新
//			UpdataErrorNumber=CO2.Updata();
//			if(UpdataErrorNumber ==1)
//				com<<CO2.GetFloatData()<<"\n";
//			else	if(UpdataErrorNumber ==2)
//				com<<"timeout !\n";
//			else	if(UpdataErrorNumber ==3)
//				com<<"Check error \n";		
		}
		
		if(tskmgr.TimeSlice(record_OrderDeal,0.1))
		{
			//命令处理
		}
		if(tskmgr.TimeSlice(record_DataSend,1))
		{
			//数据发送
			wifi.Send("fengfengfeng");
		}
		if(tskmgr.TimeSlice(record_DataReceive,0.02))
		{
			//数据接收
		}	
		
	}
}
