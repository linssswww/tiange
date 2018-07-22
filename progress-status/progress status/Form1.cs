using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace progress_status
{
    public struct employControl
    {
        public Label lab;

        public ComboBox cb;
        public Label cb_lab;

        public TextBox tb;
        public Label tb_lab;
    }

    public struct employStatisticsLabels
    {
        public Label lb_employAndWork;

        public Label lb_img;
        public Label lb_ImgNum;

        public Label lb_side;
        public Label lb_sideNum;

        public Label lb_task;
        public Label lb_taskNum;

        public Label lb_taked;
        public Label lb_takedNum;

        public Label lb_total;
        public Label lb_tatalNum;
    }


    public struct Task
    {
        public Label lb_worker;
        public Label[] lb_satisContext;
        public Label[] lb_satisResult;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Employ> usrList = new List<Employ>();
            usrList = process.getListUser();
            

            Point start = new Point(10, 50);
            Point localfirst = new Point(start.X, start.Y);
            int num = 0;
            foreach (Employ employ in usrList)
            {
                employControl employItem;
                employItem.lab = new Label();
                employItem.cb = new ComboBox();
                employItem.tb = new TextBox();
                employItem.cb_lab = new Label();
                employItem.tb_lab = new Label();


                employItem.lab.Text = employ.employName + "的计划";
                employItem.lab.Location = start;
                this.Controls.Add(employItem.lab);

                employItem.cb_lab.Text = "工作任务:";
                employItem.cb_lab.Location = new Point(start.X, start.Y + 30);
                string[] array = { "拍图片", "打标签" };
                employItem.cb.DataSource = array;
                employItem.cb.Location = new Point(start.X + 100, start.Y + 30);
                employItem.cb.Size = new Size(100, 50);
                this.Controls.Add(employItem.cb_lab);
                this.Controls.Add(employItem.cb);


                employItem.tb_lab.Text = "任务量(组):";
                employItem.tb_lab.Location = new Point(start.X, start.Y + 60);
                employItem.tb.Location = new Point(start.X + 100, start.Y + 60);
                this.Controls.Add(employItem.tb_lab);
                this.Controls.Add(employItem.tb);

                employList.Add(employItem);
                
                num++;
                if(num == 4)
                {
                    start = new Point(localfirst.X, localfirst.Y + 90);
                    continue;
                }
                start = new Point(employItem.lab.Location.X + 250, employItem.lab.Location.Y);
            }

        }



        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Point start = new Point(10, 300);
            Point tmp = new Point(start.X, start.Y);
            string[] type1 = new string[] { "拍图数" , "拍图面数" , "任务量（/组）" , "已完成（/组）" , "完成进度" };
            string[] type2 = new string[] { "打标签图片数量", "打标签图片框数", "任务量（/组）", "已完成（/组）", "完成进度" };
             int num = 0;
            foreach (employControl workerStatic in employList)
            {
                /**********************************/
                Task task;
                task.lb_satisContext = new Label[5];
                task.lb_satisResult = new Label[5];

                for (int j = 0; j < 5; j++)
                {
                    task.lb_satisResult[j] = new Label();
                    task.lb_satisContext[j] = new Label();
                    task.lb_satisResult[j].Text = "0";
                    if(j == 2)
                        task.lb_satisResult[j].Text = workerStatic.tb.Text;
                    if (workerStatic.cb.Text == "拍图片")
                        task.lb_satisContext[j].Text = type1[j];
                    else
                        task.lb_satisContext[j].Text = type2[j];
                }

                task.lb_worker = new Label();
                task.lb_worker.Text = workerStatic.lab.Text;
                task.lb_worker.Location = new Point(start.X, start.Y);
                this.Controls.Add(task.lb_worker);

                
                /****************定位置***********************/
                
                
                for (int i = 0; i < 5; i++)
                {
                    task.lb_satisContext[i].Location = new Point(task.lb_worker.Location.X, task.lb_worker.Location.Y + 30 * i + 30);
                    task.lb_satisResult[i].Location = new Point(task.lb_worker.Location.X + 100, task.lb_worker.Location.Y + 30 * i + 30);
                    this.Controls.Add(task.lb_satisContext[i]);
                    this.Controls.Add(task.lb_satisResult[i]);
                }
                num++;
                if(num == 4)
                {
                    start = new Point(tmp.X, tmp.Y + 210);
                    continue;
                }
               
                start.X = start.X + 250;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        List<Task> tasklist = new List<Task>();
        public Process process = new Process();
        public List<employControl> employList = new List<employControl>();
    }
}
