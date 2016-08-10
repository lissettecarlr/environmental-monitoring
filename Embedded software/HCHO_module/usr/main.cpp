
#include "stdlib.h"
#include "ADC.h"
#include "GPIO.h"
//#include "Timer.h"
#include "USART.h"
#include "Memory.h"
#include "Interrupt.h"
#include "TaskManager.h"
#include "HCHO.h"
#include "transmission.h"
#include "ESP8266.h"
#include "Hint.h"
#include "WIFI_Memory.h"


/*DEFINE********************************************************/
#define DELAY 					0x01
#define START 					0x02
#define GETWIFI					0x03
#define REGISTER 				0xaa
#define BEEP 						0xBB
#define RESET 					0XCC
#define MODEL 					0xEE
#define ALIVE 					0xff


#define MODULE_IP 			"10.10.10.4"   
#define MODULE_COM			9000
#define SERVER_IP				"120.27.119.115"                          //"120.27.119.115"
#define TEST_SERVER_IP  "106.91.24.83"
#define SERVER_COM 			1111
/*END********************************************************/


USART com(1,115200,true);   //USART1
USART WIFI(3,115200,true);   //USART3
USART senser(2,9600,true);

GPIO Beep(GPIOA,11,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);
GPIO Led(GPIOB,0,GPIO_Mode_Out_PP,GPIO_Speed_50MHz);

Memory InfoStore(0x08000000+100*MEMORY_PAGE_SIZE,true);//ip存储，长度+IP地址的存档格式，先读取出字符串长度 0x08019000
WifiMemory wifimemory(InfoStore);

HCHO Hcho(senser);
esp8266 wifi(WIFI);

hint Hint(Led,Beep);


int main(){
	
	u8 order=0;
	u8 exception;  //保存wifi连接的返回信息，其中0xff表示无异常
	double record_updataSensor=0;
	double record_alive=0;
	double record_getwifi=0;
	bool network=false ; //网络连接标识位 
	char *ip = (char*)calloc(15, sizeof(char*) ); 
	char *WifiName = (char*)calloc(20, sizeof(char*) ); 
	char *WifiPassword = (char*)calloc(20, sizeof(char*) ); 


/*开机WIFI模式选择*****************************************************************/
	tskmgr.DelayS(2);
//	if(wifimemory.getWifiSum()!=0)//判断表中是否已经保存wifi信息
//	{
//		while( wifimemory.Load(WifiName,WifiPassword) )
//		 {
//			  if(wifi.ConnectNetwork_client(WifiName,WifiPassword,SERVER_IP,1111)) //每次连接历时20秒
//				{network=true;   break;}
//		 }
//		 if(network ==false) {
//			  wifi.ConnectNetwork_server(MODULE_COM,0);
//			 	WIFI.ClearReceiveBuffer();
//		 }
//	}
//  else
//	{
//		 wifi.ConnectNetwork_server(MODULE_COM,0);
//			WIFI.ClearReceiveBuffer();
//	}	


//		if(wifi.CreateConnectMode(SERVER_IP,1111))
//		{
//			com<<"connet succeed"<<"\n";
//			CMCT_Tool.SendAlive(wifi,HCHONumber,1);
//			network=true;  
//		}
//		else
//		{
//			com<<"connet FAIL"<<"\n";
//			network=false; 
//		}
	
	 exception=wifi.ConnectNetwork_client("FFF","f19940202","106.91.20.100",1111)
	 if(exception==0xff)
	 {
			CMCT_Tool.SendAlive(wifi,HCHONumber,1);
			com<<"connect succeed"<<"\n";
			network=true;  
	 }
	 else
	 {
		 com<<"connect fail,errorNumber:"<<exception<<"\n";
		 exception=wifi.ConnectNetwork_server(9999);
		 if(exception ==0xff){
				com<<"create succeed"<<"\n";
				CMCT_Tool.SendAlive(wifi,HCHONumber,1);
		 }
		 else
			  com<<"create fail,errorNumber:"<<exception<<"\n";
	 }

	//Led.SetLevel(1);//将指示灯熄灭（模式切换结束）
/*END*********************************************************************************/	
	
/*Hint********************************************************************************/
	//闪烁后熄灭LED
	if(network)
	{
		Hint.ledFlicker_2s();
		Led.SetLevel(1);
	}
		
/*END********************************************************************************/	
	
	while(1)
	{		
//		com<<Hcho.data_h<<"\t"<<Hcho.data_l<<"\n";
		
		order=CMCT_Tool.GetStateOrder(WIFI); //当没有命令的时候返回0
		switch(order)
		{
			case DELAY:{}break;
	/*启动********************************************************************************************/
			case START:{//启动
				while(1){
							if(tskmgr.ClockTool(record_updataSensor,3)) //每三秒执行一次更新
							{
										Hcho.Updata();
										if(Hcho.Updata())
										{
											if(network)
											{
												wifi.Send(20,CMCT_Tool.ToServerPack(HCHONumber,Hcho.data_h,Hcho.data_l,0));
												com<<Hcho.data_h<<"\t"<<Hcho.data_l<<"\n";
											}
											else
												wifi.Send(0,20,CMCT_Tool.ToClientPack(HCHONumber,Hcho.data_h,Hcho.data_l,0));	
										}
							}
							if(CMCT_Tool.GetStateOrder(WIFI)==DELAY)
							break;					
				}
			}break;
	/*END********************************************************************************************/
			
	/*复位******************************************************************************************/
			case RESET:{//复位
					wifimemory.ClearAllData(); //清空所有保存信息
					*((u32 *)0xE000ED0C) = 0x05fa0004;
			}break;
	/*END******************************************************************************************/
			
	/*获取WIFI信息*********************************************************************************/		
			case GETWIFI:{//得到wifi账号密码
				record_getwifi=tskmgr.Time();
					while(1)
					{
						if(CMCT_Tool.GetWifiNameAndPassword(WifiName,WifiPassword,WIFI) )
						{
							//保存WIFI账号密码
							com<<"get:"<<WifiName<<"\t"<<WifiPassword<<"\n";
							wifimemory.Save(WifiName,WifiPassword);
								break;
						}
						if(tskmgr.ClockTool(record_getwifi,60)) //超时60秒退出
						   break;
					}
			}break;
	/*END******************************************************************************************/
			
	/*模式切换*************************************************************************************/
			case MODEL:{//模式切换
						u8 temp = wifi.ConnectNetwork_server(MODULE_COM);
						if(temp == 0xff)
						{
							WIFI.ClearReceiveBuffer();
							network=false;
							com<<"server mode------";
						}
						else
						{
							com<<"change fail , errorNumber:"<<temp<<"\n";
						}
			}break;
	/*END******************************************************************************************/

	/*存活确认*************************************************************************************/			
			case ALIVE:{//存活确认
				if(network)
					CMCT_Tool.SendAlive(wifi,HCHONumber,1); //存活确认，数据位全为0xff
				else
					CMCT_Tool.SendAlive(wifi,HCHONumber,0);
			}break;			
	/*END******************************************************************************************/
			
	/*常态*****************************************************************************************/
			default:		
			{  
					if(tskmgr.ClockTool(record_alive,30)) //每60秒发送一次存活确认
					{
						if(network)
							CMCT_Tool.SendAlive(wifi,HCHONumber,1);
						else
							CMCT_Tool.SendAlive(wifi,HCHONumber,0);
					}
					
					if(tskmgr.ClockTool(record_updataSensor,1)) 
					{
							Hcho.Updata();
					}
			}
	/*END******************************************************************************************/
		}		
	}
}


/*
测试命令数据

获取wifi：ff dd 00 00 00 04 03 e3
停止发送：ff dd 00 00 00 04 01 E2
发送数据：ff dd 00 00 00 01 02 E2
存活确认：ff dd 00 00 00 01 ff DF

ff cc 00 00 00 04 05 00 00 00 00 00 00 00 00 00 00 00 00 d4

WIFI信息  ff 03 46 46 46 ff 66 31 39 39 34 30 32 30 32 ff
					FF 03 46 46 46 FF 66 31 39 39 34 30 32 30 32 FF 

*/
