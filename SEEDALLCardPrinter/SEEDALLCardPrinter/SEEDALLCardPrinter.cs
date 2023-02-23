using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SC2;//20230216
using System.Runtime.InteropServices;
using System.Drawing.Printing;


namespace SEEDALLCardPrinter
{


    public partial class SEEDALLCardPrinter : Form
    {

        CSC2 m_Smart;
        private Timer m_timerStatus = new System.Windows.Forms.Timer();
        private Timer m_timerFStatus = new System.Windows.Forms.Timer();

     

        public SEEDALLCardPrinter()
        {
            InitializeComponent();

            m_Smart = new CSC2();

            chkIterStatus.Checked = true;
            m_timerStatus.Interval = 500;   // 0.5 sec
            m_timerStatus.Tick += new EventHandler(timerStatus_Tick);


            chkIterFStatus.Checked = true;
            m_timerFStatus.Interval = 500;   // 0.5 sec
            m_timerFStatus.Tick += new EventHandler(timerFStatus_Tick);
        }

     

        private void btn_Open_Click(object sender, EventArgs e)
        {
            //先判断是否连接，是先断开
            if (m_Smart.IsOpened())
                m_Smart.DCLCloseDevice();

            uint nres;

            //获取打印机列表
            CSC2.PRINTERLIST list = new CSC2.PRINTERLIST();
            m_Smart.GetDeviceList(ref list);

            //判断获取打印机列表是否为空
            if (list.n == 0)
                return;


            int pid = 0;//20221116
            bool flipper = false;//20221116
            pid = list.item[0].pid;//20221116

            CSC2.SMART_DEVGROUP group = m_Smart.GetDeviceGroup(pid);//20221116

            //打开打印机
            nres = m_Smart.DCLOpenDevice(list.item[0].desc, Win32.DMORIENT_LANDSCAPE);//打开第一个list.item[0].desc打印机，可以多台打印机 DMORIENT_LANDSCAPE为横版

            if (nres != 0)
            {
                // MessageBox.Show("打开打印机失败,错误代码：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            // 检测双面模块是否安装20221116
            if (nres == SmartComm2.SM_SUCCESS)//20221116
                nres = m_Smart.IsFlippable(group, ref flipper);//20221116

            //开启SBS模式
            nres = m_Smart.SBSStart();
            if (nres != 0)
            {
                // MessageBox.Show("开启SBS模式失败，错误代码：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }



            MessageBox.Show("打开打印机成功");

            //触发检测打印机事件
            m_timerStatus.Stop();
            m_timerStatus.Start();

            //触发检测双面模块事件
            m_timerFStatus.Stop();
            m_timerFStatus.Start();
        }

        private void btn_CheckStatus_Click(object sender, EventArgs e)
        {
            uint nres;

            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            //打印机状态
            UInt64 status = 0L;
            nres = m_Smart.GetStatus(ref status);

            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                // MessageBox.Show("获取打印机状态失败,错误代码" + nres.ToString("x8"));
                ShowResult(nres);
            }
            else
            {
                MessageBox.Show("获取打印机状态成功：0x" + status.ToString("x16"));
            }




        }

        private void btn_GetFlipStatus_Click(object sender, EventArgs e)
        {
            //检测是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            bool flipper = false;

            //第一种方法 
            //nres = m_Smart.GetStatus(ref status);

            ////true 为安装双面模块  false为未安装
            //flipper = ((status & SmartComm2.S51PS_S_CONNFLIPPER) != 0);

            //第二种方法检测翻转模块是否安装 check, flipper is installed...

            nres = m_Smart.IsFlippable(CSC2.SMART_DEVGROUP.GROUP_SMART51, ref flipper);

            if (nres != SmartComm2.SM_SUCCESS && flipper)
                return;
            //    ;
            //获取翻转模块状态
            UInt64 status = 0L;//翻转模块打印机状态
            nres = m_Smart.GetFlipStatus(ref status);
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                ShowResult(nres);
                return;//获取翻转模块状态失败
            }

            //返回翻转模块状态值
            MessageBox.Show("获取翻转模块状态成功：0x" + status.ToString("x16"));



        }

        private void btn_GetRibbonRemain_Click(object sender, EventArgs e)
        {
            uint nres;

            //检测是否连接
            if (!m_Smart.IsOpened())
                return;

            //获取色带信息
            int type = 0;//色带类型
            int max = 0;//色带最大打印量
            int remain = 0;//色带剩余量
            int grade = 0;//

            nres = m_Smart.GetRibbonInfo(ref type, ref max, ref remain, ref grade);

            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                // MessageBox.Show("获取色带剩余量失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("获取色带剩余量成功：" + remain.ToString());

            }
        }

        private void btn_CardIn_Click(object sender, EventArgs e)
        {
            uint nres;

            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            nres = m_Smart.CardIn();//进卡
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("进卡失败失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("进卡成功");
            }
        }

        private void btn_CardInBack_Click(object sender, EventArgs e)
        {
            uint nres;

            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            nres = m_Smart.CardInBack();//后进卡

            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("后进卡失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("后进卡成功");
            }
        }

        private void btn_MoveIC_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.Move(SmartComm2.CARDPOS_IC2);
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("进卡IC失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("进卡到接触IC位置成功");
            }

        }

        private void btn_MoveRF_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.Move(SmartComm2.CARDPOS_RF2);
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("进卡RF失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("非接触IC成功");
            }
        }

        private void btn_MovePrinter_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.Move(SmartComm2.CARDPOS_PRINT);
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("移动卡到打印位置失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("移动卡到打印位置成功");
            }
        }

        private void btn_MoveFliper_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;

            UInt64 status = 0L;//打印机状态

            bool flipper = false;//是否双面模块

            nres = m_Smart.GetStatus(ref status);

            //true 为安装双面模块  false为未安装
            flipper = ((status & SmartComm2.S51PS_S_CONNFLIPPER) != 0);

            if (!flipper)
            {
                MessageBox.Show("未安装双面模块");
                return;
            }

            nres = m_Smart.Move(SmartComm2.CARDPOS_TOROT);

            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("移动卡到双面模块位置失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("移动卡到双面模块位置成功");
            }
        }

        private void btn_ICDown_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.ICHContact();
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("接触式读头落下失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("接触式读头落下失败成功");
            }
        }

        private void btn_ICUp_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.ICHDiscontact();
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("接触式读头抬起失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("接触式读头抬起失败成功");
            }
        }

        private void btn_CardOut_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.CardOut();
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("移动到废卡盒失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("移动到废卡盒出卡成功");
            }
        }

        private void btn_CardOutBack_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.CardOutBack();
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("后出卡失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("后出卡成功");
            }

        }

        private void btn_KeepCard_Click(object sender, EventArgs e)
        {
            //没有双面模块，移动卡到单面打印机的持卡位置
            //有双面模块，移动到双面模块持卡位置
            uint nres;
            bool flipper = false;//是否双面模块
            UInt64 status = 0L;//打印机状态
            //获取打印机状态
            nres = m_Smart.GetStatus(ref status);
            //检测是否连接双面
            flipper = ((status & SmartComm2.S51PS_S_CONNFLIPPER) != 0);//true 为安装双面模块  false为未安装
            if (!flipper)
            {
                //不带双面模块就移动到单面打印机持卡位置
                nres = m_Smart.MoveSensor(2, 1, 550, 100);//550是持卡长度，可以自己修改最近长度
                if (nres != SC2.SmartComm2.SM_SUCCESS)
                {
                    MessageBox.Show("移动到持卡位置失败");
                    ShowResult(nres);
                    return;
                }
                else
                    MessageBox.Show("移动到持卡位置成功");
            }
            else
            {
                //带双面模块，先移动卡到双面模块
                nres = m_Smart.Move(SmartComm2.CARDPOS_TOROT);
                //再移动卡到双面模块的持卡位置
                if (nres == SC2.SmartComm2.SM_SUCCESS)
                    nres = m_Smart.MoveSensor(4, 1, 200, 100);
                if (nres != SC2.SmartComm2.SM_SUCCESS)
                {
                    MessageBox.Show("移动到持卡位置失败");
                    ShowResult(nres);
                    return;
                }
                else
                    MessageBox.Show("移动到持卡位置成功");

            }
        }

        private void btn_GetSN_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            CSC2.SYSINFO sysinfo = new CSC2.SYSINFO();
            nres = m_Smart.GetSystemInfo(ref sysinfo);
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("获取打印机序列号失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            MessageBox.Show(sysinfo.printer_serial);
            //sysinfo.printer_ver = si.printer_ver;打印机版本
            //sysinfo.printer_serial = si.printer_serial;打印机序列号
            //sysinfo.printer_hserial = si.printer_hserial;打印头序列号
            //sysinfo.printer_cleaningWarning = si.printer_cleaningWarning; 清洁警告
            //sysinfo.printer_cleaning = si.printer_cleaning; 清洁次数
            //sysinfo.printer_totalDensity = si.printer_totalDensity;打印头能量
            //sysinfo.printer_colorDensity = si.printer_colorDensity;打印头彩色能量
            //sysinfo.printer_blackDensity = si.printer_blackDensity;打印头单色能量
            //sysinfo.printer_overlayDensity = si.printer_overlayDensity;打印头覆膜能量
            //sysinfo.laminator_installed = (si.laminator_installed != 0);覆膜机是否安装
            //sysinfo.laminator_ver = si.laminator_ver;覆膜机版本
            //sysinfo.laminator_serial = si.laminator_serial;覆膜机序列号
        }

        private void ShowResult(uint nres)//错误提示信息
        {
            string str = "";
            switch (nres)
            {
                case SmartComm2.SM_SUCCESS: return; // str = "OK"; break;
                case SmartComm2.SM_F_FOUNDNODEV: str = "[SM_F_FOUNDNODEV] there is no device to use."; break;
                case SmartComm2.SM_F_INVALIDDEVIDX: str = "[SM_F_INVALIDDEVIDX] index of device is out of bound."; break;
                case SmartComm2.SM_F_INVALIDBUFPOINTER: str = "[SM_F_INVALIDBUFPOINTER] invalid buffer pointer."; break;
                case SmartComm2.SM_F_NOTEXISTDEV: str = "[SM_F_NOTEXISTDEV] not exist device."; break;
                case SmartComm2.SM_F_INVALIDPARAM: str = "[SM_F_INVALIDPARAM] invalid parameter value."; break;
                case SmartComm2.SM_F_DEVOPENFAILED: str = "[SM_F_DEVOPENFAILED] device open failed."; break;
                case SmartComm2.SM_F_DEVIO: str = "[SM_F_DEVIO] device io operation is failed."; break;
                case SmartComm2.SM_F_FOUNDNODRV: str = "[SM_F_FOUNDNODRV] not found driver or cannot acquire DEVMODE from driver."; break;
                case SmartComm2.SM_F_INVALIDHANDLE: str = "[SM_F_INVALIDHANDLE] invalid handle value."; break;
                case SmartComm2.SM_F_CARDISINSIDE: str = "[SM_F_CARDISINSIDE] card is already inside of device."; break;
                case SmartComm2.SM_F_NOCARDISINSIDE: str = "[SM_F_NOCARDISINSIDE] no card is inside of device."; break;
                case SmartComm2.SM_F_HOPPEREMPTY: str = "[SM_F_HOPPEREMPTY] no cards are in hopper."; break;
                case SmartComm2.SM_F_NOCARDONBOTH: str = "[SM_F_NOCARDONBOTH] no card both hopper and inside of printer."; break;
                case SmartComm2.SM_F_WAITTIMEOUT: str = "[SM_F_WAITTIMEOUT] timeout occured while wait."; break;
                case SmartComm2.SM_F_CASEOPEN: str = "[SM_F_CASEOPEN] case SmartComm2.is opened."; break;
                case SmartComm2.SM_F_ERRORSTATUS: str = "[SM_F_ERRORSTATUS] current status has error flag."; break;
                case SmartComm2.SM_F_CARDIN: str = "[SM_F_CARDIN] card-in action is failed."; break;
                case SmartComm2.SM_F_CARDOUT: str = "[SM_F_CARDOUT] card-out action is failed."; break;
                case SmartComm2.SM_F_CARDOUTBACK: str = "[SM_F_CARDOUTBACK] card-back-out action is failed."; break;
                case SmartComm2.SM_F_MOVE2MAG: str = "[SM_F_MOVE2MAG] card move (to magnetic) is failed."; break;
                case SmartComm2.SM_F_MOVE2IC: str = "[SM_F_MOVE2IC] card move (to IC) is failed."; break;
                case SmartComm2.SM_F_MOVE2RF: str = "[SM_F_MOVE2RF] card move (to RF) is failed."; break;
                case SmartComm2.SM_F_MOVE2ROT: str = "[SM_F_MOVE2ROT] card move (to Rotator) is failed."; break;
                case SmartComm2.SM_F_MOVE2DEV: str = "[SM_F_MOVE2DEV] card move (from Rotator) is failed."; break;
                case SmartComm2.SM_F_MAGRW: str = "[SM_F_MAGRW] magnetic read/write is failed,"; break;
                case SmartComm2.SM_F_NOPRINTDATA: str = "[SM_F_NOPRINTDATA] printer failed to receive print data."; break;
                case SmartComm2.SM_F_PRINT: str = "[SM_F_PRINT] print failed."; break;
                case SmartComm2.SM_F_SEEKRIBBON: str = "[SM_F_SEEKRIBBON] seek-ribbon is failed."; break;
                case SmartComm2.SM_F_MOVERIBBON: str = "[SM_F_MOVERIBBON] move-ribbon is failed."; break;
                case SmartComm2.SM_F_EMPTYRIBBON: str = "[SM_F_EMPTYRIBBON] ribbon is empty."; break;
                case SmartComm2.SM_F_ICHUP: str = "[SM_F_ICHUP] ic-head up failed."; break;
                case SmartComm2.SM_F_ICHDN: str = "[SM_F_ICHDN] ic-head down failed."; break;
                case SmartComm2.SM_F_ROTTOP: str = "[SM_F_ROTTOP] rotate to top is failed."; break;
                case SmartComm2.SM_F_ROTBOTTOM: str = "[SM_F_ROTBOTTOM] rotate to bottom is failed."; break;
                case SmartComm2.SM_F_REQNOMAGTRACK: str = "[SM_F_REQNOMAGTRACK] requested no magnetic track."; break;
                case SmartComm2.SM_F_REQMULTIMAGTRACK: str = "[SM_F_REQMULTIMAGTRACK] requested two or more magnetic tracks in XXXGetBuffer function."; break;
                case SmartComm2.SM_F_FILENOTFOUND: str = "[SM_F_FILENOTFOUND] file not found."; break;
                case SmartComm2.SM_F_FIELDNOTFOUND: str = "[SM_F_FIELDNOTFOUND] field is not exist."; break;
                case SmartComm2.SM_F_IMAGELOAD: str = "[SM_F_IMAGELOAD] failed to load image."; break;
                case SmartComm2.SM_F_CREATEDC: str = "[SM_F_CREATEDC] dc creation is failed."; break;
                case SmartComm2.SM_F_VERIFYDRV: str = "[SM_F_VERIFYDRV] driver verification is failed. may the driver is not ours."; break;
                case SmartComm2.SM_F_SPOOLING: str = "[SM_F_SPOOLING] failed to make spool data. (includes StartDoc, StartPage, EndPage and EndDoc)"; break;
                case SmartComm2.SM_F_DEVNOTOPENED: str = "[SM_F_DEVNOTOPENED] request access to ic/rf module without opening the printer device."; break;
                case SmartComm2.SM_F_USEDBYOTHER: str = "[SM_F_USEDBYOTHER] usb is temporarily blocked by other. "; break;
                case SmartComm2.SM_F_SOCKETCREATE: str = "[SM_F_SOCKETCREATE] socket creation failed."; break;
                case SmartComm2.SM_F_SOCKETCONNECT: str = "[SM_F_SOCKETCONNECT] socket connection failed."; break;
                case SmartComm2.SM_F_SSLINIT: str = "[SM_F_SSLINIT] SSL initialization failed."; break;
                case SmartComm2.SM_F_SSLCREATE: str = "[SM_F_SSLCREATE] SSL creation failed."; break;
                case SmartComm2.SM_F_SSLCONNECT: str = "[SM_F_SSLCONNECT] SSL connection is failed."; break;
                case SmartComm2.SM_F_RESERVED: str = "[SM_F_RESERVED] host is already reserved status."; break;
                case SmartComm2.SM_F_INVALIDSOCKET: str = "[SM_F_INVALIDSOCKET] socket fd is invalid."; break;
                case SmartComm2.SM_F_LESSSENDED: str = "[SM_F_LESSSENDED] packet is sended less than requested."; break;
                case SmartComm2.SM_F_LESSRECVED: str = "[SM_F_LESSRECVED] packet is received less than requested."; break;
                case SmartComm2.SM_F_SOCKETERROR: str = "[SM_F_SOCKETERROR] socket error occured."; break;
                case SmartComm2.SM_F_INVALIDPACKET: str = "[SM_F_INVALIDPACKET] packet is not valid."; break;
                case SmartComm2.SM_F_PACKETSEQDIFFER: str = "[SM_F_PACKETSEQDIFFER] packet sequence/id is not equaled when receive."; break;
                case SmartComm2.SM_F_PACKETFLAGNOREPLY: str = "[SM_F_PACKETFLAGNOREPLY] reply flag is not setted on received packet."; break;
                case SmartComm2.SM_F_PACKETFLAGHEADER: str = "[SM_F_PACKETFLAGHEADER] sent packet header is incorrect."; break;
                case SmartComm2.SM_F_PACKETFLAGARGUMENT: str = "[SM_F_PACKETFLAGARGUMENT] argument is not valid on sent packet."; break;
                case SmartComm2.SM_F_PACKETFLAGEXE: str = "[SM_F_PACKETFLAGEXE] execution error flag is setted."; break;
                case SmartComm2.SM_F_PACKETFLAGBADCMD: str = "[SM_F_PACKETFLAGBADCMD] bad command flag is setted."; break;
                case SmartComm2.SM_F_PACKETFLAGINIT: str = "[SM_F_PACKETFLAGINIT] ..."; break;
                case SmartComm2.SM_F_PACKETFLAGHANDLE: str = "[SM_F_PACKETFLAGHANDLE] invalid handle is given."; break;
                case SmartComm2.SM_F_FILEOPEN: str = "[SM_F_FILEOPEN] file open failed..."; break;
                case SmartComm2.SM_F_FILEREAD: str = "[SM_F_FILEREAD] read from fale is failed."; break;
                case SmartComm2.SM_F_NOTSUPPORTYET: str = "[SM_F_NOTSUPPORTYET] not support yet..."; break;
                case SmartComm2.SM_F_INSUFFICIENTBUF: str = "[SM_F_INSUFFICIENTBUF] insufficient buffer."; break;
                case SmartComm2.SM_F_ICESTABLISH: str = "[SM_F_ICESTABLISH] SCardEstablish failed."; break;
                case SmartComm2.SM_F_ICLISTREADER: str = "[SM_F_ICLISTREADER] SCardListReaders failed."; break;
                case SmartComm2.SM_F_ICCONNECT: str = "[SM_F_ICCONNECT] SCardConnect failed."; break;
                case SmartComm2.SM_F_ICGETSTATUS: str = "[SM_F_ICGETSTATUS] SCardStatus failed."; break;
                case SmartComm2.SM_F_ICDISCONNECT: str = "[SM_F_ICDISCONNECT] SCardDisconenct failed."; break;
                case SmartComm2.SM_F_ICRELEASE: str = "[SM_F_ICRELEASE] SCardReleaseContext failed."; break;
                case SmartComm2.SM_F_INVALIDNAME: str = "[SM_F_INVALIDNAME] invalid or not supporting barcode name is given."; break;
                case SmartComm2.SM_F_OBJECTNOTFOUND: str = "[SM_F_OBJECTNOTFOUND] object is not exist."; break;
                case SmartComm2.SM_F_OVERHEATED: str = "[SM_F_OVERHEATED] thermal-head is overheated."; break;
                case SmartComm2.SM_F_NOPRINTHREAD: str = "[SM_F_NOPRINTHREAD] no thermal-head"; break;
                case SmartComm2.SM_F_CHANGEPASSWORD: str = "[SM_F_CHANGEPASSWORD] changing root/user password is failed."; break;
                case SmartComm2.SM_F_UNLOCK: str = "[SM_F_UNLOCK] unlock is failed."; break;
                case SmartComm2.SM_F_LOCK: str = "[SM_F_LOCK] lock is failed."; break;
                case SmartComm2.SM_F_FAILEDTOSET: str = "[SM_F_FAILEDTOSET] failed to printer set."; break;
                case SmartComm2.SM_F_FILESIZEZERO: str = "[SM_F_FILESIZEZERO] file size is 0."; break;
                case SmartComm2.SM_F_DEPRECATED: str = "[SM_F_DEPRECATED] function is deprecated."; break;
                case SmartComm2.SM_F_SERIALNORESPONSE: str = "[SM_F_SERIALNORESPONSE] not responding for serial command."; break;
                // PC/SC SmartCard Service Error Code...
                case SmartComm2.SM_F_SCARD_F_INTERNAL_ERROR: str = "[SCARD_F_INTERNAL_ERROR] An internal consistency check failed."; break;
                case SmartComm2.SM_F_SCARD_E_CANCELLED: str = "[SCARD_E_CANCELLED] The action was cancelled by an SCardCancel request."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_HANDLE: str = "[SCARD_E_INVALID_HANDLE] The supplied handle was invalid."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_PARAMETER: str = "[SCARD_E_INVALID_PARAMETER] One or more of the supplied parameters could not be properly interpreted."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_TARGET: str = "[SCARD_E_INVALID_TARGET] Registry startup information is missing or invalid."; break;
                case SmartComm2.SM_F_SCARD_E_NO_MEMORY: str = "[SCARD_E_NO_MEMORY] Not enough memory available to complete this command."; break;
                case SmartComm2.SM_F_SCARD_F_WAITED_TOO_LONG: str = "[SCARD_F_WAITED_TOO_LONG] An internal consistency timer has expired."; break;
                case SmartComm2.SM_F_SCARD_E_INSUFFICIENT_BUFFER: str = "[SCARD_E_INSUFFICIENT_BUFFER] The data buffer to receive returned data is too small for the returned data."; break;
                case SmartComm2.SM_F_SCARD_E_UNKNOWN_READER: str = "[SCARD_E_UNKNOWN_READER] The specified reader name is not recognized."; break;
                case SmartComm2.SM_F_SCARD_E_TIMEOUT: str = "[SCARD_E_TIMEOUT] The user-specified timeout value has expired."; break;
                case SmartComm2.SM_F_SCARD_E_SHARING_VIOLATION: str = "[SCARD_E_SHARING_VIOLATION] The smart card cannot be accessed because of other connections outstanding."; break;
                case SmartComm2.SM_F_SCARD_E_NO_SMARTCARD: str = "[SCARD_E_NO_SMARTCARD] The operation requires a Smart Card, but no Smart Card is currently in the device."; break;
                case SmartComm2.SM_F_SCARD_E_UNKNOWN_CARD: str = "[SCARD_E_UNKNOWN_CARD] The specified smart card name is not recognized."; break;
                case SmartComm2.SM_F_SCARD_E_CANT_DISPOSE: str = "[SCARD_E_CANT_DISPOSE] The system could not dispose of the media in the requested manner."; break;
                case SmartComm2.SM_F_SCARD_E_PROTO_MISMATCH: str = "[SCARD_E_PROTO_MISMATCH] The requested protocols are incompatible with the protocol currently in use with the smart card."; break;
                case SmartComm2.SM_F_SCARD_E_NOT_READY: str = "[SCARD_E_NOT_READY] The reader or smart card is not ready to accept commands."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_VALUE: str = "[SCARD_E_INVALID_VALUE] One or more of the supplied parameters values could not be properly interpreted."; break;
                case SmartComm2.SM_F_SCARD_E_SYSTEM_CANCELLED: str = "[SCARD_E_SYSTEM_CANCELLED] The action was cancelled by the system, presumably to log off or shut down."; break;
                case SmartComm2.SM_F_SCARD_F_COMM_ERROR: str = "[SCARD_F_COMM_ERROR] An internal communications error has been detected."; break;
                case SmartComm2.SM_F_SCARD_F_UNKNOWN_ERROR: str = "[SCARD_F_UNKNOWN_ERROR] An internal error has been detected, but the source is unknown."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_ATR: str = "[SCARD_E_INVALID_ATR] An ATR obtained from the registry is not a valid ATR string."; break;
                case SmartComm2.SM_F_SCARD_E_NOT_TRANSACTED: str = "[SCARD_E_NOT_TRANSACTED] An attempt was made to end a non-existent transaction."; break;
                case SmartComm2.SM_F_SCARD_E_READER_UNAVAILABLE: str = "[SCARD_E_READER_UNAVAILABLE] The specified reader is not currently available for use."; break;
                case SmartComm2.SM_F_SCARD_P_SHUTDOWN: str = "[SCARD_P_SHUTDOWN] The operation has been aborted to allow the server application to exit."; break;
                case SmartComm2.SM_F_SCARD_E_PCI_TOO_SMALL: str = "[SCARD_E_PCI_TOO_SMALL] The PCI Receive buffer was too small."; break;
                case SmartComm2.SM_F_SCARD_E_READER_UNSUPPORTED: str = "[SCARD_E_READER_UNSUPPORTED] The reader driver does not meet minimal requirements for support."; break;
                case SmartComm2.SM_F_SCARD_E_DUPLICATE_READER: str = "[SCARD_E_DUPLICATE_READER] The reader driver did not produce a unique reader name."; break;
                case SmartComm2.SM_F_SCARD_E_CARD_UNSUPPORTED: str = "[SCARD_E_CARD_UNSUPPORTED] The smart card does not meet minimal requirements for support."; break;
                case SmartComm2.SM_F_SCARD_E_NO_SERVICE: str = "[SCARD_E_NO_SERVICE] The Smart card resource manager is not running."; break;
                case SmartComm2.SM_F_SCARD_E_SERVICE_STOPPED: str = "[SCARD_E_SERVICE_STOPPED] The Smart card resource manager has shut down."; break;
                case SmartComm2.SM_F_SCARD_E_UNEXPECTED: str = "[SCARD_E_UNEXPECTED] An unexpected card error has occurred."; break;
                case SmartComm2.SM_F_SCARD_E_ICC_INSTALLATION: str = "[SCARD_E_ICC_INSTALLATION] No Primary Provider can be found for the smart card."; break;
                case SmartComm2.SM_F_SCARD_E_ICC_CREATEORDER: str = "[SCARD_E_ICC_CREATEORDER] The requested order of object creation is not supported."; break;
                case SmartComm2.SM_F_SCARD_E_UNSUPPORTED_FEATURE: str = "[SCARD_E_UNSUPPORTED_FEATURE] This smart card does not support the requested feature."; break;
                case SmartComm2.SM_F_SCARD_E_DIR_NOT_FOUND: str = "[SCARD_E_DIR_NOT_FOUND] The identified directory does not exist in the smart card."; break;
                case SmartComm2.SM_F_SCARD_E_FILE_NOT_FOUND: str = "[SCARD_E_FILE_NOT_FOUND] The identified file does not exist in the smart card."; break;
                case SmartComm2.SM_F_SCARD_E_NO_DIR: str = "[SCARD_E_NO_DIR] The supplied path does not represent a smart card directory."; break;
                case SmartComm2.SM_F_SCARD_E_NO_FILE: str = "[SCARD_E_NO_FILE] The supplied path does not represent a smart card file."; break;
                case SmartComm2.SM_F_SCARD_E_NO_ACCESS: str = "[SCARD_E_NO_ACCESS] Access is denied to this file."; break;
                case SmartComm2.SM_F_SCARD_E_WRITE_TOO_MANY: str = "[SCARD_E_WRITE_TOO_MANY] The smartcard does not have enough memory to store the information."; break;
                case SmartComm2.SM_F_SCARD_E_BAD_SEEK: str = "[SCARD_E_BAD_SEEK] There was an error trying to set the smart card file object pointer."; break;
                case SmartComm2.SM_F_SCARD_E_INVALID_CHV: str = "[SCARD_E_INVALID_CHV] The supplied PIN is incorrect."; break;
                case SmartComm2.SM_F_SCARD_E_UNKNOWN_RES_MNG: str = "[SCARD_E_UNKNOWN_RES_MNG] An unrecognized error code was returned from a layered component."; break;
                case SmartComm2.SM_F_SCARD_E_NO_SUCH_CERTIFICATE: str = "[SCARD_E_NO_SUCH_CERTIFICATE] The requested certificate does not exist."; break;
                case SmartComm2.SM_F_SCARD_E_CERTIFICATE_UNAVAILABLE: str = "[SCARD_E_CERTIFICATE_UNAVAILABLE] The requested certificate could not be obtained."; break;
                case SmartComm2.SM_F_SCARD_E_NO_READERS_AVAILABLE: str = "[SCARD_E_NO_READERS_AVAILABLE] Cannot find a smart card reader."; break;
                case SmartComm2.SM_F_SCARD_E_COMM_DATA_LOST: str = "[SCARD_E_COMM_DATA_LOST] A communications error with the smart card has been detected.  Retry the operation."; break;
                case SmartComm2.SM_F_SCARD_E_NO_KEY_CONTAINER: str = "[SCARD_E_NO_KEY_CONTAINER] The requested key container does not exist on the smart card."; break;
                case SmartComm2.SM_F_SCARD_E_SERVER_TOO_BUSY: str = "[SCARD_E_SERVER_TOO_BUSY] The Smart card resource manager is too busy to complete this operation."; break;
                // PC/SC SmartCard Service Warning Code...
                case SmartComm2.SM_F_SCARD_W_UNSUPPORTED_CARD: str = "[SCARD_W_UNSUPPORTED_CARD] The smart card is not supported card."; break;
                case SmartComm2.SM_F_SCARD_W_UNRESPONSIVE_CARD: str = "[SCARD_W_UNRESPONSIVE_CARD] The smart card is not responding to a reset."; break;
                case SmartComm2.SM_F_SCARD_W_UNPOWERED_CARD: str = "[SCARD_W_UNPOWERED_CARD] Power has been removed from the smart card, so that further communication is not possible."; break;
                case SmartComm2.SM_F_SCARD_W_RESET_CARD: str = "[SCARD_W_RESET_CARD] The smart card has been reset, so any shared state information is invalid."; break;
                case SmartComm2.SM_F_SCARD_W_REMOVED_CARD: str = "[SCARD_W_REMOVED_CARD] The smart card has been removed, so that further communication is not possible."; break;
                case SmartComm2.SM_F_SCARD_W_SECURITY_VIOLATION: str = "[SCARD_W_SECURITY_VIOLATION] Access was denied because of a security violation."; break;
                case SmartComm2.SM_F_SCARD_W_WRONG_CHV: str = "[SCARD_W_WRONG_CHV] The card cannot be accessed because the wrong PIN was presented."; break;
                case SmartComm2.SM_F_SCARD_W_CHV_BLOCKED: str = "[SCARD_W_CHV_BLOCKED] The card cannot be accessed because the maximum number of PIN entry attempts has been reached."; break;
                case SmartComm2.SM_F_SCARD_W_EOF: str = "[SCARD_W_EOF] The end of the smart card file has been reached."; break;
                case SmartComm2.SM_F_SCARD_W_CANCELLED_BY_USER: str = "[SCARD_W_CANCELLED_BY_USER] The action was cancelled by the user."; break;
                case SmartComm2.SM_F_SCARD_W_CARD_NOT_AUTHENTICATED: str = "[SCARD_W_CARD_NOT_AUTHENTICATED] No PIN was presented to the smart card."; break;

            }
            MessageBox.Show(str);
        }

        private void btn_MoveFromFliper_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;

            UInt64 status = 0L;//打印机状态

            UInt64 Fstatus = 0L;//翻转模块状态

            bool flipper = false;//是否双面模块

            //1.先检测打印机是否连接双面模块

            nres = m_Smart.GetStatus(ref status);

            flipper = ((status & SmartComm2.S51PS_S_CONNFLIPPER) != 0);//true 为安装双面模块  false为未安装

            if (!flipper)
            {
                MessageBox.Show("未安装双面模块");
                return;
            }

            //检测双面模块是否有卡

            nres = m_Smart.GetFlipStatus(ref Fstatus);

            bool checkcard = false;

            checkcard = ((Fstatus & SmartComm2.S51FS_S_REARSENSOR) != 0);

            if (!checkcard)
            {
                MessageBox.Show("翻转模块无卡，无需移动卡片");
                return;
            }

            //移动卡到翻转模块中间
            nres = m_Smart.MoveSensor(4, 1, -400, 100);//从翻转模块移动到打印机内

            //将卡从翻转模块位置移动到打印机内
            nres = m_Smart.Move(SmartComm2.CARDPOS_FROMROT);//从翻转模块移动到打印机内

            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("移动卡到打印机内失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("移动卡到打印位置成功");
            }
        }

        private void btn_Reboot_Click(object sender, EventArgs e)
        {

            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;

            UInt64 status = 0L;

            nres = m_Smart.GetStatus(ref status);

            if (nres != SmartComm2.SM_SUCCESS)
            {
                ShowResult(nres);
                return;
            }
            m_Smart.Reboot();
            MessageBox.Show("重启执行等待完成");
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            //检测打印机是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;
            nres = m_Smart.DoCleaning();
            if (nres != SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("清洁失败,错误代码:0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }
            else
            {
                MessageBox.Show("根据操作提示完成清洁！");
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            //检测是否连接打印机
            if (!m_Smart.IsOpened())
                return;

            uint nres;


            nres = m_Smart.CloseDocument();
            if (nres != SmartComm2.SM_SUCCESS)
                return;

            nres = m_Smart.SBSEnd();

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            nres = m_Smart.DCLCloseDevice();

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            MessageBox.Show("断开成功");





        }

        private void btn_signlPrint_Click(object sender, EventArgs e)
        {
            //检测是否连接打印机
            if (!m_Smart.IsOpened())
                return;

            //关闭模板 为了防止打印上次的内容
            m_Smart.CloseDocument();

            uint nres;

            //打开模板
            string szdoc;
            szdoc = Application.StartupPath + "\\XDCard.csd";     // 获取模板路径.
            nres = m_Smart.OpenDocument(szdoc);

            //正面赋值
            nres = m_Smart.SetFieldValue("PHOTO", "D:\\0.jpg");
            nres = m_Smart.SetFieldValue("Name", "姓名  李丹琳");
            nres = m_Smart.SetFieldValue("SSCardID", "社会保障号码 372928198812304288");
            nres = m_Smart.SetFieldValue("ID", "人员识别号 888888888");
            nres = m_Smart.SetFieldValue("Date", "发卡日期 2022年09月");

            //背面赋值
            nres = m_Smart.SetFieldValue("BankNo", "622848 02931 57852816");

            if (nres != 0)
            {
                MessageBox.Show("赋值失败，错误代码：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            // 发送任务到设备..
            nres = m_Smart.DCLPrint(SmartComm2.SMART51_PRINTSIDE_FRONT);//单面打印
            if (nres != 0)
            {
                MessageBox.Show("发送打印任务失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            //开始打印...
            nres = m_Smart.DoPrint();
            if (nres != 0)
            {
                MessageBox.Show("打印失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            // 关闭文档.
            nres = m_Smart.CloseDocument();
            if (nres != 0)
            {
                MessageBox.Show("关闭文档失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            MessageBox.Show("打印完成");
        }

        private void btn_BothPrint_Click(object sender, EventArgs e)
        {
            //检测是否连接打印机
            if (!m_Smart.IsOpened())
                return;

            //关闭模板
            m_Smart.CloseDocument();

            //准备打印
            uint nres;

            //打开模板
            string szdoc;
            szdoc = Application.StartupPath + "\\XDCard.csd";     // 获取模板路径.
            nres = m_Smart.OpenDocument(szdoc);

            //正面赋值
            nres = m_Smart.SetFieldValue("PHOTO", "D:\\0.jpg");
            nres = m_Smart.SetFieldValue("Name", "姓名  李双琳");
            nres = m_Smart.SetFieldValue("SSCardID", "社会保障号码 372928198812304288");
            nres = m_Smart.SetFieldValue("ID", "人员识别号 888888888");
            nres = m_Smart.SetFieldValue("Date", "发卡日期 2022年09月");

            //背面赋值
            nres = m_Smart.SetFieldValue("BankNo", "622848 02931 57852816");

            if (nres != 0)
            {
                MessageBox.Show("赋值失败，错误代码：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            // 发送任务到设备..
            nres = m_Smart.DCLPrint(SmartComm2.SMART51_PRINTSIDE_BOTH);//双面打印
            if (nres != 0)
            {
                MessageBox.Show("发送打印任务失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            //开始打印...
            nres = m_Smart.DoPrint();
            if (nres != 0)
            {
                MessageBox.Show("打印失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            // 关闭文档.
            nres = m_Smart.CloseDocument();
            if (nres != 0)
            {
                MessageBox.Show("关闭文档失败,错误代码为：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            MessageBox.Show("打印完成");
        }



        private void timerStatus_Tick(object sender, EventArgs e)
        {

            //获取色带信息
            int type = 0, remain = 0, max = 0, grade = 0;
            uint nres = m_Smart.GetRibbonInfo(ref type, ref max, ref remain, ref grade);
            if (nres == SC2.SmartComm2.SM_SUCCESS)
            {
                switch (type)
                {
                    case SmartComm2.SMART_RIBBON_YMCKO: txtRibbon.Text = "YMCKO"; break;
                    case SmartComm2.SMART_RIBBON_YMCKOK: txtRibbon.Text = "YMCKOK"; break;
                    case SmartComm2.SMART_RIBBON_hYMCKO: txtRibbon.Text = "hYMCKO"; break;
                    case SmartComm2.SMART_RIBBON_KO: txtRibbon.Text = "KO"; break;
                    case SmartComm2.SMART_RIBBON_K: txtRibbon.Text = "K"; break;
                    case SmartComm2.SMART_RIBBON_BO: txtRibbon.Text = "BO"; break;
                    case SmartComm2.SMART_RIBBON_B: txtRibbon.Text = "B"; break;
                    case SmartComm2.SMART_RIBBON_BYMCKO: txtRibbon.Text = "BYMCKO"; break;
                    case SmartComm2.SMART_RIBBON_YMCKFO: txtRibbon.Text = "YMCFKO"; break;
                    case SmartComm2.SMART_RIBBON_REWRITABLE: txtRibbon.Text = "Rewritable"; break;
                    case SmartComm2.SMART_RIBBON_hYMCKOKO: txtRibbon.Text = "hYMCKOKO"; break;
                    case SmartComm2.SMART_RIBBON_YMCKOKR: txtRibbon.Text = "YMCKOKR"; break;
                    default: txtRibbon.Text = String.Format("{0}", type); break;
                }
                txtRemain.Text = String.Format("{0}/{1}", remain, max);

                //获取打印机状态
                UInt64 status = 0;
                nres = m_Smart.GetStatus(ref status);

                txtStatusCode.Text = String.Format("{0,16:X16}", status);
                txtStatus.Text = "";
                for (int i = 0; i < 64; i++)
                {
                    string status_text = "";
                    UInt64 status_flag = status & ((UInt64)1 << i);
                    switch (status_flag)
                    {
                        case SmartComm2.S51PS_M_CARDIN: status_text = "insert card"; break;
                        case SmartComm2.S51PS_M_CARDMOVE: status_text = "move card"; break;
                        case SmartComm2.S51PS_M_CARDMOVEEXT: status_text = "move card between external"; break;
                        case SmartComm2.S51PS_M_CARDEJECT: status_text = "eject card"; break;
                        case SmartComm2.S51PS_M_THEADLIFT: status_text = "lift up/down thermal head"; break;
                        case SmartComm2.S51PS_M_ICLIFT: status_text = "lift up/down ic head"; break;
                        case SmartComm2.S51PS_M_RIBBONSEARCH: status_text = "seek ribbon"; break;
                        case SmartComm2.S51PS_M_RIBBONWIND: status_text = "wind ribbon"; break;
                        case SmartComm2.S51PS_M_MAGNETIC: status_text = "magnetic encoding"; break;
                        case SmartComm2.S51PS_M_PRINT: status_text = "printing"; break;
                        case SmartComm2.S51PS_M_INIT: status_text = "initializing"; break;
                        case SmartComm2.S51PS_S_CONNHOPPER: status_text = "hopper connected"; break;
                        case SmartComm2.S51PS_S_CONNICENCODEER: status_text = "ic encoder connected"; break;
                        case SmartComm2.S51PS_S_CONNMAGNETIC: status_text = "mag. encoder connected"; break;
                        case SmartComm2.S51PS_S_CONNLAMINATOR: status_text = "laminator connected"; break;
                        case SmartComm2.S51PS_S_CONNFLIPPER: status_text = "flipper connected"; break;
                        case SmartComm2.S51PS_S_FLIPPERTOP: status_text = "flipper is top sided"; break;
                        case SmartComm2.S51PS_S_COVEROPENED: status_text = "cover is opened"; break;
                        case SmartComm2.S51PS_S_DETECTIN: status_text = "detect card from in sensor"; break;
                        case SmartComm2.S51PS_S_DETECTOUT: status_text = "detect card from out sensor"; break;
                        case SmartComm2.S51PS_S_CARDEMPTY: status_text = "card empty"; break;
                        case SmartComm2.S51PS_S_RECVPRINTDATA: status_text = "receiving print data"; break;
                        case SmartComm2.S51PS_S_HAVEPRINTDATA: status_text = "hold print data"; break;
                        case SmartComm2.S51PS_S_NEEDCLEANING: status_text = "need cleaning"; break;
                        case SmartComm2.S51PS_S_SWLOCKED: status_text = "locked (s/w)"; break;
                        case SmartComm2.S51PS_S_HWLOCKED: status_text = "locked (h/w)"; break;
                        case SmartComm2.S51PS_M_SBSCOMMAND: status_text = "doing SBS command"; break;
                        case SmartComm2.S51PS_S_SBSMODE: status_text = "SBS mode"; break;
                        case SmartComm2.S51PS_S_TESTMODE: status_text = "test mode"; break;
                        case SmartComm2.S51PS_F_CARDIN: status_text = "failed to insert card"; break;
                        case SmartComm2.S51PS_F_CARDMOVE: status_text = "failed to move card"; break;
                        case SmartComm2.S51PS_F_CARDMOVEEXT: status_text = "failed to move card between external"; break;
                        case SmartComm2.S51PS_F_CARDEJECT: status_text = "failed to eject card"; break;
                        case SmartComm2.S51PS_F_THEADLIFT: status_text = "failed to lift up/down thermal head"; break;
                        case SmartComm2.S51PS_F_ICLIFT: status_text = "failed to lift up/down ic head"; break;
                        case SmartComm2.S51PS_F_RIBBONSEARCH: status_text = "failed to seek ribbon"; break;
                        case SmartComm2.S51PS_F_RIBBONWIND: status_text = "failed to wind ribbon"; break;
                        case SmartComm2.S51PS_F_MAGNETIC: status_text = "failed to encode magnetic"; break;
                        case SmartComm2.S51PS_F_READMAGT1: status_text = "failed to read magnetic track 1"; break;
                        case SmartComm2.S51PS_F_READMAGT2: status_text = "failed to read magnetic track 2"; break;
                        case SmartComm2.S51PS_F_READMAGT3: status_text = "failed to read magnetic track 3"; break;
                        case SmartComm2.S51PS_F_PRINT: status_text = "failed to print"; break;
                        case SmartComm2.S51PS_E_INIT: status_text = "initialize error"; break;
                        case SmartComm2.S51PS_E_CONNEXT: status_text = "connection error -external"; break;
                        case SmartComm2.S51PS_E_CONNLAMINATOR: status_text = "connection error -laminator"; break;
                        case SmartComm2.S51PS_E_CONNFLIPPER: status_text = "connection error -flipper"; break;
                        case SmartComm2.S51PS_E_RIBBON0: status_text = "ribbon remain 0"; break;
                        case SmartComm2.S51PS_E_NORIBBON: status_text = "no ribbon"; break;
                        case SmartComm2.S51PS_E_NOTHEAD: status_text = "no thermal head"; break;
                        case SmartComm2.S51PS_E_OVERHEAT: status_text = "thermal head overheat"; break;
                        case SmartComm2.S51PS_F_INVALIDPRINTDATA: status_text = "invalid printing data"; break;
                        case SmartComm2.S51PS_F_INVALIDPASSWORD: status_text = "incorrect password"; break;
                        case SmartComm2.S51PS_F_SET: status_text = "failed to set"; break;
                        case SmartComm2.S51PS_F_SPOOLFULL: status_text = "printer spool is full"; break;
                        case 0: break;
                        default: status_text = String.Format("(stauts-{0})", i + 1); break;
                    }
                    if (status_text != "")
                        txtStatus.Text += status_text + "\r\n";
                }


            }

            if (nres == SC2.SmartComm2.SM_F_DEVIO ||
                nres == SC2.SmartComm2.SM_F_INVALIDHANDLE)
            {
                txtRibbon.Text = "-";
                txtRemain.Text = "-/-";
                txtStatusCode.Text = "--";
                txtStatus.Text = "* not connected *";

                if (!m_Smart.IsOpened())

                    m_timerStatus.Stop();
            }
        }


        private void timerFStatus_Tick(object sender, EventArgs e)//翻转模块
        {


            //获取翻转模块状态
            uint nres;
            UInt64 Fstatus = 0;
            nres = m_Smart.GetFlipStatus(ref Fstatus);

            txtFStatusCode.Text = String.Format("{0,16:X16}", Fstatus);
            txtFStatus.Text = "";
            for (int i = 0; i < 64; i++)
            {
                string Fstatus_text = "";
                UInt64 Fstatus_flag = Fstatus & ((UInt64)1 << i);
                switch (Fstatus_flag)
                {
                    case SmartComm2.S51FS_S_READY: Fstatus_text = "ready"; break;
                    case SmartComm2.S51FS_S_BUSY: Fstatus_text = "busy (doing something)"; break;
                    case SmartComm2.S51FS_M_CARDMOVE: Fstatus_text = "moving card"; break;
                    case SmartComm2.S51FS_M_CARDIN: Fstatus_text = "inserting card"; break;
                    case SmartComm2.S51FS_M_CARDEJECT: Fstatus_text = "ejecting card"; break;
                    case SmartComm2.S51FS_M_FLIP: Fstatus_text = "flipping"; break;
                    case SmartComm2.S51FS_S_FLIPTRAYTOPSIDED: Fstatus_text = "flip tray top sided"; break;
                    case SmartComm2.S51FS_S_ACTIVATEDREARSENSOR: Fstatus_text = "activated rear sensor"; break;
                    case SmartComm2.S51FS_M_CARDMOVESTEPMOTOR: Fstatus_text = "working card move step motor"; break;
                    case SmartComm2.S51FS_M_FLIPSTEPMOTOR: Fstatus_text = "working flip step motor"; break;
                    case SmartComm2.S51FS_S_COVERCLOSED: Fstatus_text = "cover is closed"; break;
                    case SmartComm2.S51FS_S_CENTERSENSOR: Fstatus_text = "center sensor"; break;
                    case SmartComm2.S51FS_S_REARSENSOR: Fstatus_text = "rear sensor"; break;
                    case SmartComm2.S51FS_S_FLIPSENSOR: Fstatus_text = "flip sensor"; break;
                    case SmartComm2.S51FS_F_CARDIN: Fstatus_text = "failed to card insert"; break;
                    case SmartComm2.S51FS_F_CARDMOVE: Fstatus_text = "failed to card move"; break;
                    case SmartComm2.S51FS_F_CARDEJECT: Fstatus_text = "failed to card eject"; break;
                    case SmartComm2.S51FS_F_MOVEFLIPTRAY: Fstatus_text = "failed to move flip tray"; break;
                    case SmartComm2.S51FS_F_COMMAND: Fstatus_text = "failed while process command"; break;
                    case SmartComm2.S51FS_E_INIT: Fstatus_text = " error from initializing"; break;

                    case 0: break;
                    default: Fstatus_text = String.Format("(stauts-{0})", i + 1); break;
                }
                if (Fstatus_text != "")
                    txtFStatus.Text += Fstatus_text + "\r\n";



            }

            if (nres == SC2.SmartComm2.SM_F_DEVIO ||
                nres == SC2.SmartComm2.SM_F_INVALIDHANDLE)
            {

                txtFStatusCode.Text = "--";
                txtFStatus.Text = "* not connected *";

                if (!m_Smart.IsOpened())

                    m_timerFStatus.Stop();
            }
        }

        private void chkIterStatus_CheckedChanged(object sender, EventArgs e)
        {
            //检测是否连接
            if (!m_Smart.IsOpened())
                return;

            if (chkIterStatus.Checked == true)
                m_timerStatus.Start();
            else
                m_timerStatus.Stop();
        }

        private void chkIterFStatus_CheckedChanged(object sender, EventArgs e)
        {
            //检测是否连接
            if (!m_Smart.IsOpened())
                return;

            if (chkIterFStatus.Checked == true)
                m_timerFStatus.Start();
            else
                m_timerFStatus.Stop();
        }

        private void btn_FlipCard_Click(object sender, EventArgs e)
        {
            //检测是否连接
            if (!m_Smart.IsOpened())
                return;

            uint nres;

            nres = m_Smart.Flip();
            if (nres != SC2.SmartComm2.SM_SUCCESS)
            {
                MessageBox.Show("翻转卡片失败：0x" + nres.ToString("x8"));
                ShowResult(nres);
                return;
            }

            MessageBox.Show("翻转成功");

        }

        private void btnDCLSingle_Click(object sender, EventArgs e)
        {

            uint nres;

            //设置打印机参数
            SmartComm2.SMART51_DEVMODE dm = new SmartComm2.SMART51_DEVMODE();
            nres = m_Smart.GetPrinterSettings2(ref dm);
            if (nres == SmartComm2.SM_SUCCESS)
            {
                dm.oemdev.dwPrtSide = SmartComm2.SMART_PRINTSIDE_FRONT;//打印正面
                dm.oemdev.dwASResolution = 3;//打印分辨率0 300*300 1 300*600 2 300*1200
                dm.oemdev.dwPrtFlipFront = 3;//正面旋转180

                nres = m_Smart.SetPrinterSettings2(dm);
            }


            //图片
            string strimg = Application.StartupPath + "\\0.jpg";

            nres = m_Smart.DrawImage(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_COLOR, 47, 130, 236, 295, strimg);

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            //正面文本

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 170, "宋体", 11, SmartComm2.FONT_BOLD, "姓名  李春䶮");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 228, "宋体", 11, SmartComm2.FONT_BOLD, "社会保障号码  372928198812304115");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 282, "宋体", 11, SmartComm2.FONT_BOLD, "人员识别号  JSA888888888");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 336, "宋体", 11, SmartComm2.FONT_BOLD, "发卡日期  2021年11月");

            if (nres != SmartComm2.SM_SUCCESS)
                return;





            //发送打印任务到打印机
            nres = m_Smart.DCLPrint(SmartComm2.SMART_PRINTSIDE_FRONT);

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            // 打印...
            nres = m_Smart.DoPrint();

            if (nres != SmartComm2.SM_SUCCESS)
            {
                ShowResult(nres);
                return;
            }

            MessageBox.Show("打印成功");

        }

        private void btn_DCLBoth_Click(object sender, EventArgs e)
        {


            uint nres;

            //设置打印机打印双面的参数
            SmartComm2.SMART51_DEVMODE dm = new SmartComm2.SMART51_DEVMODE();
            nres = m_Smart.GetPrinterSettings2(ref dm);
            if (nres == SmartComm2.SM_SUCCESS)
            {
                dm.oemdev.dwPrtSide = SmartComm2.SMART_PRINTSIDE_BOTH;//打印双面
                dm.oemdev.dwASResolution = 2;//打印分辨率0 300*300 1 300*600 2 300*1200
                dm.oemdev.dwPrtFlipFront = 3;//正面旋转180
                dm.oemdev.dwPrtFlipBack = 3;//背面旋转180

                nres = m_Smart.SetPrinterSettings2(dm);
            }

            if (nres != SmartComm2.SM_SUCCESS)
                return;


            //正面

            string strimg = Application.StartupPath + "\\0.jpg";

            nres = m_Smart.DrawImage(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_COLOR, 47, 130, 236, 295, strimg);

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 170, "宋体", 11, SmartComm2.FONT_BOLD, "姓名  李春䶮");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 228, "宋体", 11, SmartComm2.FONT_BOLD, "社会保障号码  372928198812304115");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 282, "宋体", 11, SmartComm2.FONT_BOLD, "人员识别号  JSA888888888");

            nres = m_Smart.DrawText(SmartComm2.PAGE_FRONT, SmartComm2.PANEL_BLACK, 320, 336, "宋体", 11, SmartComm2.FONT_BOLD, "发卡日期  2021年11月");


            //背面

            string strimgb = Application.StartupPath + "\\0.jpg";

            nres = m_Smart.DrawImage(SmartComm2.PAGE_BACK, SmartComm2.PANEL_COLOR, 47, 130, 236, 295, strimgb);

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            nres = m_Smart.DrawText(SmartComm2.PAGE_BACK, SmartComm2.PANEL_BLACK, 320, 170, "宋体", 11, SmartComm2.FONT_BOLD, "姓名  李春䶮");

            nres = m_Smart.DrawText(SmartComm2.PAGE_BACK, SmartComm2.PANEL_BLACK, 320, 228, "宋体", 11, SmartComm2.FONT_BOLD, "社会保障号码  372928198812304115");

            nres = m_Smart.DrawText(SmartComm2.PAGE_BACK, SmartComm2.PANEL_BLACK, 320, 282, "宋体", 11, SmartComm2.FONT_BOLD, "人员识别号  JSA888888888");

            nres = m_Smart.DrawText(SmartComm2.PAGE_BACK, SmartComm2.PANEL_BLACK, 320, 336, "宋体", 11, SmartComm2.FONT_BOLD, "发卡日期  2021年11月");

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            //发送打印任务到打印机
            nres = m_Smart.DCLPrint(SmartComm2.SMART_PRINTSIDE_BOTH);

            if (nres != SmartComm2.SM_SUCCESS)
                return;

            // 打印...
            nres = m_Smart.DoPrint();

            if (nres != SmartComm2.SM_SUCCESS)
            {
                ShowResult(nres);
                return;
            }

            MessageBox.Show("打印成功");
        }






    }
}
