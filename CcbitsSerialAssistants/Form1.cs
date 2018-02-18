using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;

namespace CcbitsSerialAssistants
{
    public partial class Form1 : Form
    {
        //声明SerialPortUtil工具类
        SerialPortUtil spu;
        //计算时间差
        DateTime beforDT = DateTime.Now;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Ccbits串口助手--QQ:474177818(侯建军)";
            init();
        }
        /// <summary>
        /// 初始化串口数据
        /// </summary>
        public void init()
        {
            btnSend.Enabled = false;
            //串口号初始化
            SerialPortUtil.SetPortNameValues(combComList);
            if (combComList.Items.Count > 0)
            {
                combComList.SelectedIndex = 0;
            }
            //波特率初始化
            SerialPortUtil.SetBauRateValues(combBaudList);
            combBaudList.SelectedIndex = 8;
            //数据位
            SerialPortUtil.SetDataBitsValues(combDataBit);
            combDataBit.SelectedIndex = 3;
            //校验位
            SerialPortUtil.SetParityValues(combParityList);
            combParityList.SelectedIndex = 0;
            //停止位
            SerialPortUtil.SetStopBitValues(combStopbitList);
            combStopbitList.SelectedIndex = 1;

        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            if (spu != null)
            {
                if (spu.IsOpen)
                {
                    spu.ClosePort();
                    btnOpenCom.Text = "连接";
                }
                else
                {
                    spu.OpenPort();
                    btnOpenCom.Text = "断开";
                    btnSend.Enabled = true;
                }
            }
            else
            {
                spu = new SerialPortUtil(combComList.Text, combBaudList.Text, combParityList.Text, combDataBit.Text, combStopbitList.Text);
                //数据接收
                spu.DataReceived += new DataReceivedEventHandler(serial_DataReceived);
                spu.OpenPort();
                btnOpenCom.Text = "断开";
                btnSend.Enabled = true;
            }

            showSate();
        }

        private void showSate()
        {
            if (spu.IsOpen)
            {
                tsslLabStatus.Text = "连接";
                txtLogs.AppendText("串行端口" + spu.PortName + "已经开启！波特率,校验位,数据位,停止位=" + combBaudList.Text + "," + combParityList.Text + "," + combDataBit.Text + "," + combStopbitList.Text + Environment.NewLine);
            }
            else
            {
                tsslLabStatus.Text = "断开";
                txtLogs.AppendText("串行端口" + spu.PortName + "已经关闭！" + Environment.NewLine);
            }

        }
        /// <summary>
        /// 清除接受数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReveCls_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
        }
        /// <summary>
        /// 清空发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendCls_Click(object sender, EventArgs e)
        {
            txtSend.Text = "";
        }
        /// <summary>
        /// 数据发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            txtLogs.AppendText("手动发送！" + Environment.NewLine);
            //按16进制发送
            if (radHEXSend.Checked)
            {
                string hexStr = txtSend.Text.Replace("0x", "");
                if (SerialPortUtil.IsHexadecimal(hexStr))
                {
                    txtLogs.AppendText("……>发送数据：" + txtSend.Text + Environment.NewLine);
                    spu.WriteData(SerialPortUtil.HexToByte(hexStr));
                }
                else
                {
                    MessageBox.Show("16进制数格式不正确，请使用0xFF与FF格式");
                }
            }
            else
            {
                txtLogs.AppendText("……>发送数据：" + txtSend.Text + Environment.NewLine);
                spu.WriteData(txtSend.Text);
                
            }
            beforDT = DateTime.Now;
        }
        /// <summary>
        /// 串口接受事件
        /// </summary>
        /// <param name="e"></param>
        void serial_DataReceived(DataReceivedEventArgs e)
        {
            //解决线程冲突，调用一个委托，将数据加到文本框
            this.txtReceived.Invoke(new MethodInvoker(delegate
            {
                //获得Encoder实例;
                Encoder encoder = Encoding.UTF8.GetEncoder();
                if (radHexRecerived.Checked)
                {
                    //接受数据到文件框 添加
                    this.txtReceived.AppendText(e.HexDataReceived.Trim() + "  ");
                    txtLogs.AppendText("<……接受数据：" + e.HexDataReceived.Trim() + Environment.NewLine);
                }
                else
                {
                    //接受数据到文件框，NewLine为换行
                    this.txtReceived.AppendText(e.DataReceived + "  ");
                    txtLogs.AppendText("<……接受数据：" + e.DataReceived + Environment.NewLine);
                }
                DateTime afterDT = System.DateTime.Now;
                TimeSpan ts = afterDT.Subtract(beforDT);
                txtLogs.AppendText("总共花费" + ts.TotalMilliseconds + "ms." + Environment.NewLine);
            }));
            
        }
    }

}
