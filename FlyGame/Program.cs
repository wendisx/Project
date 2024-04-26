using System;
using System.Runtime.CompilerServices;
namespace FlyGame{
    class Program{
        public static int[] Map= new int[100];//地图数组,默认全是0
        //玩家位置数组记录玩家坐标
        static int[] Playerpos=new int[2];
        //玩家姓名
        static string[] PlayerName=new string[2];
        //主函数接入口
        static void Main(string[] args){
                Show();
                #region 输入玩家信息
                Console.WriteLine("请输入玩家1的姓名：");
                PlayerName[0]=Console.ReadLine();
                while(PlayerName[0]==""){
                    Console.WriteLine("玩家名字不能为空");
                    PlayerName[0]=Console.ReadLine();
                }
                Console.WriteLine("请输入玩家2的姓名：");
                PlayerName[1]=Console.ReadLine();
                while(true){
                    if(PlayerName[1]==""){
                        Console.WriteLine("玩家姓名不能为空");
                    }
                    else if(PlayerName[1]==PlayerName[0]){
                            Console.WriteLine("玩家2不能和玩家1同名,请重新输入");
                    }
                    else{
                        break;
                    }
                    PlayerName[1]=Console.ReadLine();
                }
                #endregion
                //清除屏幕操作
                Console.Clear();
                Show();
                Console.ForegroundColor=ConsoleColor.Green;
                Console.WriteLine("{0}的棋子用AA表示，{1}的棋子用BB表示",PlayerName[0],PlayerName[1]);
                InitialMap();
                DrawMap();
                while(Playerpos[0]<99&&Playerpos[1]<99){
                    #region 方法折叠
                   /*  Console.WriteLine("{0}按任意键开始掷骰子...",PlayerName[0]);
                    Console.ReadKey(true);
                    Console.WriteLine("{0}掷出了一个4",PlayerName[0]);
                    Console.ReadKey(true);
                    Console.WriteLine("玩家{0}按任意键开始行动",PlayerName[0]);
                    //行动前进行坐标移动位置
                    Playerpos[0]+=4;
                    Console.ReadKey(true);
                    Console.WriteLine("玩家{0}行动完了...",PlayerName[0]);
                    //行动完进行基本判断
                    Checkstatus(Playerpos[0],Playerpos[1],PlayerName[0],PlayerName[1],0,1);
                    Console.Clear();
                    DrawMap();
                    Console.ReadKey(true); */
                    #endregion
                    //玩家1先玩
                    Play(0,1);
                    if(Playerpos[0]>=99){break;}
                    //玩家2后玩
                    Play(1,0);
                    }
                    //游戏结束
                    if(Playerpos[0]>=99){
                        Console.WriteLine("玩家{0}赢了",PlayerName[0]);
                    }
                    else if(Playerpos[1]>=99){
                        Console.WriteLine("玩家{0}赢了",PlayerName[1]);
                    }
                Console.ReadKey();
        }
        //打印游戏头
        public static void Show(){
            #region 游戏标题
            //Console.BackgroundColor=ConsoleColor.Yellow;
            Console.ForegroundColor=ConsoleColor.Magenta;
            Console.WriteLine("********************");
            Console.ForegroundColor=ConsoleColor.Green;
            Console.WriteLine("********************");
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("********************");
            Console.ForegroundColor=ConsoleColor.Yellow;
            Console.WriteLine("****飞行棋小游戏****");
            Console.ForegroundColor=ConsoleColor.Blue;
            Console.WriteLine("********************");
            Console.ForegroundColor=ConsoleColor.Cyan;
            Console.WriteLine("********************");
            Console.ForegroundColor=ConsoleColor.Gray;
            Console.WriteLine("********************");
            #endregion
        }
        //初始化地图
        public static void InitialMap(){
            #region 初始化地图
            //1、奖励前进----6个特殊点位为5,12,28,45,67,83
            int[] Up={5,12,28,45,67,83};
            for(int i=0;i<Up.Length;i++){
                //int index=Up[i];
                Map[Up[i]]=1;
            }
            //2、惩罚后退----6个特殊点位为6,13,38,64,98,47
            int[] Back={6,13,38,64,98,47};
            for(int i=0;i<Back.Length;i++){
                    // index=Back[i];
                    Map[Back[i]]=2;
            }
            //3、无法前进----6个特殊点位为34，2，10，57，72，81
            int[] Pause={34,2,10,57,72,81};
            for(int i=0;i<Pause.Length;i++){
                    //int index=Pause[i];
                    Map[Pause[i]]=3;
            }
            //4、传送前进----6个特殊点位为20,25,30,36,60,70
            int[] Transfer={20,25,30,36,60,70};
            for(int i=0;i<Transfer.Length;i++){
                    //int index=Transfer[i];
                    Map[Transfer[i]]=4;
            }
            #endregion
        }
        //画出地图
        public static void DrawMap(){
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine("解释：前进：Up    后退：bc    无法前进：pu    传送：ts");
            #region 打印一横行
            for(int i=0;i<30;i++){
                Console.Write(CheckMap(i));
            }
            #endregion
            #region 打印一竖行
            for(int i=30;i<35;i++){
                Console.WriteLine();
                for(int j=0;j<29;j++){
                    Console.Write("  ");
                }
                Console.Write(CheckMap(i));
            }
            Console.WriteLine();
            #endregion
            #region 打印第二横行
            for(int i=64;i>=35;i--){
                Console.Write(CheckMap(i));
            }
            Console.WriteLine();
            #endregion
            #region 打印第二竖行
            for(int i=65;i<70;i++){
                Console.WriteLine(CheckMap(i));
            }

            #endregion
            #region 打印最后一行
            for(int i=70;i<100;i++){
                Console.Write(CheckMap(i));
            }
            #endregion
            Console.WriteLine();
        }
        public static string CheckMap(int i){
            string str="";
            #region 判断模块
            if(Playerpos[0]==Playerpos[1]&&Playerpos[0]==i){
                    str="<>";
                }
                else if(Playerpos[0]==i){
                    Console.ForegroundColor=ConsoleColor.Cyan;
                    str="AA";
                }
                else if(Playerpos[1]==i){
                    Console.ForegroundColor=ConsoleColor.Magenta;
                    str="BB";
                }
                else{
                    switch (Map[i]){
                        
                        case 0:Console.ForegroundColor= ConsoleColor.White;str="00";break;
                        case 1:Console.ForegroundColor= ConsoleColor.Red;str="up";break;
                        case 2:Console.ForegroundColor= ConsoleColor.Green;str="bc";break;
                        case 3:Console.ForegroundColor= ConsoleColor.Yellow;str="pu";break;
                        case 4:Console.ForegroundColor= ConsoleColor.Gray;str="ts";break;
                    }
                }
                #endregion
                return str;
        }

        public static void Checkstatus(int index1,int index2,string name1,string name2,int mark1,int mark2){
            #region 状态判断逻辑
            //越界判断
            if(index1>99){
                return;
            }
            if(index1==index2){
                    Console.WriteLine("玩家{0}踩到了玩家{1},玩家{2}回退6格",name1,name2,name2);
                    Playerpos[mark2]-=6;
            }
            else{
                switch (Map[index1])
                {
                    case 0:Console.WriteLine("玩家{0}无事发生",name1);break;
                    //前进逻辑
                    case 1:Console.WriteLine("玩家{0}触发幸运事件，前进6格",name1);Playerpos[mark1]+=6;break;
                    //倒退逻辑
                    case 2:Console.WriteLine("玩家{0}触发倒霉事件，倒退5格",name1);Playerpos[mark1]-=5;break;
                    //暂停逻辑
                    case 3:Console.WriteLine("玩家{0}触发震慑事件，无法前进一回合",name1);Play(1,0);break;
                    //随机传送考虑使用随机数来模拟随机传送操作
                    case 4:Console.WriteLine("玩家{0}触发？事件，随机向前传送",name1);Random rd1=new Random();Playerpos[mark1]+=rd1.Next(1,10);break;
                }
            }
            #endregion
            Console.ReadKey(true);
        }
        public static void Play(int i,int j){
                    #region 游戏逻辑
                    Console.WriteLine("{0}按任意键开始掷骰子...",PlayerName[i]);
                    Console.ReadKey(true);
                    Random rd=new Random();
                    int cod=rd.Next(1,6);
                    Console.WriteLine("{0}掷出了一个{1}",PlayerName[i],cod);
                    Console.ReadKey(true);
                    Console.WriteLine("玩家{0}按任意键开始行动",PlayerName[i]);
                    //行动前进行坐标移动位置
                    Playerpos[i]+=cod;
                    Console.ReadKey(true);
                    Console.WriteLine("玩家{0}行动完了...",PlayerName[i]);
                    //行动完进行基本判断
                    Checkstatus(Playerpos[i],Playerpos[j],PlayerName[i],PlayerName[j],i,j);
                    Console.Clear();
                    DrawMap();
                    Console.ReadKey(true);
                    #endregion
        }
    }
}