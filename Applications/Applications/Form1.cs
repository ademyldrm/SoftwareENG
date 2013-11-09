using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Applications
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #include<conio.h>
#include<stdlib.h>
#include<graphics.h>
#include<stdarg.h>
#include<stdio.h>
#include<dos.h>
#include<mouse.h>


#define getb() Get_Button(&b,&x,&y)
#define tcap 20
#define orta_x getmaxx()/2
#define orta_y getmaxy()/2
#define xbas orta_x-8*tcap
#define ybas orta_y-8*tcap


void graph(void);
void tahta_ciz(void);
void tas_ciz(void);
void oyna();
void hakkinda();
void tas_ciz();
void tas_al(void);
void tas_koy(void);
void buton_ciz(int,int,int,int);
void golge(int,int,int,int);
void koord(void);
void menu(void);
//void kontrol(void);
//********************* Globals ************************************

int b,x,y;
int xs,ys;//solo dizisi icin x,y
int x1,y1;//tas_al daki x,y
int xm,ym;//mouse icin x,y
int solo[9][9];
int tas_sayisi;
int en_iyi=44;



//************************** main **********************************
void main()

{

graph();
setbkcolor(GREEN);

settextstyle(12,0,4);

//setfillstyle(1,BLUE);


buton_ciz(550,80,630,100);
setcolor(YELLOW);
outtextxy(555,87,"YENi OYUN");

buton_ciz(550,110,630,130);
setcolor(YELLOW);
outtextxy(555,117,"HAKKINDA");

buton_ciz(550,140,630,160);
setcolor(YELLOW);
outtextxy(570,145,"CIKIS");


Show_Mouse();
Set_Mouse_Coor(570,300);

tahta_ciz();






while(1)
{
getb();
menu();

}



}

//************************************************** *********************
void menu(void)
{
while(b==1 && x>=550 && x<=630 && y>=80 && y<=100)
{
golge(550,80,630,100);
delay(250);
getb();
if(b!=1)
{
buton_ciz(550,80,630,100);

if(x>=550 && x<=630 && y>=80 && y<=100)
oyna();

else break;
}
}

while(b==1 && x>=550 && x<=630 && y>=110 && y<=130)
{
golge(550,110,630,130);

getb();
if(b!=1)
{
buton_ciz(550,110,630,130);

if(x>=550 && x<=630 && y>=110 && y<=130)
hakkinda();

else
break;

}
}



while(b==1 && x>=550 && x<=630 && y>=140 && y<=160)
{
golge(550,140,630,160);

getb();
if(b!=1)
{
buton_ciz(550,140,630,160);

if(x>=550 && x<=630 && y>=140 && y<=160)
exit(1);
else break;
}
}
}
//************************************************** *********************


void koord() //ilk atamay� yapar
{int yk,xk;//koord i‡in x,y

for(yk=0;yk<9;yk++)
for(xk=0;xk<9;xk++)
{
if((xk>=3 && xk<=5)||(yk>=3 && yk<=5))
solo[yk][xk]=1;
else solo[yk][xk]=2;
}
solo[4][4]=0;
tas_sayisi=44;
}

//************************************************** *********************
void graph(void)
{ //grafik modu a‡ar
int GrA,GrM,h_k;
detectgraph(&GrA,&GrM);

initgraph(&GrA,&GrM,"c:tcbgi");
h_k = graphresult();
if (h_k != grOk)
{
printf("Graphics error: %s
", grapherrormsg(h_k));
printf("Press any key to halt:");
getch();
}
}

//************************************************** *********************
void hakkinda()
{
int x=getmaxx()/2,y=getmaxy()/2;

setfillstyle(2,LIGHTGRAY);
fillellipse(x+5,y+5,150,75);

setcolor(LIGHTGREEN);
setfillstyle(1,BLUE);

fillellipse(x,y,150,75);
setcolor(YELLOW);
outtextxy(x-70,y-45,"*** SOLO TEST ***");
outtextxy(x-70,y-30,"Ali Kemal TASCI");
outtextxy(x-120,y-15,"KARADENiZ TEKNiK UNiVERSiTESi");
outtextxy(x-125,y,"BiLGiSAYAR MUHENDiSLiGi BOLUMU");
outtextxy(x-95,y+15,"ali_kemal_tasci@yahoo.com");
outtextxy(x-35,y+30,"29.06.2002");
}


//************************************************** *********************
void tahta_ciz()
{


int tacap=10*tcap; //tacap:tahtanin yaricapi,tcap:tasin yaricapisetcolor(YELLOW);
setfillstyle(1,BLUE);

fillellipse(orta_x,orta_y,tacap,tacap);
}

//************************************************** ****************
void tas_ciz() //3:secili,1:dolu,0:bos,2yun disi alan
{
setcolor(YELLOW);

for(y=0;y<9;y++)

for(x=0;x<9;x++)
{

if(solo[y][x]==1)
setfillstyle(1,RED);

else if(solo[y][x]==0)
setfillstyle(1,LIGHTRED);
else if(solo[y][x]==3)

setfillstyle(9,RED);

else continue;


fillellipse((xbas+x*2*tcap),(ybas+y*2*tcap),tcap,t cap);

}
}

//************************************************** ****************
void oyna()
{

char sayi[20];
char eniyi[20];

koord();
tahta_ciz();
tas_ciz();




while(1)
{

setcolor(YELLOW);
setfillstyle(1,BLUE);
bar(0,getmaxy()-40,180,getmaxy());
itoa(en_iyi,eniyi,10);
outtextxy(5,getmaxy()-35,"EN iYi SAYI >>");
outtextxy(155,getmaxy()-35,eniyi);
setlinestyle(CENTER_LINE,0,1);
line(0,getmaxy()-20,180,getmaxy()-20);

setlinestyle(SOLID_LINE,0,1);



itoa(tas_sayisi,sayi,10);
outtextxy(5,getmaxy()-15,"KALAN TAS SAYISI>>");
outtextxy(155,getmaxy()-15,sayi);

tas_al();



Hide_Mouse();
tas_ciz();
Show_Mouse();
Set_Mouse_Coor(xm,ym);

delay(250);//bunu yapmazsan b'nindegeri cok hizli dongu oldugu icin degismiyor

tas_koy();

Hide_Mouse();
tas_ciz();
Show_Mouse();
Set_Mouse_Coor(xm,ym);

delay(250);

if(tas_sayisi<en_iyi) en_iyi=tas_sayisi;

}



}

//************************************************** ****************
void tas_al()
{
getb();


while(1)
{
getb();
ys=(y-(ybas-tcap))/(2*tcap);
xs=(x-(xbas-tcap))/(2*tcap);

if(b==1 && x>(xbas-tcap) && x<(orta_x+9*tcap)&& y>(ybas-tcap) && y<(orta_y+9*tcap) )
{
if(solo[ys][xs]==1)
{
if(((solo[ys+1][xs]==1)&&(solo[ys+2][xs]==0))||((solo[ys-1][xs]==1)&&(solo[ys-2][xs]==0))
||((solo[ys][xs+1]==1)&&(solo[ys][xs+2]==0))||((solo[ys][xs-1]==1)&&(solo[ys][xs-2]==0)) )
{
x1=xm=x;
y1=ym=y;
solo[ys][xs]=3;
break;
}
}
}




menu();


}
x1=(x1-(xbas-tcap))/(2*tcap);
y1=(y1-(ybas-tcap))/(2*tcap);


}

//************************************************** ****************
void tas_koy()
{

getb();
while(1)
{
getb();

xs=(x-(xbas-tcap))/(2*tcap);
ys=(y-(ybas-tcap))/(2*tcap);

if(b==1&&x1==xs&&y1==ys)
{
solo[y1][x1]=1;
xm=x;
ym=y;
break;
}


else if(b==1 && x>(xbas-tcap) && x<(orta_x+9*tcap)&& y>(ybas-tcap) && y<(orta_y+9*tcap) )
{if(solo[ys][xs]==0)
{
if(xs==x1)
{
if(ys==y1+2&&solo[ys-1][xs]==1)
{
solo[y1][x1]=0;
solo[ys-1][xs]=0;
solo[ys][xs]=1;
xm=x;
ym=y;
tas_sayisi--;
break;

}
else if(ys==y1-2&&solo[ys+1][xs]==1)

{
solo[y1][x1]=0;
solo[ys+1][xs]=0;
solo[ys][xs]=1;
xm=x;
ym=y;
tas_sayisi--;
break;
}
}

else if(ys==y1)
{
if(xs==x1+2&&solo[ys][xs-1]==1)
{
solo[y1][x1]=0;
solo[ys][xs-1]=0;
solo[ys][xs]=1;
xm=x;
ym=y;
tas_sayisi--;
break;
}
else if(xs==x1-2&& solo[ys][xs+1]==1)

{
solo[y1][x1]=0;
solo[ys][xs+1]=0;
solo[ys][xs]=1;
xm=x;
ym=y;
tas_sayisi--;
break;
}
}
}

}
menu();


}

}

///************************************************** ********************

void buton_ciz(int x1,int y1,int x2,int y2)
{
setcolor(WHITE);
line(x1,y1,x1,y2);
line(x1,y1,x2,y1);

setcolor(BLUE);
line(x2,y1,x2,y2);
line(x1,y2,x2,y2);

}
//************************************************** ********************
void golge(int x1,int y1,int x2,int y2)
{
setcolor(BLUE);
line(x1,y1,x1,y2);
line(x1,y1,x2,y1);


setcolor(WHITE);
line(x2,y1,x2,y2);
line(x1,y2,x2,y2);

}
/************************** BAZI NOTLAR **********************************
->grafic hatasi verirse c:tcbgi yazan yere sizin bgi klasorunuzun yolunu yazin

->asagidaki mouse.h baslik dosyasini .h uzantisiyla include dosyanizin icine kopyalayin

->dilek ve sikayetleriniz icin bana yazin
*/
/*********** mouse.h **************************************************

union REGS reg;
int X,Y,Xo,Yo,B,R,Bo;
void *Head_Buf;
int ply[14];

int gggprintf( int xloc, int yloc, char *fmt, ... )
{
va_list argptr;
char str[14];
int cnt;
va_start( argptr,fmt );
cnt = vsprintf( str, fmt, argptr );
outtextxy( xloc, yloc, str );
va_end( argptr );
return( cnt );

}

void Show_Mouse(void)
{ reg.x.ax=1;
int86(0x33,®,®);
}

void Hide_Mouse(void)
{ reg.x.ax=0;
int86(0x33,®,®);
}

void Set_Mouse_Sens(int B,int C,int D)
{ reg.x.ax=0;
reg.h.al=0x1a;
reg.x.bx=B;
reg.x.cx=C;
reg.x.dx=D;
int86(0x33,®,®);
}

void Set_Mouse_Coor(int XCoor,int YCoor)
{ reg.x.ax=0;
reg.h.al=4;
reg.x.cx=XCoor;
reg.x.dx=YCoor;
int86(0x33,®,®);
}

char Get_Button(int *B,int *XCoor,int *YCoor)
{ reg.x.ax=0;
reg.h.al=3;
int86(0x33,®,®);
*XCoor=reg.x.cx;
*YCoor=reg.x.dx;
if (reg.x.bx&1&&reg.x.bx&2) *B=3;
else if (reg.x.bx&1) *B=1;
else if (reg.x.bx&2) *B=2;
else *B=0;
return *B;
}

void Set_Mouse_Range(int Xmin,int Ymin,int Xmax,int Ymax)

{ reg.x.ax=0;
reg.h.al=7;
reg.x.cx=Xmin;
reg.x.dx=Xmax;
int86(0x33,®,®);
reg.x.ax=0;
reg.h.al=8;
reg.x.cx=Ymin;
reg.x.dx=Ymax;
int86(0x33,®,®);
}
void Put_Head(int x,int y,char r)
{ if (!r)
putimage(x,y,Head_Buf,0);
else { getimage(x,y,x+8,y+8,Head_Buf);
setcolor(10);
setfillstyle(SOLID_FILL,r);
ply[0]=x; ply[1]=y;
ply[2]=x; ply[3]=y+6;
ply[4]=x+2; ply[5]=y+3;
ply[6]=x+5; ply[7]=y+7;
ply[8]=x+2; ply[9]=y+3;
ply[10]=x+6;ply[11]=y+3;
ply[12]=x; ply[13]=y;
fillpoly(6,ply);
}
}
        }
    }
}
