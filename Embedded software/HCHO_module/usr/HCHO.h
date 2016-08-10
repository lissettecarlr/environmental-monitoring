#ifndef _HCHO_H
#define _HCHO_H

#include <stm32f10x.h>
#include "USART.h"


#define HCHO_DATASIZE 20

#define _HCHO 0x14

#define PPM 	0x01
#define VOL 	0x02
#define LEL 	0x03
#define PPB 	0x04
#define MGM3 	0x05



class HCHO
{
	private:
		
		USART &mUsart;
		float data;
		unsigned char mData[HCHO_DATASIZE];			//数据区
	
	public:
			
		u8 data_h;
	  u8 data_l;
	

	
		HCHO(USART &usart);
	
		~HCHO();
	
		/**
		*@brief 和校验函数（只是简单的将数据求和）
		*@param data :要生成和校验的数据的首地址
		*/
		unsigned short LRC(unsigned char *data,unsigned char len);
		

		bool Updata();
	
		/**
		*@brief 得到甲醛浓度的数据
		*@retval 甲醛浓度的高低字节数据
		*/
		float GetData();
};


#endif
