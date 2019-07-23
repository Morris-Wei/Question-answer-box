using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechRecognitionMod
{
    public partial class Form1 : Form
    {
/*--------------------------------------------------------------------------------*/

       public string[] question = {" 1.我觉得闷闷不乐, 情绪低沉",
                                "2.  我觉得一天之中早晨最好",
                                "3.	我一阵阵哭出来或想哭",
                                "4.  我晚上睡眠不好",
                                "5.  我吃得跟平常一样多",
                                "6.  我与异性密切接触时和以往一样感到愉快",
                                "7.  我发觉我的体重在下降",
                                "8.  我有便秘的苦恼",
                                "9.  我心跳比平时快",
                                "10.  我无缘无故地感到疲乏",
                                "11.  我的头脑跟平常一样清楚",
                                "12.  我觉得经常做的事情并没困难",
                                "13.  我觉得不安而平静不下来",
                                "14.  我对将来抱有希望",
                                "15.我比平常容易生气激动",
                                "16. 我觉得作出决定是容易的",
                                "17. 我觉得自己是个有用的人，有人需要我",
                                "18. 我的生活过得很有意思",
                                "19. 我认为如果我死了别人会生活得更好些",
                                "20. 平常感兴趣的事我仍然照样感兴趣"};
        public string answer;    
/*--------------------------------------------------------------------------------*/
        public static int num = 20;
        public int count = 0;
/*--------------------------------------------------------------------------------*/

        private SRecognition sr;
        public Form1()
        {
            InitializeComponent();
            string[] fg = { "是的", "我感到", "不安", "困惑" };
            sr = new SRecognition(fg);
            textBoxShow.Text = "未进行语音识别";
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            buttonPlay.Enabled = false;
            if (count >= 1 && count < num)
            {
                sr.over();
                textBoxShow.Text = "语音识别停止";
                answer += (Convert.ToString(num + 1) + textBox2);
                textBox2.Text = " ";
            }       
            if (count >= num)
            {
                 MessageBox.Show("已经问完所有的问题了，可以点击Restart按钮重新开始");
                
            }                              
            else         
            {
                textBox1.Text = question[count];
                SpVoice voice = new SpVoice();
                voice.Rate = 10; //语速,[-10,10]
                voice.Volume = 100; //音量,[0,100]
                voice.Voice = voice.GetVoices().Item(0); //语音库
                voice.Speak("请开始回答问题" + textBox1.Text);
                //voice.Speak("请选择：1,没有或很少时间，2,小部分时间，3，相当多时间，4，绝大部分时间");
                count++;             
                buttonPlay.Enabled = true;
                textBoxShow.Text = "语音识别开始";
                sr.BeginRec(textBox2);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                   
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            count = 0;//重新开始审问
            sr.over();
            buttonPlay.Enabled = true;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (count > 0)
                count--;//返回上一次提问
            else
                MessageBox.Show("已经是第一个了！");                   
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxShow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
