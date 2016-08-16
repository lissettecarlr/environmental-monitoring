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
#include "Senser.h"
#include "HCHO.h"
#include "ZPH01.h"
#include "ESP8266.h"


//Timer T1(TIM1,1,2,3); //使用定时器计，溢出时间:1S+2毫秒+3微秒
USART com(1,115200,true);
USART senser(2,9600,true);
USART WIFI(3,115200,true);
//I2C abc(2); 
//PWM pwm2(TIM2,1,1,1,1,20000);  //开启时钟2的4个通道，频率2Whz
//InputCapture_TIM t4(TIM4, 400, true, true, true, true);
//InputCapture_EXIT ch1(GPIOB,6);
ADC pressure(1); //PA1读取AD值
//flash InfoStore(0x08000000+100*MEMORY_PAGE_SIZE,true);     //flash

GPIO ledRedGPIO(GPIOB,0,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);//LED GPIO
GPIO ledBlueGPIO(GPIOB,1,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);//LED GPIO
LED ledRed(ledRedGPIO);//LED red
LED ledBlue(ledBlueGPIO);//LED blue

ZPH01 zph01(senser);

int main()
{
//	ledBlue.On();
//	ledRed.Off();
	double record_SenserUpdata=0;
	double record_OrderDeal=0;
	double record_DataSend=0;
	double record_DataReceive=0;
	
	while(1) 
	{
		if(tskmgr.TimeSlice(record_SenserUpdata,0.5)) 
		{
			//数据更新
			
		}
		if(tskmgr.TimeSlice(record_OrderDeal,0.1))
		{
			//命令处理
		}
		if(tskmgr.TimeSlice(record_DataSend,1))
		{
			//数据发送
		}
		if(tskmgr.TimeSlice(record_DataReceive,0.02))
		{
			//数据接收
		}	
		
	}
}
