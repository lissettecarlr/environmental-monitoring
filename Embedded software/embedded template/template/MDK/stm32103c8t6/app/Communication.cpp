#include "communication.h"



Communication::Communication()
{
	State=false; //false 待机 true 启动发送
	Resert=false;//复位
	Ack=false;//存确认
}


bool Communication::Calibration(u8 *data,int lenth,u8 check)
{
	u8 num=0; 
	for(int i=0;i<lenth;i++)
	{
		num+=data[i];
	}
	if(num == check)
		return true;
	else
		return false;
}

bool Communication::DataListening(USART &ListeningCOM)
{
		u8 ch=0;
		u8 data[10]={0};
		u8 num = ListeningCOM.ReceiveBufferSize();
		u16 Module=0;
		if(num>0)
		{
				ListeningCOM.GetReceivedData(&ch,1);
				if(ch == 0xff)
				{
					ListeningCOM.GetReceivedData(&ch,1);
					if(ch == 0xdd)
					{
						//功能字判断
						while(ListeningCOM.ReceiveBufferSize()<4);//等待数据
							ListeningCOM.GetReceivedData(data,4);		
						if( Calibration(data,4,data[3] )) //如果校验正确
						{
								Module=(u16)data[0]<<8+data[1];
								if(Module == ModuleNuber)
								{
									if(data[2] == 0x01) //待机
									{
										State = false;
									}
									else if(data[2] == 0x02)//启动
									{
										State = true;
									}
									else if(data[2] == 0x03)//复位
									{
										Resert=true;
									}
									else if(data[2] == 0xff)//存在确认
									{
											Ack = true;
									}
									else
									{
										return false;//未知命令
									}
								}
								else
									return false;//设备号错误
						}
						else
							return false; //校验错误				
					
					}
				}											
		}
			return false;//没接收到数据
		
}


u8 *Communication::ToServerPack(u8 DataType,float Value,u16 Multiple,float Adc)
{
	
	vs16 temp;
	SendData[0]=0XFF;
	SendData[1]=0XAA;
	SendData[2]=(ModuleNuber>>8) 	&0xff;
	SendData[3]=(ModuleNuber)			&0xff;
	//数据类型
	SendData[4]=DataType;
	
	temp = (int)(Value*Multiple);
	SendData[5]=BYTE1(temp);
	SendData[6]=BYTE0(temp);
	//电压
	temp = (int)(Adc*10);
	SendData[7]=temp;
	//保留
	SendData[8]=0;
	SendData[9]=0;
	for(u8 i=2;i<9;i++)
		SendData[9]+=SendData[i];
	return SendData;
	
}
