using System;
namespace HelloWorld{
    //声明一个性别的枚举类型
    public enum gender{
        男,
        女
    }
    //声明一个人的类
    class Person{
        private string name;
        private int age;
        private gender sex;
        public  Person(){
            name=null;
            age=0;
            sex=gender.男;
        }
        public Person(string name,int age,gender sex){
            this.name=name;
            this.age=age;
            this.sex=sex;
        }
        public void Eat(){
            Console.WriteLine("我一天吃三餐饭。");
        }
        public void Study(){
            Console.WriteLine("我热爱学习");
        }
        public int GetAge(){return age;}
        public string GetName(){return name;}
        public gender GetSex(){return sex;}
    };
class Program
{
    //public static int a=3;
    static void Main(string[] args)
    {
        //创建一个对象并对对象进行赋值
       /* Person me=new Person("qirenzheng",18,gender.男);
       Console.WriteLine("你的名字是{0},你的年龄是{1},你的性别是{2}",me.GetName(),me.GetAge(),me.GetSex());
       Console.ReadKey(); */
       //创建可输入的一个实例
        Console.WriteLine("请输入你的姓名：");
        string me_name=Console.ReadLine();
        Console.WriteLine("请输入你的年龄：");
        int me_age=Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("请输入你的性别：");
        gender me_sex=(gender)Enum.Parse(typeof(gender),Console.ReadLine());
        Person me=new Person(me_name,me_age,me_sex);
        Console.WriteLine("是否查询：");
        Console.WriteLine("1、是------2、否");
        int flag=Convert.ToInt32(Console.ReadLine());
        if(flag==1){
                Console.WriteLine("你要查询的内容是：");
                Console.WriteLine("1、姓名");
                Console.WriteLine("2、年龄");
                Console.WriteLine("3、性别");
                int element=Convert.ToInt32(Console.ReadLine());
                switch (element){
                    case 1:Console.WriteLine("你的姓名是：{0}",me.GetName());
                    break;
                    case 2:Console.WriteLine("你的年龄是：{0}",me.GetAge());
                    break;
                    case 3:Console.WriteLine("你的性别是：{0}",me.GetSex());
                    break;
                    default:Console.WriteLine("--------结束---------");
                    break;
                }
        }
        Console.ReadKey();
    }
}
}