using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PID
{
    public partial class frmMain : Form
    {
        PID frmPid;
        Box frmBox;
        const int yBase = 500;
        const int yMul = 5;
        const int xMul = 1;
        int time = 0;//上次采样时间 时间为秒
        Point lastPoint;
        decimal maxLevel = 0;//最大值用于求超调
        public frmMain()
        {
            InitializeComponent();
            frmPid = new PID();
            frmBox = new Box(20, 0.3m, 0.1m, 0m, 0.5m);
            Init();
        }
        //初始化
        private void Init()
        {
            using (Graphics g = panel2.CreateGraphics())
            {
                Pen whitePen = new Pen(Brushes.White, 2000);
                Point point1 = new Point(0, 0);
                Point point2 = new Point(0, 2000);
                g.DrawLine(whitePen, point1, point2);
            }
            maxLevel = 0;
            time = 0;
            lastPoint = new Point(0, yBase);
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            Start(0);
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            Start(1);
        }

        /// <summary>
        /// 开始
        /// </summary>
        /// <param name="number">0使用普通pi调节，1使用改进pi调节</param>
        private void Start(int number)
        {
            Init();
            frmPid.Init(0.8m, numP.Value, numI.Value, 0, 1);
            frmBox.Init();
            Pen bluePen = new Pen(Brushes.Blue, 1);
            using (Graphics g = panel2.CreateGraphics())
            {
                Point point1 = new Point(0, yBase - Convert.ToInt32(frmPid.Target * 100) * yMul);
                Point point2 = new Point(1000, yBase - Convert.ToInt32(frmPid.Target * 100) * yMul);
                g.DrawLine(bluePen, point1, point2);
            }
            bool complete = false;
            for (int i = 0; i < 1000; i++)
            {
                {
                    time++;
                    frmBox.ChangeLevel();
                    Pen blackPen = new Pen(Brushes.Black, 1);
                    using (Graphics g = panel2.CreateGraphics())
                    {
                        Point point = new Point(time * xMul, yBase - Convert.ToInt32(frmBox.GetLevel() * 100) * yMul);
                        g.DrawLine(blackPen, point, lastPoint);
                        lastPoint = point;
                    }
                    decimal degreeIn = frmPid.GetOutPutValue(frmBox.GetLevel(), number);
                    frmBox.ChangeDegreeIn(degreeIn);
                }

                if (frmBox.GetLevel() > maxLevel)
                {
                    maxLevel = frmBox.GetLevel();
                }
                if ((Math.Abs(frmBox.GetLevel() - frmPid.Target) / frmPid.Target < 0.01m) && (!complete))
                {
                    complete = true;
                    lblInfo2.Text = "调节时间：" + time;
                }
            }
            decimal up = 0;
            if (maxLevel > frmPid.Target)
            {
                up = (maxLevel - frmPid.Target) / frmPid.Target;
            }
            lblInfo1.Text = "超调：" + up.ToString("0.000");
        }
    }

    public class Box
    {
        private List<decimal> levelList;
        private decimal area; //底面积  平方米
        private decimal maxFlowOut = 0.05m; //出水阀最大流量立方每秒
        private decimal maxFlowIn = 0.1m;  //进水阀最大流量 立方每秒
        private decimal degreeIn;   //进水阀开度
        private decimal degreeOut; //出水阀开度

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="area">底面积</param>  
        /// <param name="maxFlowIn">进水阀最大流量 立方每秒</param>
        /// <param name="maxFlowOut">出水阀最大流量立方每秒</param>
        /// <param name="degreeIn">进水阀开度</param>
        /// <param name="degreeOut">出水阀开度</param>
        public Box(decimal area, decimal maxFlowIn, decimal maxFlowOut, decimal degreeIn, decimal degreeOut)
        {
            this.area = area;
            this.maxFlowOut = maxFlowOut;
            this.maxFlowIn = maxFlowIn;
            this.degreeIn = degreeIn;
            this.degreeOut = degreeOut;
            this.levelList = new List<decimal>();
            this.levelList.Add(0);
        }
        public void Init()
        {
            this.levelList = new List<decimal>();
            this.levelList.Add(0);
        }
        private decimal GetActualLevel()
        {
            return this.levelList[this.levelList.Count - 1];
        }
        /// <summary>
        ///每调用一次表示经过了一秒
        /// </summary>
        public void ChangeLevel()
        {
            decimal myflow = this.degreeIn * this.maxFlowIn - this.degreeOut * this.maxFlowOut;//增加的流量
            decimal level = this.GetActualLevel() + myflow / this.area;//新的液位
            if (level < 0)
            {
                level = 0;
            }
            if (level > 1)
            {
                level = 1;
            }
            this.levelList.Add(level);
            while (this.levelList.Count > 10)
            {
                this.levelList.RemoveAt(0);
            }
        }

        public decimal GetLevel()
        {
            return this.levelList[0];
        }

        /// <summary>
        /// 改变进水阀开度
        /// </summary>
        public void ChangeDegreeIn(decimal degreeIn)
        {
            this.degreeIn = degreeIn;
        }
    }

    /// <summary>
    /// PID控制类
    /// </summary>
    public class PID
    {
        /// <summary>
        /// 积分累计值
        /// </summary>
        public decimal IntegralValue { get; set; }
        /// <summary>
        /// 设定值
        /// </summary>
        public decimal Target { get; set; }
        /// <summary>
        /// 比例
        /// </summary>
        public decimal P { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public decimal I { get; set; }
        /// <summary>
        /// 输出限幅
        /// </summary>
        private decimal MinOutPut { get; set; }
        /// <summary>
        /// 输出限幅
        /// </summary>
        private decimal MaxOutPut { get; set; }

        public void Init(decimal target, decimal p, decimal i, decimal minOutput, decimal maxOutput)
        {
            this.Target = target;
            this.P = p;
            this.I = i;
            IntegralValue = 0;
            if (minOutput > maxOutput)
            {
                throw new Exception("下限幅不能大于上限幅");
            }
            this.MinOutPut = minOutput;
            this.MaxOutPut = maxOutput;
        }

        /// <summary>
        /// 获得输出值
        /// </summary>
        /// <param name="feedBack">反馈值</param>
        /// <param name="number">0普通算法，1改进后的算法</param>
        /// <returns></returns>
        public decimal GetOutPutValue(decimal feedBack, int number)
        {
            decimal error = this.Target - feedBack;
            if (this.I > 0)
            {
                if (number == 0)
                {
                    this.IntegralValue += error / this.I;
                }
                else
                {
                    if ((Math.Abs(error) < 0.5m))
                    {
                        this.IntegralValue += error / this.I;
                    }
                }
            }
            decimal output = error * this.P + this.IntegralValue;
            if (output < this.MinOutPut)
            {
                return this.MinOutPut;
            }
            if (output > this.MaxOutPut)
            {
                return this.MaxOutPut;
            }
            return output;
        }
    }
}