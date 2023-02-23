namespace SEEDALLCardPrinter
{
    partial class SEEDALLCardPrinter
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btn_DCLBoth = new System.Windows.Forms.Button();
            this.btnDCLSingle = new System.Windows.Forms.Button();
            this.btn_FlipCard = new System.Windows.Forms.Button();
            this.chkIterFStatus = new System.Windows.Forms.CheckBox();
            this.txtFStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIterStatus = new System.Windows.Forms.CheckBox();
            this.txtFStatusCode = new System.Windows.Forms.TextBox();
            this.btn_Reboot = new System.Windows.Forms.Button();
            this.txtStatusCode = new System.Windows.Forms.TextBox();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.txtRibbon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Close = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btn_BothPrint = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btn_GetSN = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_signlPrint = new System.Windows.Forms.Button();
            this.btn_MovePrinter = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_ICDown = new System.Windows.Forms.Button();
            this.btn_ICUp = new System.Windows.Forms.Button();
            this.btn_MoveIC = new System.Windows.Forms.Button();
            this.btn_GetFlipStatus = new System.Windows.Forms.Button();
            this.btn_GetRibbonRemain = new System.Windows.Forms.Button();
            this.btn_CardIn = new System.Windows.Forms.Button();
            this.btn_CheckStatus = new System.Windows.Forms.Button();
            this.btn_MoveFromFliper = new System.Windows.Forms.Button();
            this.btn_MoveFliper = new System.Windows.Forms.Button();
            this.btn_MoveRF = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_CardOut = new System.Windows.Forms.Button();
            this.btn_KeepCard = new System.Windows.Forms.Button();
            this.btn_CardOutBack = new System.Windows.Forms.Button();
            this.btn_CardInBack = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btn_DCLBoth);
            this.groupBox6.Controls.Add(this.btnDCLSingle);
            this.groupBox6.Location = new System.Drawing.Point(699, 404);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(300, 180);
            this.groupBox6.TabIndex = 56;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "DCL打印";
            // 
            // btn_DCLBoth
            // 
            this.btn_DCLBoth.Location = new System.Drawing.Point(40, 100);
            this.btn_DCLBoth.Margin = new System.Windows.Forms.Padding(4);
            this.btn_DCLBoth.Name = "btn_DCLBoth";
            this.btn_DCLBoth.Size = new System.Drawing.Size(238, 62);
            this.btn_DCLBoth.TabIndex = 10;
            this.btn_DCLBoth.Text = "双面打印";
            this.btn_DCLBoth.UseVisualStyleBackColor = true;
            this.btn_DCLBoth.Click += new System.EventHandler(this.btn_DCLBoth_Click);
            // 
            // btnDCLSingle
            // 
            this.btnDCLSingle.Location = new System.Drawing.Point(41, 30);
            this.btnDCLSingle.Margin = new System.Windows.Forms.Padding(4);
            this.btnDCLSingle.Name = "btnDCLSingle";
            this.btnDCLSingle.Size = new System.Drawing.Size(238, 62);
            this.btnDCLSingle.TabIndex = 9;
            this.btnDCLSingle.Text = "单面打印";
            this.btnDCLSingle.UseVisualStyleBackColor = true;
            this.btnDCLSingle.Click += new System.EventHandler(this.btnDCLSingle_Click);
            // 
            // btn_FlipCard
            // 
            this.btn_FlipCard.Location = new System.Drawing.Point(1356, 406);
            this.btn_FlipCard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FlipCard.Name = "btn_FlipCard";
            this.btn_FlipCard.Size = new System.Drawing.Size(238, 62);
            this.btn_FlipCard.TabIndex = 55;
            this.btn_FlipCard.Text = "翻转卡片(带双面)";
            this.btn_FlipCard.UseVisualStyleBackColor = true;
            this.btn_FlipCard.Click += new System.EventHandler(this.btn_FlipCard_Click);
            // 
            // chkIterFStatus
            // 
            this.chkIterFStatus.AutoSize = true;
            this.chkIterFStatus.Location = new System.Drawing.Point(1650, 422);
            this.chkIterFStatus.Margin = new System.Windows.Forms.Padding(4);
            this.chkIterFStatus.Name = "chkIterFStatus";
            this.chkIterFStatus.Size = new System.Drawing.Size(295, 22);
            this.chkIterFStatus.TabIndex = 54;
            this.chkIterFStatus.Text = "Read Fliper Status Repeatedly";
            this.chkIterFStatus.UseVisualStyleBackColor = true;
            // 
            // txtFStatus
            // 
            this.txtFStatus.Location = new System.Drawing.Point(1640, 508);
            this.txtFStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtFStatus.Multiline = true;
            this.txtFStatus.Name = "txtFStatus";
            this.txtFStatus.ReadOnly = true;
            this.txtFStatus.Size = new System.Drawing.Size(372, 199);
            this.txtFStatus.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1660, 471);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 51;
            this.label3.Text = "翻转模块状态 :";
            // 
            // chkIterStatus
            // 
            this.chkIterStatus.AutoSize = true;
            this.chkIterStatus.Location = new System.Drawing.Point(1640, 69);
            this.chkIterStatus.Margin = new System.Windows.Forms.Padding(4);
            this.chkIterStatus.Name = "chkIterStatus";
            this.chkIterStatus.Size = new System.Drawing.Size(232, 22);
            this.chkIterStatus.TabIndex = 50;
            this.chkIterStatus.Text = "Read Status Repeatedly";
            this.chkIterStatus.UseVisualStyleBackColor = true;
            // 
            // txtFStatusCode
            // 
            this.txtFStatusCode.Location = new System.Drawing.Point(1803, 464);
            this.txtFStatusCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtFStatusCode.Name = "txtFStatusCode";
            this.txtFStatusCode.ReadOnly = true;
            this.txtFStatusCode.Size = new System.Drawing.Size(172, 28);
            this.txtFStatusCode.TabIndex = 52;
            this.txtFStatusCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Reboot
            // 
            this.btn_Reboot.Location = new System.Drawing.Point(51, 27);
            this.btn_Reboot.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Reboot.Name = "btn_Reboot";
            this.btn_Reboot.Size = new System.Drawing.Size(238, 62);
            this.btn_Reboot.TabIndex = 18;
            this.btn_Reboot.Text = "重启打印机";
            this.btn_Reboot.UseVisualStyleBackColor = true;
            this.btn_Reboot.Click += new System.EventHandler(this.btn_Reboot_Click);
            // 
            // txtStatusCode
            // 
            this.txtStatusCode.Location = new System.Drawing.Point(1738, 165);
            this.txtStatusCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatusCode.Name = "txtStatusCode";
            this.txtStatusCode.ReadOnly = true;
            this.txtStatusCode.Size = new System.Drawing.Size(172, 28);
            this.txtStatusCode.TabIndex = 49;
            this.txtStatusCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Clean
            // 
            this.btn_Clean.Location = new System.Drawing.Point(51, 102);
            this.btn_Clean.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(238, 62);
            this.btn_Clean.TabIndex = 18;
            this.btn_Clean.Text = "清洁打印机";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1647, 170);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 48;
            this.label2.Text = "状态 :";
            // 
            // txtRemain
            // 
            this.txtRemain.Location = new System.Drawing.Point(1832, 126);
            this.txtRemain.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.ReadOnly = true;
            this.txtRemain.Size = new System.Drawing.Size(79, 28);
            this.txtRemain.TabIndex = 47;
            this.txtRemain.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRibbon
            // 
            this.txtRibbon.Location = new System.Drawing.Point(1738, 126);
            this.txtRibbon.Margin = new System.Windows.Forms.Padding(4);
            this.txtRibbon.Name = "txtRibbon";
            this.txtRibbon.ReadOnly = true;
            this.txtRibbon.Size = new System.Drawing.Size(98, 28);
            this.txtRibbon.TabIndex = 46;
            this.txtRibbon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1647, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 45;
            this.label1.Text = "色带 :";
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(1365, 525);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(238, 62);
            this.btn_Close.TabIndex = 43;
            this.btn_Close.Text = "断开打印机";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_Clean);
            this.groupBox5.Controls.Add(this.btn_Reboot);
            this.groupBox5.Location = new System.Drawing.Point(999, 406);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(321, 180);
            this.groupBox5.TabIndex = 41;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "打印机维护";
            // 
            // btn_BothPrint
            // 
            this.btn_BothPrint.Location = new System.Drawing.Point(40, 100);
            this.btn_BothPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btn_BothPrint.Name = "btn_BothPrint";
            this.btn_BothPrint.Size = new System.Drawing.Size(238, 62);
            this.btn_BothPrint.TabIndex = 10;
            this.btn_BothPrint.Text = "双面打印";
            this.btn_BothPrint.UseVisualStyleBackColor = true;
            this.btn_BothPrint.Click += new System.EventHandler(this.btn_BothPrint_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(1640, 207);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(372, 199);
            this.txtStatus.TabIndex = 44;
            // 
            // btn_GetSN
            // 
            this.btn_GetSN.Location = new System.Drawing.Point(1365, 69);
            this.btn_GetSN.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GetSN.Name = "btn_GetSN";
            this.btn_GetSN.Size = new System.Drawing.Size(238, 62);
            this.btn_GetSN.TabIndex = 42;
            this.btn_GetSN.Text = "获取打印机序列号";
            this.btn_GetSN.UseVisualStyleBackColor = true;
            this.btn_GetSN.Click += new System.EventHandler(this.btn_GetSN_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_BothPrint);
            this.groupBox4.Controls.Add(this.btn_signlPrint);
            this.groupBox4.Location = new System.Drawing.Point(382, 406);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(300, 180);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CSD打印";
            // 
            // btn_signlPrint
            // 
            this.btn_signlPrint.Location = new System.Drawing.Point(41, 30);
            this.btn_signlPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btn_signlPrint.Name = "btn_signlPrint";
            this.btn_signlPrint.Size = new System.Drawing.Size(238, 62);
            this.btn_signlPrint.TabIndex = 9;
            this.btn_signlPrint.Text = "单面打印";
            this.btn_signlPrint.UseVisualStyleBackColor = true;
            this.btn_signlPrint.Click += new System.EventHandler(this.btn_signlPrint_Click);
            // 
            // btn_MovePrinter
            // 
            this.btn_MovePrinter.Location = new System.Drawing.Point(415, 44);
            this.btn_MovePrinter.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MovePrinter.Name = "btn_MovePrinter";
            this.btn_MovePrinter.Size = new System.Drawing.Size(238, 62);
            this.btn_MovePrinter.TabIndex = 5;
            this.btn_MovePrinter.Text = "移动到打印位置";
            this.btn_MovePrinter.UseVisualStyleBackColor = true;
            this.btn_MovePrinter.Click += new System.EventHandler(this.btn_MovePrinter_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_ICDown);
            this.groupBox3.Controls.Add(this.btn_ICUp);
            this.groupBox3.Location = new System.Drawing.Point(44, 404);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(300, 183);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接触IC控制";
            // 
            // btn_ICDown
            // 
            this.btn_ICDown.Location = new System.Drawing.Point(34, 30);
            this.btn_ICDown.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ICDown.Name = "btn_ICDown";
            this.btn_ICDown.Size = new System.Drawing.Size(238, 62);
            this.btn_ICDown.TabIndex = 6;
            this.btn_ICDown.Text = "接触式读头落下";
            this.btn_ICDown.UseVisualStyleBackColor = true;
            this.btn_ICDown.Click += new System.EventHandler(this.btn_ICDown_Click);
            // 
            // btn_ICUp
            // 
            this.btn_ICUp.Location = new System.Drawing.Point(34, 100);
            this.btn_ICUp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_ICUp.Name = "btn_ICUp";
            this.btn_ICUp.Size = new System.Drawing.Size(238, 62);
            this.btn_ICUp.TabIndex = 7;
            this.btn_ICUp.Text = "接触式读头抬起";
            this.btn_ICUp.UseVisualStyleBackColor = true;
            this.btn_ICUp.Click += new System.EventHandler(this.btn_ICUp_Click);
            // 
            // btn_MoveIC
            // 
            this.btn_MoveIC.Location = new System.Drawing.Point(49, 44);
            this.btn_MoveIC.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MoveIC.Name = "btn_MoveIC";
            this.btn_MoveIC.Size = new System.Drawing.Size(238, 62);
            this.btn_MoveIC.TabIndex = 4;
            this.btn_MoveIC.Text = "接触IC位置";
            this.btn_MoveIC.UseVisualStyleBackColor = true;
            this.btn_MoveIC.Click += new System.EventHandler(this.btn_MoveIC_Click);
            // 
            // btn_GetFlipStatus
            // 
            this.btn_GetFlipStatus.Location = new System.Drawing.Point(760, 69);
            this.btn_GetFlipStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GetFlipStatus.Name = "btn_GetFlipStatus";
            this.btn_GetFlipStatus.Size = new System.Drawing.Size(238, 62);
            this.btn_GetFlipStatus.TabIndex = 36;
            this.btn_GetFlipStatus.Text = "检测翻转模块状态";
            this.btn_GetFlipStatus.UseVisualStyleBackColor = true;
            this.btn_GetFlipStatus.Click += new System.EventHandler(this.btn_GetFlipStatus_Click);
            // 
            // btn_GetRibbonRemain
            // 
            this.btn_GetRibbonRemain.Location = new System.Drawing.Point(1084, 69);
            this.btn_GetRibbonRemain.Margin = new System.Windows.Forms.Padding(4);
            this.btn_GetRibbonRemain.Name = "btn_GetRibbonRemain";
            this.btn_GetRibbonRemain.Size = new System.Drawing.Size(238, 62);
            this.btn_GetRibbonRemain.TabIndex = 35;
            this.btn_GetRibbonRemain.Text = "获取色带信息";
            this.btn_GetRibbonRemain.UseVisualStyleBackColor = true;
            this.btn_GetRibbonRemain.Click += new System.EventHandler(this.btn_GetRibbonRemain_Click);
            // 
            // btn_CardIn
            // 
            this.btn_CardIn.Location = new System.Drawing.Point(35, 36);
            this.btn_CardIn.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CardIn.Name = "btn_CardIn";
            this.btn_CardIn.Size = new System.Drawing.Size(238, 62);
            this.btn_CardIn.TabIndex = 3;
            this.btn_CardIn.Text = "前进卡";
            this.btn_CardIn.UseVisualStyleBackColor = true;
            this.btn_CardIn.Click += new System.EventHandler(this.btn_CardIn_Click);
            // 
            // btn_CheckStatus
            // 
            this.btn_CheckStatus.Location = new System.Drawing.Point(417, 69);
            this.btn_CheckStatus.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CheckStatus.Name = "btn_CheckStatus";
            this.btn_CheckStatus.Size = new System.Drawing.Size(238, 62);
            this.btn_CheckStatus.TabIndex = 34;
            this.btn_CheckStatus.Text = "检测打印机状态";
            this.btn_CheckStatus.UseVisualStyleBackColor = true;
            this.btn_CheckStatus.Click += new System.EventHandler(this.btn_CheckStatus_Click);
            // 
            // btn_MoveFromFliper
            // 
            this.btn_MoveFromFliper.Location = new System.Drawing.Point(709, 114);
            this.btn_MoveFromFliper.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MoveFromFliper.Name = "btn_MoveFromFliper";
            this.btn_MoveFromFliper.Size = new System.Drawing.Size(238, 62);
            this.btn_MoveFromFliper.TabIndex = 19;
            this.btn_MoveFromFliper.Text = "从双面移动到打印机";
            this.btn_MoveFromFliper.UseVisualStyleBackColor = true;
            this.btn_MoveFromFliper.Click += new System.EventHandler(this.btn_MoveFromFliper_Click);
            // 
            // btn_MoveFliper
            // 
            this.btn_MoveFliper.Location = new System.Drawing.Point(415, 114);
            this.btn_MoveFliper.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MoveFliper.Name = "btn_MoveFliper";
            this.btn_MoveFliper.Size = new System.Drawing.Size(238, 62);
            this.btn_MoveFliper.TabIndex = 18;
            this.btn_MoveFliper.Text = "移动到双面位置";
            this.btn_MoveFliper.UseVisualStyleBackColor = true;
            this.btn_MoveFliper.Click += new System.EventHandler(this.btn_MoveFliper_Click);
            // 
            // btn_MoveRF
            // 
            this.btn_MoveRF.Location = new System.Drawing.Point(49, 114);
            this.btn_MoveRF.Margin = new System.Windows.Forms.Padding(4);
            this.btn_MoveRF.Name = "btn_MoveRF";
            this.btn_MoveRF.Size = new System.Drawing.Size(238, 62);
            this.btn_MoveRF.TabIndex = 15;
            this.btn_MoveRF.Text = "非接触位置";
            this.btn_MoveRF.UseVisualStyleBackColor = true;
            this.btn_MoveRF.Click += new System.EventHandler(this.btn_MoveRF_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_MoveFromFliper);
            this.groupBox2.Controls.Add(this.btn_MoveFliper);
            this.groupBox2.Controls.Add(this.btn_MoveRF);
            this.groupBox2.Controls.Add(this.btn_MoveIC);
            this.groupBox2.Controls.Add(this.btn_CardOut);
            this.groupBox2.Controls.Add(this.btn_KeepCard);
            this.groupBox2.Controls.Add(this.btn_CardOutBack);
            this.groupBox2.Controls.Add(this.btn_MovePrinter);
            this.groupBox2.Location = new System.Drawing.Point(382, 184);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1221, 201);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "移动卡到";
            // 
            // btn_CardOut
            // 
            this.btn_CardOut.Location = new System.Drawing.Point(709, 44);
            this.btn_CardOut.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CardOut.Name = "btn_CardOut";
            this.btn_CardOut.Size = new System.Drawing.Size(238, 62);
            this.btn_CardOut.TabIndex = 10;
            this.btn_CardOut.Text = "前出卡（废卡盒）";
            this.btn_CardOut.UseVisualStyleBackColor = true;
            this.btn_CardOut.Click += new System.EventHandler(this.btn_CardOut_Click);
            // 
            // btn_KeepCard
            // 
            this.btn_KeepCard.Location = new System.Drawing.Point(981, 44);
            this.btn_KeepCard.Margin = new System.Windows.Forms.Padding(4);
            this.btn_KeepCard.Name = "btn_KeepCard";
            this.btn_KeepCard.Size = new System.Drawing.Size(238, 62);
            this.btn_KeepCard.TabIndex = 12;
            this.btn_KeepCard.Text = "后出卡持卡";
            this.btn_KeepCard.UseVisualStyleBackColor = true;
            this.btn_KeepCard.Click += new System.EventHandler(this.btn_KeepCard_Click);
            // 
            // btn_CardOutBack
            // 
            this.btn_CardOutBack.Location = new System.Drawing.Point(981, 114);
            this.btn_CardOutBack.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CardOutBack.Name = "btn_CardOutBack";
            this.btn_CardOutBack.Size = new System.Drawing.Size(238, 62);
            this.btn_CardOutBack.TabIndex = 11;
            this.btn_CardOutBack.Text = "后出卡不持卡";
            this.btn_CardOutBack.UseVisualStyleBackColor = true;
            this.btn_CardOutBack.Click += new System.EventHandler(this.btn_CardOutBack_Click);
            // 
            // btn_CardInBack
            // 
            this.btn_CardInBack.Location = new System.Drawing.Point(35, 106);
            this.btn_CardInBack.Margin = new System.Windows.Forms.Padding(4);
            this.btn_CardInBack.Name = "btn_CardInBack";
            this.btn_CardInBack.Size = new System.Drawing.Size(238, 62);
            this.btn_CardInBack.TabIndex = 14;
            this.btn_CardInBack.Text = "后进卡";
            this.btn_CardInBack.UseVisualStyleBackColor = true;
            this.btn_CardInBack.Click += new System.EventHandler(this.btn_CardInBack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_CardInBack);
            this.groupBox1.Controls.Add(this.btn_CardIn);
            this.groupBox1.Location = new System.Drawing.Point(44, 184);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(300, 201);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "进卡";
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(72, 69);
            this.btn_Open.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(238, 62);
            this.btn_Open.TabIndex = 33;
            this.btn_Open.Text = "连接打印机";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // SEEDALLCardPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 779);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btn_FlipCard);
            this.Controls.Add(this.chkIterFStatus);
            this.Controls.Add(this.txtFStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIterStatus);
            this.Controls.Add(this.txtFStatusCode);
            this.Controls.Add(this.txtStatusCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.txtRibbon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btn_GetSN);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_GetFlipStatus);
            this.Controls.Add(this.btn_GetRibbonRemain);
            this.Controls.Add(this.btn_CheckStatus);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Open);
            this.Name = "SEEDALLCardPrinter";
            this.Text = "SEEDALLCardPrinter";
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btn_DCLBoth;
        private System.Windows.Forms.Button btnDCLSingle;
        private System.Windows.Forms.Button btn_FlipCard;
        private System.Windows.Forms.CheckBox chkIterFStatus;
        private System.Windows.Forms.TextBox txtFStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIterStatus;
        private System.Windows.Forms.TextBox txtFStatusCode;
        private System.Windows.Forms.Button btn_Reboot;
        private System.Windows.Forms.TextBox txtStatusCode;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.TextBox txtRibbon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btn_BothPrint;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btn_GetSN;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_signlPrint;
        private System.Windows.Forms.Button btn_MovePrinter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_ICDown;
        private System.Windows.Forms.Button btn_ICUp;
        private System.Windows.Forms.Button btn_MoveIC;
        private System.Windows.Forms.Button btn_GetFlipStatus;
        private System.Windows.Forms.Button btn_GetRibbonRemain;
        private System.Windows.Forms.Button btn_CardIn;
        private System.Windows.Forms.Button btn_CheckStatus;
        private System.Windows.Forms.Button btn_MoveFromFliper;
        private System.Windows.Forms.Button btn_MoveFliper;
        private System.Windows.Forms.Button btn_MoveRF;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_CardOut;
        private System.Windows.Forms.Button btn_KeepCard;
        private System.Windows.Forms.Button btn_CardOutBack;
        private System.Windows.Forms.Button btn_CardInBack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Open;

    }
}

