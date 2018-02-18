

using System;
using System.Collections.Generic;
/**
* 命名空间: CcbitsSerialAssistants
*
* 功 能： 串口开发工具类
* 类 名： SerialPortUtil
*
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2018/2/18 11:27:59 侯建军 v1.0
*
* Copyright (c) 2016 Lir Corporation. All rights reserved.
*┌────────────────────────────────────────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：山西迅腾伟业科贸有限公司 　　　　　　　　　　           │
*└────────────────────────────────────────────────────────────────────┘
*/
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CcbitsSerialAssistants
{
    public class SerialPortUtil
    {
        /// <summary>
        /// 接收事件是否有效 false表示有效
        /// </summary>
        public bool ReceiveEventFlag = false;
        /// <summary>
        /// 结束符比特 回车16进制 0x0D  换行0x0A "#"0x23
        /// </summary>
        public byte EndByte = 0x0A;//string End = "#";
        /// <summary>
        /// 完整协议的记录处理事件
        /// </summary>
        public event DataReceivedEventHandler DataReceived;
        public event SerialErrorReceivedEventHandler Error;

        #region 变量属性
        private string _portName = "COM1";               //串口号，默认COM1
        private SerialPortBaudRates _baudRate = SerialPortBaudRates.BaudRate_57600;    //波特率
        private Parity _parity = Parity.None;           //校验位
        private StopBits _stopBits = StopBits.One;      //停止位
        private SerialPortDatabits _dataBits = SerialPortDatabits.EightBits;            //数据位

        private SerialPort comPort = new SerialPort();          //串口实例

        public string PortName
        {
            get
            {
                return _portName;
            }

            set
            {
                _portName = value;
            }
        }

        public SerialPortBaudRates BaudRate
        {
            get
            {
                return _baudRate;
            }

            set
            {
                _baudRate = value;
            }
        }

        public Parity Parity
        {
            get
            {
                return _parity;
            }

            set
            {
                _parity = value;
            }
        }

        public StopBits StopBits
        {
            get
            {
                return _stopBits;
            }

            set
            {
                _stopBits = value;
            }
        }

        public SerialPortDatabits DataBits
        {
            get
            {
                return _dataBits;
            }

            set
            {
                _dataBits = value;
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// 参数构造函数（使用枚举参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortUtil(string name, SerialPortBaudRates baud, Parity par, SerialPortDatabits dBits, StopBits sBits)
        {
            _portName = name;
            _baudRate = baud;
            _parity = par;
            _dataBits = dBits;
            _stopBits = sBits;

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        /// <summary>
        /// 参数构造函数（使用字符串参数构造）
        /// </summary>
        /// <param name="baud">波特率</param>
        /// <param name="par">奇偶校验位</param>
        /// <param name="sBits">停止位</param>
        /// <param name="dBits">数据位</param>
        /// <param name="name">串口号</param>
        public SerialPortUtil(string name, string baud, string par, string dBits, string sBits)
        {
            _portName = name;
            _baudRate = (SerialPortBaudRates)Enum.Parse(typeof(SerialPortBaudRates), baud);
            _parity = (Parity)Enum.Parse(typeof(Parity), par);
            _dataBits = (SerialPortDatabits)Enum.Parse(typeof(SerialPortDatabits), dBits);
            _stopBits = (StopBits)Enum.Parse(typeof(StopBits), sBits);

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SerialPortUtil()
        {
            _portName = "COM1";
            _baudRate = SerialPortBaudRates.BaudRate_9600;
            _parity = Parity.None;
            _dataBits = SerialPortDatabits.EightBits;
            _stopBits = StopBits.One;

            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
            comPort.ErrorReceived += new SerialErrorReceivedEventHandler(comPort_ErrorReceived);
        }
        #endregion

        #region 常用方法
        /// <summary>
        /// 端口是否已经打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return comPort.IsOpen;
            }
        }

        /// <summary>
        /// 打开端口
        /// </summary>
        /// <returns></returns>
        public void OpenPort()
        {
            if (comPort.IsOpen) comPort.Close();

            comPort.PortName = _portName;
            comPort.BaudRate = (int)_baudRate;
            comPort.Parity = _parity;
            comPort.DataBits = (int)_dataBits;
            comPort.StopBits = _stopBits;

            comPort.Open();
        }

        /// <summary>
        /// 关闭端口
        /// </summary>
        public void ClosePort()
        {
            if (comPort.IsOpen) comPort.Close();
        }

        /// <summary>
        /// 丢弃来自串行驱动程序的接收和发送缓冲区的数据
        /// </summary>
        public void DiscardBuffer()
        {
            comPort.DiscardInBuffer();
            comPort.DiscardOutBuffer();
        }

        /// <summary>
        /// 检查端口名称是否存在
        /// </summary>
        /// <param name="port_name"></param>
        /// <returns></returns>
        public static bool Exists(string port_name)
        {
            foreach (string port in SerialPort.GetPortNames()) if (port == port_name) return true;
            return false;
        }

        /// <summary>
        /// 格式化端口相关属性
        /// </summary>
        /// <param name="port"></param>
        /// <returns></returns>
        public static string Format(SerialPort port)
        {
            return String.Format("{0} ({1},{2},{3},{4},{5})",
                port.PortName, port.BaudRate, port.DataBits, port.StopBits, port.Parity, port.Handshake);
        }

        /// <summary>
        /// 错误处理函数
        /// </summary>
        void comPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (Error != null)
            {
                Error(sender, e);
            }
        }
        #endregion

        #region 数据接收
        /// <summary>
        /// 数据接收处理
        /// </summary>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //禁止接收事件时直接退出
            if (ReceiveEventFlag) return;

            #region 根据结束字节来判断是否全部获取完成
            List<byte> _byteData = new List<byte>();

            while (comPort.BytesToRead > 0)
            {
                byte[] readBuffer = new byte[comPort.ReadBufferSize + 1];
                //读取串口缓冲区数据大小
                int count = comPort.Read(readBuffer, 0, comPort.ReadBufferSize);
                for (int i = 0; i < count; i++)
                {
                    //将缓冲数据添加到字节数据数组
                    _byteData.Add(readBuffer[i]);
                }
            }
            #endregion

            //字符转换
            string readString = System.Text.Encoding.Default.GetString(_byteData.ToArray(), 0, _byteData.Count);
            string hexString = "";
            foreach (var item in _byteData)
            {
                //将第一个字节转为16进制数
                if (item != 10 && item != 13) {
                    hexString+= Convert.ToString(item, 16)+" ";
                }
            }
            //触发整条记录的处理
            if (DataReceived != null)
            {
                DataReceived(new DataReceivedEventArgs(readString,hexString));
            }
        }
        #endregion

        #region 数据写入操作

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg"></param>
        public void WriteData(string msg)
        {
            if (!(comPort.IsOpen)) comPort.Open();
            //串口数据以字符串方式发送
            comPort.Write(msg);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg">写入端口的字节数组</param>
        public void WriteData(byte[] msg)
        {
            if (!(comPort.IsOpen)) comPort.Open();
            //串口数据以字节方式发送
            comPort.Write(msg, 0, msg.Length);
        }

        /// <summary>
        /// 写入数据
        /// </summary>
        /// <param name="msg">包含要写入端口的字节数组</param>
        /// <param name="offset">参数从0字节开始的字节偏移量</param>
        /// <param name="count">要写入的字节数</param>
        public void WriteData(byte[] msg, int offset, int count)
        {
            if (!(comPort.IsOpen)) comPort.Open();
            //使用偏移方式发送字节数组
            comPort.Write(msg, offset, count);
        }

        /// <summary>
        /// 发送串口命令
        /// </summary>
        /// <param name="SendData">发送数据</param>
        /// <param name="ReceiveData">接收数据</param>
        /// <param name="Overtime">重复次数</param>
        /// <returns></returns>
        public int SendCommand(byte[] SendData, ref byte[] ReceiveData, int Overtime)
        {
            if (!(comPort.IsOpen)) comPort.Open();

            ReceiveEventFlag = true;        //关闭接收事件
            comPort.DiscardInBuffer();      //清空接收缓冲区                 
            comPort.Write(SendData, 0, SendData.Length);

            int num = 0, ret = 0;
            while (num++ < Overtime)
            {
                if (comPort.BytesToRead >= ReceiveData.Length) break;
                System.Threading.Thread.Sleep(1);
            }

            if (comPort.BytesToRead >= ReceiveData.Length)
            {
                ret = comPort.Read(ReceiveData, 0, ReceiveData.Length);
            }

            ReceiveEventFlag = false;       //打开事件
            return ret;
        }

        #endregion

        #region 常用的列表数据获取和绑定操作

        /// <summary>
        /// 封装获取串口号列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 设置串口号
        /// </summary>
        /// <param name="obj"></param>
        public static void SetPortNameValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in SerialPort.GetPortNames())
            {
                obj.Items.Add(str);
            }
        }

        /// <summary>
        /// 设置波特率
        /// </summary>
        public static void SetBauRateValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortBaudRates rate in Enum.GetValues(typeof(SerialPortBaudRates)))
            {
                obj.Items.Add(((int)rate).ToString());
            }
        }

        /// <summary>
        /// 设置数据位
        /// </summary>
        public static void SetDataBitsValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (SerialPortDatabits databit in Enum.GetValues(typeof(SerialPortDatabits)))
            {
                obj.Items.Add(((int)databit).ToString());
            }
        }

        /// <summary>
        /// 设置校验位列表
        /// </summary>
        public static void SetParityValues(ComboBox obj)
        {
            obj.Items.Clear();
            //获取名称
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                obj.Items.Add(str);
            }
            //获取值
            //foreach (Parity party in Enum.GetValues(typeof(Parity)))
            //{
            //    obj.Items.Add(((int)party).ToString());
            //}
        }

        /// <summary>
        /// 设置停止位
        /// </summary>
        public static void SetStopBitValues(ComboBox obj)
        {
            obj.Items.Clear();
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                obj.Items.Add(str);
            }
            //foreach (StopBits stopbit in Enum.GetValues(typeof(StopBits)))
            //{
            //    obj.Items.Add(((int)stopbit).ToString());
            //}
        }

        #endregion

        #region 格式转换
        /// <summary>
        /// 转换十六进制字符串到字节数组
        /// </summary>
        /// <param name="msg">待转换字符串</param>
        /// <returns>字节数组</returns>
        public static byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");//移除空格

            //创建一个字节数组长度为
            //(十六进制字符串为2个字节)，所有除以2
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
            {
                //转换每个字符为2个字节，并添加到数据
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            }

            return comBuffer;
        }

        /// <summary>
        /// 转换字节数组到十六进制字符串
        /// </summary>
        /// <param name="comByte">待转换字节数组</param>
        /// <returns>十六进制字符串</returns>
        public static string ByteToHex(byte[] comByte)
        {
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            foreach (byte data in comByte)
            {
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            }

            return builder.ToString().ToUpper();
        }

        /// <summary>
        /// 判断是否十六进制格式字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsHexadecimal(string str)
        {
            const string PATTERN = @"[A-Fa-f0-9]+$";
            bool bo = System.Text.RegularExpressions.Regex.IsMatch(str, PATTERN);

            if (bo == true)
            {
                // 长度判断 长度+1 与3的余数为0表示长度符合要求
                if ((str.Length + 1) % 3 != 0)
                {
                    bo = false;
                }
                else
                {
                    // 空格判断，空格数为长度+1 与3的余数
                    if (str.Length > 2)
                    {

                        string[] arr = str.Split(new char[] { ' ' });

                        //分离后，得到空格数
                        int space_count = arr.Length - 1;

                        //实际空格数
                        int n = ((str.Length + 1) / 3) - 1;

                        // 获得字符串中所有的空格数
                        int cout = Regex.Matches(str, @" ").Count;

                        if (space_count != n || cout != space_count)
                        {
                            bo = false;
                        }
                        else
                        {
                            for (int i = 0; i < str.Length; i++)
                            {
                                if ((i + 1) % 3 == 0)
                                {
                                    // 判断 2 5 8 11 .. 位置是否为空格
                                    if (str[i] != ' ')
                                    {
                                        bo = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (str.Length < 2)
                    {
                        bo = false;
                    }
                }
            }

            return bo;
        }
        #endregion
    }

    /// <summary>
    /// 数据接受事件类，继承EventArgs
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        public string DataReceived;
        public string HexDataReceived;
        public DataReceivedEventArgs(string m_DataReceived, string hexDataReceived)
        {
            this.DataReceived = m_DataReceived;
            this.HexDataReceived = hexDataReceived;
        }
    }
    //数据接受事件委托
    public delegate void DataReceivedEventHandler(DataReceivedEventArgs e);
    /// <summary>
    /// 串口波特率列表。
    /// 75,110,150,300,600,1200,2400,4800,9600,14400,19200,28800,38400,56000,57600,
    /// 115200,128000,230400,256000
    /// </summary>
    public enum SerialPortBaudRates : int
    {
        BaudRate_75 = 75,
        BaudRate_110 = 110,
        BaudRate_150 = 150,
        BaudRate_300 = 300,
        BaudRate_600 = 600,
        BaudRate_1200 = 1200,
        BaudRate_2400 = 2400,
        BaudRate_4800 = 4800,
        BaudRate_9600 = 9600,
        BaudRate_14400 = 14400,
        BaudRate_19200 = 19200,
        BaudRate_28800 = 28800,
        BaudRate_38400 = 38400,
        BaudRate_56000 = 56000,
        BaudRate_57600 = 57600,
        BaudRate_115200 = 115200,
        BaudRate_128000 = 128000,
        BaudRate_230400 = 230400,
        BaudRate_256000 = 256000
    }
    /// <summary>
    /// 串口数据位列表（5,6,7,8）
    /// </summary>
    public enum SerialPortDatabits : int
    {
        FiveBits = 5,
        SixBits = 6,
        SeventBits = 7,
        EightBits = 8
    }
}
