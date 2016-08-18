/*
二氧化碳传感器驱动，单位是PPM。通信波特率为9600,范围大小在传感器上的贴纸有写
*/


#include "USART.h"
#include "TaskManager.h"


class MHZ14{

	private:
		USART &COM;
		u8 Command_getvalue[9]; //发送命令
		double Timeout; //操作超时时间
		u16 CO2_Concentration;
		bool SumCheck(u8 data[9]);
	public:
		MHZ14(USART &com,double timeout);
	
	  //返回数据: 1(数据更新成功)  2(数据获取超时) 3(校验错误)
		unsigned char Updata();//更新数据
		float GetFloatData(); //得到一个浓度数据
		
};
